using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using GaTech.Chai.Share;
using GaTech.Chai.UsCore;
using GaTech.Chai.Vrdr;
using GaTech.Chai.Odh;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using GaTech.Chai.Mdi;
using GaTech.Chai.Vdor;
using System.Text;

namespace GaTech.Chai.Nvdrs;

public class FlatObjectTox : FlatObject
{
    List<JsonArray> DataArrays = [];

    public FlatObjectTox(string outputFileFormat = "flat", string filename = "TOX_2026.json", string? path = null) : base(filename, path)
    {
        if (!"TOX".Equals(FlatType))
        {
            throw new NotSupportedException("This flat object only support Tox flat format");
        }

        this.outputFileFormat = outputFileFormat;
    }

    protected List<Dictionary<string, object?>> GetToxicologyFindingsSubstanceInfo(List<Resource> toxicologyResources)
    {
        string? substanceName = null;
        CodeableConcept? substanceTested = null;
        CodeableConcept? substanceResult = null;
        bool substanceCausedDeath = false;
        CodeableConcept? drugObtainedFor = null;
        List<Dictionary<string, object?>> substanceInfoList = [];

        foreach (Resource resource in toxicologyResources)
        {
            if (resource is Observation obs)
            {
                if (VdorCustomCs.ToxicologyFindings.CodingExist(obs.Code))
                {
                    Dictionary<string, object?> substanceInfo = [];

                    // Get Components from this observation.
                    List<Observation.ComponentComponent> components = obs.Component;
                    foreach (Observation.ComponentComponent component in components)
                    {
                        if (VdorCustomCs.SubstanceName.CodingExist(component.Code))
                        {
                            if (component.Value is FhirString substanceNameValue)
                            {
                                substanceName = substanceNameValue.Value;
                                substanceInfo["SubstanceName"] = substanceName;
                            }
                        }
                        else if (VdorCustomCs.SubstanceTested.CodingExist(component.Code))
                        {
                            substanceTested = component.Value as CodeableConcept;
                            substanceInfo["SubstanceTested"] = substanceTested;
                        }
                        else if (VdorCustomCs.SubstanceResult.CodingExist(component.Code))
                        {
                            substanceResult = component.Value as CodeableConcept;
                            substanceInfo["SubstanceResult"] = substanceResult;
                        }
                        else if (VdorCustomCs.SubstanceCausedDeath.CodingExist(component.Code))
                        {
                            if (component.Value is FhirBoolean SubstanceCausedDeathValue)
                            {
                                if (SubstanceCausedDeathValue != null)
                                {
                                    if (SubstanceCausedDeathValue.Value != null)
                                    {
                                        substanceCausedDeath = (bool)SubstanceCausedDeathValue.Value;
                                        substanceInfo["SubstanceCausedDeath"] = substanceCausedDeath;
                                    }
                                }
                            }
                        }
                        else if (VdorCustomCs.DrugObtainedFor.CodingExist(component.Code))
                        {
                            drugObtainedFor = component.Value as CodeableConcept;
                            substanceInfo["DrugObtainedFor"] = drugObtainedFor;
                        }
                    }

                    substanceInfoList.Add(substanceInfo);
                }
            }
        }

        return substanceInfoList;
    }

    public override void MapToNVDRS(Bundle bundle)
    {
        if (bundle.Meta != null && bundle.Meta.Profile != null && bundle.Meta.Profile.Any())
        {
            Boolean isOk = false;
            foreach (string profile in bundle.Meta.Profile)
            {
                if (VdorDocumentBundle.ProfileUrl.Equals(profile))
                {
                    isOk = true;
                    break;
                }
            }

            if (!isOk)
            {

                throw new NotSupportedException("This flat object only support VDOR FHIR Document Bundle with profile " + VdorDocumentBundle.ProfileUrl);
            }

            // Now Map the NVDRS FHIR CME Document to NVDRS. This is manual mapping.
            Composition composition = bundle.VdorDocumentBundle().VdorComposition ?? throw new Exception("Composition missing in Bundle document.");
            // get the List of entries in the Toxicology section
            List<Resource> toxicologyResources = composition.VdorComposition().GetSectionByCode(VdorCustomCs.Toxicology);

            // Before we get into the flatfile object mapping, get toxicology findings values from the toxicology findings observation components.
            List<Dictionary<string, object?>> substanceInfoList = GetToxicologyFindingsSubstanceInfo(toxicologyResources);

            // Mapping Process with a simple iteration over the data array.
            foreach (Dictionary<string, object?> substanceInfo in substanceInfoList) {
                // since we have muultiple substances, we will create multiple rows in the flat file, so we need to iterate through the data array for each substance and write to file separately for each substance.
                JsonArray ToxDataArray = (JsonArray) DataArray.DeepClone();
                foreach (JsonNode? data in ToxDataArray)
                {
                    if ("IncidentYear".Equals(data!["name"]!.GetValue<string>())) // 1-4
                    {
                        if (composition.VdorComposition().IncidentYear != null)
                        {
                            string incidentYearDate = composition.VdorComposition().IncidentYear!.Value;
                            string[] incidentdatepart = incidentYearDate.Split('-');
                            StringWriteToData(data, incidentdatepart[0]);
                        }
                    }
                    else if ("IncidentNumber".Equals(data!["name"]!.GetValue<string>())) // 5-14
                    {
                        if (composition.VdorComposition().IncidentNumber != null)
                        {
                            StringWriteToData(data, composition.VdorComposition().IncidentNumber, Alignment.RIGHT);
                        }
                    }
                    else if ("VictimNumber".Equals(data!["name"]!.GetValue<string>())) // 15-18
                    {
                        Identifier? additionalId = composition.VdorComposition().GetAdditionalIdentifier(VdorCustomUris.victimnumberIdentifierUrl);
                        if (additionalId != null)
                        {
                            StringWriteToData(data, additionalId.Value, Alignment.RIGHT);
                        }
                    }
                    else if ("SubstanceName".Equals(data!["name"]!.GetValue<string>())) // 19-118
                    {
                        string? substanceName = substanceInfo.ContainsKey("SubstanceName") ? substanceInfo["SubstanceName"] as string : null;
                        if (substanceName != null)
                        {
                            StringWriteToData(data, substanceName);
                        }
                    }
                    else if ("SubstanceTested".Equals(data!["name"]!.GetValue<string>())) // 119-119
                    {
                        CodeableConcept? substanceTested = substanceInfo.ContainsKey("SubstanceTested") ? substanceInfo["SubstanceTested"] as CodeableConcept : null;
                        if (substanceTested != null)
                        {
                            if (substanceTested.Matches(VdorToxSubstanceTestedVs.Unknown))
                            {
                                StringWriteToData(data, "9");
                            }
                            else
                            {
                                string resp = substanceTested.Coding[0].Code;
                                StringWriteToData(data, resp[^1].ToString());
                            }
                        }
                    }
                    else if ("SubstanceResult".Equals(data!["name"]!.GetValue<string>())) // 120-120
                    {
                        CodeableConcept? substanceResult = substanceInfo.ContainsKey("SubstanceResult") ? substanceInfo["SubstanceResult"] as CodeableConcept : null;
                        if (substanceResult != null)
                        {
                            if (substanceResult.Matches(VdorToxSubstanceTestedVs.Unknown))
                            {
                                StringWriteToData(data, "9");
                            }
                            else
                            {
                                string resp = substanceResult.Coding[0].Code;
                                StringWriteToData(data, resp[^1].ToString());
                            }
                        }
                    }
                    else if ("IsSubstanceCausedDeath".Equals(data!["name"]!.GetValue<string>())) // 139-148
                    {
                        bool? substanceCausedDeath = substanceInfo.ContainsKey("SubstanceCausedDeath") ? (bool)substanceInfo["SubstanceCausedDeath"]! : null;
                        if (substanceCausedDeath != null) {
                            if (substanceCausedDeath == true)
                            {
                                StringWriteToData(data, "1");
                            }
                            else
                            {
                                StringWriteToData(data, "0");
                            }
                        }
                    }
                    else if ("DrugObtainedFor".Equals(data!["name"]!.GetValue<string>())) // 149-150
                    {
                        CodeableConcept? drugObtainedFor = substanceInfo.ContainsKey("DrugObtainedFor") ? substanceInfo["DrugObtainedFor"] as CodeableConcept : null;
                        if (drugObtainedFor != null)
                        {
                            string resp = drugObtainedFor.Coding[0].Code;
                            StringWriteToData(data, resp[^1].ToString());
                        }
                    }
                }

                // Store this data in the list.
                DataArrays.Add(ToxDataArray);
            }
        }
    }

    List<Dictionary<string, string[]>> toxCsvValues = new List<Dictionary<string, string[]>>();
    List<string> flatSequences = new List<string>();

    public override void PopulateSequence()
    {
        // loop through data and populate the byte sequence.
        foreach (JsonArray? dataArray in DataArrays)
        {
            Dictionary<string, string[]> csvValue = [];
            byte[] flatSequence = new byte[FlatSize];

            foreach (JsonNode? data in dataArray)
            {
                int startIndex = data!["firstColumn"]!.GetValue<int>() - 1;
                int endIndex = data!["lastColumn"]!.GetValue<int>();

                string? nodeName = data["name"]!.GetValue<string>();
                string? value = data["value"]!.GetValue<string>();
                string? dataType = data["dataType"]!.GetValue<string>();
                if (value != null && value != "")
                {
                    try
                    {
                        if (outputFileFormat.Equals("csv"))
                        {
                            csvValue[nodeName] = [value.Trim(), dataType.Trim()];
                        }
                        else
                        {
                            char[] valueCharacters = value.ToCharArray();
                            for (int i = startIndex; i < endIndex; i++)
                            {
                                flatSequence[i] = Convert.ToByte(valueCharacters[i - startIndex]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + nodeName + " config has an issue(s)\n" + ex.Message);
                    }
                }
            }

            toxCsvValues.Add(csvValue);
            flatSequences.Add(Encoding.UTF8.GetString(flatSequence));
        }
    }

    public override void ExportToFile(string? filename = null)
    {
        if (filename == null || filename == "")
        {
            string dateTimeTag = DateTime.Now.ToString("MMddyyyyhmmtt");
            if (outputFileFormat.Equals("csv"))
            {
                filename = FlatType + "_" + dateTimeTag + ".csv";
            }
            else
            {
                filename = FlatType + "_" + dateTimeTag + ".txt";
            }
        }

        // Populate data to flatsequnce or csvValues.
        PopulateSequence();

        if (outputFileFormat.Equals("csv"))
        {
            // Export csvValues to csv file.
            // using (var writer = new StreamWriter(filename))
            // {
            //     // Write data type header
            //     writer.WriteLine(string.Join(",", csvValues.Select(kv => kv.Key + " (" + kv.Value[1] + ")")));
            //     // Write header
            //     writer.WriteLine(string.Join(",",csvValues.Keys));

            //     // Write values
            //     writer.WriteLine(string.Join(",", csvValues.Values));
            // }

            using (var writer = new StreamWriter(filename, false, Encoding.UTF8))
            {
                // --- ROW 1: Second element of the array (Index 1) ---
                var row1SecondValues = new List<string>();
                foreach (var kvp in toxCsvValues[0])
                {
                    // Verify index exists to prevent crashes
                    string val = (kvp.Value != null && kvp.Value.Length > 1) ? kvp.Value[1] : string.Empty;
                    row1SecondValues.Add(EscapeCsvField(val));
                }
                writer.WriteLine(string.Join(",", row1SecondValues));

                // --- ROW 2: Dictionary Keys ---
                var row2Keys = new List<string>();
                foreach (var kvp in toxCsvValues[0])
                {
                    row2Keys.Add(EscapeCsvField(kvp.Key));
                }
                writer.WriteLine(string.Join(",", row2Keys));

                // --- ROW 3 and more: toxicolgy findings substances ---
                foreach (Dictionary<string, string[]> csvValue in toxCsvValues)
                {
                    var row3FirstValues = new List<string>();
                    foreach (var kvp in csvValue)
                    {
                        string val = (kvp.Value != null && kvp.Value.Length > 0) ? kvp.Value[0] : string.Empty;
                        row3FirstValues.Add(EscapeCsvField(val));
                    }
                    writer.WriteLine(string.Join(",", row3FirstValues));
                }
            }
        }
        else
        {
            foreach (string flatSequence in flatSequences)
            {
                File.WriteAllBytes(filename, Encoding.UTF8.GetBytes(flatSequence));
            }
        }
    }
}
