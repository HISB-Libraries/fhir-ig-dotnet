using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using Hl7.Fhir.Model;
using GaTech.Chai.Vdor;
using System.Text;

namespace GaTech.Chai.Nvdrs;

public abstract class FlatObject
{
    JsonNode rootNode;
    byte[] flatSequence;
    readonly Dictionary<string, string[]> csvValues = [];
    protected string outputFileFormat = "flat";


    public enum Alignment { LEFT, RIGHT };

    public FlatObject(string filename, string? path = null)
    {
        JsonNode? jsonNode = null;
        if (path != null && path != "")
        {
            // Get flatfile configuration file.
            // var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // var filePath = buildDir + @"/NvdrsExport/" + filename;
            var filePath = filename;
            if (path.EndsWith("/") || path.EndsWith("\\"))
            {
                filePath = path + filename;
            }
            else
            {
                filePath = path + "/" + filename;
            }

            // Create an instance of StreamReader to read from a file.
            FileStream SourceStream = File.Open(filePath, FileMode.Open);
            jsonNode = JsonNode.Parse(SourceStream);
        }
        else
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = @"GaTech.Chai.Vdor.NvdrsExport." + filename;

            using Stream? stream = assembly.GetManifestResourceStream(resourceName) ?? throw new FileNotFoundException($"Embedded resource '{resourceName}' was not found.");
            using StreamReader reader = new StreamReader(stream);
            jsonNode = JsonNode.Parse(reader.ReadToEnd());
        }

        if (jsonNode == null)
        {
            throw new JsonException(filename + " has no JSON nodes");
        }
        else
        {
            rootNode = jsonNode;
        }

        // create the flat data sequnce size.
        if (FlatSize <= 0)
        {
            throw new Exception(filename + " must contain length or greater than 0.");
        }

        flatSequence = new byte[FlatSize];
        for (int i = 0; i < FlatSize; i++)
        {
            flatSequence[i] = (byte)' ';
        }
    }

    public string? Version => rootNode["version"]!.GetValue<string>();
    public string? FlatType => rootNode["type"]!.GetValue<string>();
    public int FlatSize
    {
        get
        {
            if (rootNode == null)
            {
                return 0;
            }

            return rootNode["length"]!.GetValue<int>();
        }
    }

    public JsonArray DataArray => rootNode["data"]!.AsArray();

    public virtual void MapToNVDRS(Bundle bundle)
    {
        // Implement this in the child class
    }

    protected void StringWriteToData(JsonNode data, string? value, Alignment alignment = Alignment.LEFT)
    {
        if (value == null)
        {
            return;
        }

        int start = data["firstColumn"]!.GetValue<int>();
        int end = data["lastColumn"]!.GetValue<int>();
        int length = end - start + 1;
        int valueLength = value.Length;

        if (valueLength > length)
        {
            throw new OverflowException(value + " is larger than field size (" + length + ")");
        }

        if (alignment == Alignment.LEFT)
        {
            data["value"] = value.PadRight(length);
        }
        else
        {
            data["value"] = value.PadLeft(length);
        }
    }

    public virtual void PopulateSequence()
    {
        // loop through data and populate the byte sequence.
        foreach (JsonNode? data in DataArray)
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
                        csvValues[nodeName] = [value.Trim(), dataType.Trim()];
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
    }

    public virtual void ExportToFile(string? filename = null)
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
                foreach (var kvp in csvValues)
                {
                    // Verify index exists to prevent crashes
                    string val = (kvp.Value != null && kvp.Value.Length > 1) ? kvp.Value[1] : string.Empty;
                    row1SecondValues.Add(EscapeCsvField(val));
                }
                writer.WriteLine(string.Join(",", row1SecondValues));

                // --- ROW 2: Dictionary Keys ---
                var row2Keys = new List<string>();
                foreach (var kvp in csvValues)
                {
                    row2Keys.Add(EscapeCsvField(kvp.Key));
                }
                writer.WriteLine(string.Join(",", row2Keys));

                // --- ROW 3: First element of the array (Index 0) ---
                var row3FirstValues = new List<string>();
                foreach (var kvp in csvValues)
                {
                    string val = (kvp.Value != null && kvp.Value.Length > 0) ? kvp.Value[0] : string.Empty;
                    row3FirstValues.Add(EscapeCsvField(val));
                }
                writer.WriteLine(string.Join(",", row3FirstValues));
            }
        }
        else
        {
            File.WriteAllBytes(filename, flatSequence);
        }
    }

    public static string EscapeCsvField(string field)
    {
        if (string.IsNullOrEmpty(field)) return string.Empty;

        // If field contains commas, quotes, or newlines, wrap it in double quotes
        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
        {
            // Duplicate any existing internal double quotes to escape them
            return $"\"{field.Replace("\"", "\"\"")}\"";
        }

        return field;
    }
}

