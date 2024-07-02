using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Nvdrs;

public class NvdrsComposition
{

    readonly Composition composition;

    internal NvdrsComposition(Composition composition)
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
        string title = "NVDRS Document")
    {
        if (subjectAsResource == null)
        {
            throw new Exception("subject resource is required for NVDRS Composition");
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

        composition.NvdrsComposition().SubjectAsResource = (Patient)subjectAsResource;
        composition.NvdrsComposition().AddProfile();

        composition.NvdrsComposition().SetAuthor(authorAsResource, authorAbsentReason);
        return composition;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-composition";

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
            Extension ext = this.composition.GetExtension("http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-force-new-record-extension");
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
                Url = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-force-new-record-extension",
                Value = new FhirBoolean(value)
            };
            this.composition.Extension.AddOrUpdateExtension(ext);
        }
    }

    public bool OverwriteConflicts
    {
        get
        {
            Extension ext = this.composition.GetExtension("http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-overwrite-conflicts-extension");
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
                Url = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-overwrite-conflicts-extension",
                Value = new FhirBoolean(value)
            };
            this.composition.Extension.AddOrUpdateExtension(ext);
        }
    }

    public Identifier? GetAdditionalIdentifier(string system)
    {
        IEnumerable<Extension> exts = this.composition.GetExtensions("http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/identifier-extension");
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
        IEnumerable<Extension> exts = this.composition.GetExtensions("http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/identifier-extension");
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
            Url = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/identifier-extension",
            Value = newId
        };
        this.composition.Extension.AddOrUpdateExtension(newExt);
    }

    public Date? IncidentYear
    {
        get
        {
            Extension ext = this.composition.GetExtension("http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-incident-year-extension");
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
                Url = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-incident-year-extension",
                Value = value
            };
            this.composition.Extension.AddOrUpdateExtension(ext);
        }
    }

    public string? IncidentNumber
    {
        get
        {
            this.composition.TryGetIdentifier(NvdrsCustomUris.incidentnumberIdentifierUrl, out Identifier? identifier);
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
}
