using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using static Hl7.Fhir.Model.Composition;

namespace GaTech.Chai.Vdor;

public class VdorComposition
{

    readonly Composition composition;

    internal VdorComposition(Composition composition)
    {
        this.composition = composition;
    }

    public static Composition Create(
        Resource subjectAsResource,
        Resource? authorAsResource,
        Code? authorAbsentReason,
        CodeableConcept? type,
        FhirDateTime? date = null,
        CompositionStatus status = CompositionStatus.Final,
        string title = "VDOR Document")
    {
        if (subjectAsResource == null)
        {
            throw new Exception("subject resource is required for VDOR Composition");
        }

        if (authorAsResource == null)
        {
            if (authorAbsentReason == null)
            {
                throw new Exception("If author is null, then absent reason must be provided");
            }
        }
        if (date == null)
        {
            date = FhirDateTime.Now();
        }

        type ??= NvdrsDocTypesVs.CMEReport;

        Composition composition = new()
        {
            Type = type,
            Status = status,
            Date = date.ToString(),
            Title = title,
        };

        composition.VdorComposition().SubjectAsResource = (Patient)subjectAsResource;
        composition.VdorComposition().AddProfile();

        composition.VdorComposition().SetAuthor(authorAsResource, authorAbsentReason);
        return composition;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-composition";

    /// <summary>
    /// Set profile for the CompositionNVDRSProfile
    /// </summary>
    public void AddProfile()
    {
        composition.AddProfile(ProfileUrl);
    }

    /// <summary>
    /// Clear profile for the CompositionNVDRSProfile
    /// </summary>
    public void RemoveProfile()
    {
        composition.RemoveProfile(ProfileUrl);
    }

    /// <summary>
    /// Setting subject from resource and save in Record for future use.
    /// </summary>
    public Patient? SubjectAsResource
    {
        get
        {
            Record.GetResources().TryGetValue(this.composition.Subject.Reference, out Resource? value);
            return value as Patient;
        }
        set
        {
            this.composition.Subject = value.AsReference();
            Record.GetResources()[value.AsReference().Reference] = value;
        }
    }

    /// <summary>
    /// Set author or absent reason
    /// </summary>
    /// <param name="practitioner"></param>
    /// <param name="code"></param>
    public void SetAuthor(Resource? author, Code? code)
    {
        if (author == null)
        {
            ResourceReference authorReference = new();
            authorReference.AddDataAbsentReason(code);
            this.composition.Author = new List<ResourceReference> { authorReference };
        }
        else
        {
            if (this.composition.Author.Count > 0)
            {
                this.composition.Author.Clear();
            }
            this.composition.Author = new List<ResourceReference> { author.AsReference() };

            Record.GetResources()[author.AsReference().Reference] = author;
        }
    }

    /// <summary>
    /// NVDRS meta extensions
    /// </summary>
    public bool ForceNewRecord
    {
        get
        {
            Extension ext = this.composition.GetExtension("http://hl7.org/fhir/us/vdor/StructureDefinition/nvdrs-force-new-record-extension");
            if (ext == null || ext.Value is not FhirBoolean force || force.Value == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        set
        {
            Extension ext = new()
            {
                Url = "http://hl7.org/fhir/us/vdor/StructureDefinition/nvdrs-force-new-record-extension",
                Value = new FhirBoolean(value)
            };
            this.composition.Extension.AddOrUpdateExtension(ext);
        }
    }

    public bool OverwriteConflicts
    {
        get
        {
            Extension ext = this.composition.GetExtension("http://hl7.org/fhir/us/vdor/StructureDefinition/nvdrs-overwrite-conflicts-extension");
            if (ext == null || ext.Value is not FhirBoolean force || force.Value == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        set
        {
            Extension ext = new()
            {
                Url = "http://hl7.org/fhir/us/vdor/StructureDefinition/nvdrs-overwrite-conflicts-extension",
                Value = new FhirBoolean(value)
            };
            this.composition.Extension.AddOrUpdateExtension(ext);
        }
    }

    public Identifier? GetAdditionalIdentifier(string system)
    {
        IEnumerable<Extension> exts = this.composition.GetExtensions("http://hl7.org/fhir/us/vdor/StructureDefinition/identifier-extension");
        foreach (Extension ext in exts)
        {
            Identifier? id = ext.Value as Identifier;
            if (id != null)
            {
                if (id.System == system)
                {
                    return id;
                }
            }
        }

        return null;
    }

    public void AddAdditionalIdentifier(Identifier newId)
    {
        IEnumerable<Extension> exts = this.composition.GetExtensions("http://hl7.org/fhir/us/vdor/StructureDefinition/identifier-extension");
        foreach (Extension ext in exts)
        {
            Identifier? id = ext.Value as Identifier;
            if (id != null)
            {
                if (newId.System == id.System)
                {
                    id.Value = newId.Value;
                    return;
                }
            }
        }

        Extension newExt = new()
        {
            Url = "http://hl7.org/fhir/us/vdor/StructureDefinition/identifier-extension",
            Value = newId
        };
        this.composition.Extension.AddOrUpdateExtension(newExt);
    }

    public Date? IncidentYear
    {
        get
        {
            Extension ext = this.composition.GetExtension("http://hl7.org/fhir/us/vdor/StructureDefinition/nvdrs-incident-year-extension");
            if (ext != null)
            {
                return ext.Value as Date;
            }

            return null;
        }
        set
        {
            Extension ext = new()
            {
                Url = "http://hl7.org/fhir/us/vdor/StructureDefinition/nvdrs-incident-year-extension",
                Value = value
            };
            this.composition.Extension.AddOrUpdateExtension(ext);
        }
    }

    public string? IncidentNumber
    {
        get
        {
            this.composition.TryGetIdentifier(VdorCustomUris.incidentnumberIdentifierUrl, out Identifier? identifier);
            if (identifier == null)
            {
                return null;
            }
            else
            {
                return identifier.Value;
            }
        }
        set
        {
            if (value != null)
            {
                this.composition.TryGetIdentifier("urn:vdrs:nvdrs:incidentnumber", out Identifier? identifer);
                if (identifer == null)
                {
                    this.composition.Identifier = new Identifier("urn:vdrs:nvdrs:incidentnumber", value);
                }
                else
                {
                    identifer.Value = value;
                }
            }
        }
    }

    private (List<Resource>, Narrative, CodeableConcept) GetSectionAndEntry(string code, CodeableConcept mdiCodeSystem)
    {
        SectionComponent sectionComponent = GetOrAddSection(code, mdiCodeSystem.Coding[0].Display);
        List<Resource> valueResource = [];
        foreach (ResourceReference reference in sectionComponent.Entry)
        {
            if (Record.GetResources().TryGetValue(reference.Reference, out Resource? resource))
            {
                valueResource.Add(resource);
            }
            else
            {
                Console.WriteLine(reference.Reference + " is not found from resource dictionary");
            }
        }

        return (valueResource, sectionComponent.Text, sectionComponent.EmptyReason);
    }

    /// <summary>
    /// setSectionAndEntry: Helper function that sets section and entry or list empty reason if appropriate
    /// </summary>
    /// <param name="code"></param>
    /// <param name="mdiCodeSystem"></param>
    /// <param name="value"></param>
    private void SetSectionAndEntry(string code, CodeableConcept mdiCodeSystem, (List<Resource>, Narrative?, CodeableConcept?) value)
    {
        List<ResourceReference> references = [];

        if (value.Item1 != null)
        {
            foreach (Resource valueResource in value.Item1)
            {
                references.Add(valueResource.AsReference());
                Record.GetResources()[valueResource.AsReference().Reference] = valueResource;
            }
        }

        SectionComponent sectionComponent = new() { Code = mdiCodeSystem, Entry = references };
        if (value.Item2 != null)
        {
            sectionComponent.Text = value.Item2;
        }

        if (value.Item1 == null || value.Item1.Count == 0)
        {
            sectionComponent.EmptyReason = value.Item3;
        }

        AddOrUpdateSection(code, mdiCodeSystem.Coding[0].Display, sectionComponent);
    }
    
    public List<Resource> GetSectionByCode(CodeableConcept codeable)
    {
        List<Resource> resources = new();

        Composition.SectionComponent section = this.composition.Section.GetSection(codeable.Coding[0].System, codeable.Coding[0].Code);
        if (section != null)
        {
            List<ResourceReference> entry = section.Entry;
            foreach (ResourceReference reference in entry)
            {
                Record.GetResources().TryGetValue(reference.Reference, out Resource? value);
                if (value != null)
                {
                    resources.Add(value);
                }
            }
        }

        return resources;
    }

    public List<Resource> Demographics
    {
        get
        {
            List<Resource> resources = GetSectionByCode(VdorCustomCs.Demographics);
            return resources;
        }
        set
        {
            SetSectionAndEntry(VdorCustomCs.Demographics.Coding[0].Code, VdorCustomCs.Demographics, (value, null, null));
        }
    }

    public List<Resource> InjuryAndDeath
    {
        get
        {
            List<Resource> resources = GetSectionByCode(VdorCustomCs.InjuryAndDeath);
            return resources;
        }
        set
        {
            SetSectionAndEntry(VdorCustomCs.InjuryAndDeath.Coding[0].Code, VdorCustomCs.InjuryAndDeath, (value, null, null));
        }
    }

    public List<Resource> Toxicology
    {
        get
        {
            List<Resource> resources = GetSectionByCode(VdorCustomCs.Toxicology);
            return resources;
        }
        set
        {
            SetSectionAndEntry(VdorCustomCs.Toxicology.Coding[0].Code, VdorCustomCs.Toxicology, (value, null, null));
        }
    }

    public List<Resource> Circumstances
    {
        get
        {
            List<Resource> resources = GetSectionByCode(VdorCustomCs.Circumstances);
            return resources;
        }
        set
        {
            SetSectionAndEntry(VdorCustomCs.Circumstances.Coding[0].Code, VdorCustomCs.Circumstances, (value, null, null));
        }
    }

    public List<Resource> Weapons
    {
        get
        {
            List<Resource> resources = GetSectionByCode(VdorCustomCs.Weapons);
            return resources;
        }
        set
        {
            SetSectionAndEntry(VdorCustomCs.Weapons.Coding[0].Code, VdorCustomCs.Weapons, (value, null, null));
        }
    }

    public List<Resource> Suspects
    {
        get
        {
            List<Resource> resources = GetSectionByCode(VdorCustomCs.Suspects);
            return resources;
        }
        set
        {
            SetSectionAndEntry(VdorCustomCs.Suspects.Coding[0].Code, VdorCustomCs.Suspects, (value, null, null));
        }
    }

    public List<Resource> Overdose
    {
        get
        {
            List<Resource> resources = GetSectionByCode(VdorCustomCs.Overdose);
            return resources;
        }
        set
        {
            SetSectionAndEntry(VdorCustomCs.Overdose.Coding[0].Code, VdorCustomCs.Overdose, (value, null, null));
        }
    }

    public void AddSectionEntryByCode(CodeableConcept codeable, List<Resource> resources)
    {
        Composition.SectionComponent section = this.composition.Section.GetOrAddSection(codeable.Coding[0].System, codeable.Coding[0].Code, codeable.Coding[0].Display, codeable.Coding[0].Display);
        section.Title = codeable.Coding[0].Display;
        foreach (Resource resource in resources)
        {
            section.Entry.Add(resource.AsReference());
            Record.GetResources()[resource.AsReference().Reference] = resource;
        }
    }

    protected SectionComponent GetOrAddSection(Coding coding)
    {
        return composition.Section.GetOrAddSection(coding.System, coding.Code,
                coding.Display, coding.Display);
    }

    protected SectionComponent GetOrAddSection(string code, string display)
    {
        return composition.Section.GetOrAddSection(VdorCustomCs.officialUrl, code, display, display);
    }

    protected SectionComponent GetOrAddSection(string code, string display, string title)
    {
        return composition.Section.GetOrAddSection(VdorCustomCs.officialUrl, code, title, display);
    }

    protected void AddOrUpdateSection(string code, string display, Composition.SectionComponent section)
    {
        string system = VdorCustomCs.officialUrl;
        if (section.Code != null)
        {
            if (section.Code.Coding.Count != 0)
            {
                system = section.Code.Coding[0].System;
            }
        }

        composition.Section.AddOrUpdateSection(system, code, display, display, section);
    }

    protected void AddOrUpdateSection(string code, string display, string title, Composition.SectionComponent section)
    {
        string system = VdorCustomCs.officialUrl;
        if (section.Code != null)
        {
            if (section.Code.Coding.Count != 0)
            {
                system = section.Code.Coding[0].System;
            }
        }

        composition.Section.AddOrUpdateSection(system, code, title, display, section);
    }    
}
