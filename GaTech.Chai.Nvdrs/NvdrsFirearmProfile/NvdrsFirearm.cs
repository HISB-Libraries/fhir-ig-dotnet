using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.Nvdrs.Common;

namespace GaTech.Chai.Nvdrs;

public class NvdrsFirearm
{
    readonly Observation observation;

    internal NvdrsFirearm(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new()
        {
            Code = NvdrsCustomCs.Firearm
        };

        observation.NvdrsFirearm().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-firearm";

    /// <summary>
    /// Set profile for the ObservationDeathDateProfile
    /// </summary>
    public void AddProfile()
    {
        this.observation.AddProfile(ProfileUrl);
    }

    /// <summary>
    /// Clear profile for the ObservationDeathDateProfile
    /// </summary>
    public void RemoveProfile()
    {
        this.observation.RemoveProfile(ProfileUrl);
    }

    public CodeableConcept? FirearmStolen
    {
        get
        {
            Extension ext = this.observation.GetExtension("http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-firearm-stolen-extension");
            if (ext == null || ext.Value is not CodeableConcept)
            {
                return null;
            }

            return ext.Value as CodeableConcept;
        }
        set
        {
            if (value != null)
            {
                Extension ext = new("http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-firearm-stolen-extension", value);
                this.observation.Extension.AddOrUpdateExtension(ext);
            }
        }
    }

    public CodeableConcept? StoredLoaded
    {
        get
        {
            Extension ext = this.observation.GetExtension("http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-firearm-stored-loaded-extension");
            if (ext == null || ext.Value is not CodeableConcept)
            {
                return null;
            }

            return ext.Value as CodeableConcept;
        }
        set
        {
            if (value != null)
            {
                Extension ext = new("http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-gun-stored-loaded-extension", value);
                this.observation.Extension.AddOrUpdateExtension(ext);
            }
        }
    }

    public CodeableConcept? StoredLocked
    {
        get
        {
            Extension ext = this.observation.GetExtension("http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-firearm-stored-locked-extension");
            if (ext == null || ext.Value is not CodeableConcept)
            {
                return null;
            }

            return ext.Value as CodeableConcept;
        }
        set
        {
            if (value != null)
            {
                Extension ext = new("http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-gun-stored-locked-extension", value);
                this.observation.Extension.AddOrUpdateExtension(ext);
            }
        }
    }

    public (CodeableConcept?, string?, ResourceReference?) FireamrOwner
    {
        get
        {
            CodeableConcept? firearmOwnerCode = null;
            FhirString? firearmOwnerNarrative = null;
            ResourceReference? firearmOwnerReference = null;

            IEnumerable<Extension> exts = this.observation.GetExtensions("http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-firearm-owner-extension");
            foreach (Extension ext in exts)
            {
                if ("code".Equals(ext.Url))
                {
                    firearmOwnerCode = ext.Value as CodeableConcept;
                }
                else if ("narrative".Equals(ext.Url))
                {
                    firearmOwnerNarrative = ext.Value as FhirString;
                }
                else if ("reference".Equals(ext.Url))
                {
                    firearmOwnerReference = ext.Value as ResourceReference;
                }
            }

            return (firearmOwnerCode, firearmOwnerNarrative?.Value, firearmOwnerReference);
        }
        set
        {
            Extension ext = new()
            {
                Url = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-firearm-owner-extension"
            };
            if (value.Item1 != null)
            {
                ext.AddExtension("code", value.Item1);
            }

            if (value.Item2 != null)
            {
                ext.AddExtension("narrative", new FhirString(value.Item2));
            }

            if (value.Item3 != null)
            {
                ext.AddExtension("reference", value.Item3);
            }
        }
    }

    public string? SerialNumber
    {
        get
        {
            Extension ext = this.observation.GetExtension("http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/firearm-serial-number");
            if (ext == null || ext.Value is not Identifier)
            {
                return null;
            }


            return ((Identifier)ext.Value).Value;
        }
        set
        {
            if (value != null)
            {
                Identifier identifierValue = new("urn:vdrs:ncic:serialnumber", value);
                Extension ext = new("http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/firearm-serial-number", identifierValue);
                this.observation.Extension.AddOrUpdateExtension(ext);
            }
        }
    }

    public CodeableConcept? FirearmType
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(NvdrsCustomCs.FirearmType.Coding[0].System, NvdrsCustomCs.FirearmType.Coding[0].Code);
            return component?.Value as CodeableConcept;
        }

        set
        {
            Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(NvdrsCustomCs.FirearmType.Coding[0].System, NvdrsCustomCs.FirearmType.Coding[0].Code, NvdrsCustomCs.FirearmType.Coding[0].Display);
            component.Value = value;
        }
    }

    public DataType? FirearmMake
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(NvdrsCustomCs.FirearmMake.Coding[0].System, NvdrsCustomCs.FirearmMake.Coding[0].Code);
            if (component?.Value is CodeableConcept)
                return component?.Value as CodeableConcept;
            else
                return component?.Value as FhirString;
        }

        set
        {
            Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(NvdrsCustomCs.FirearmMake.Coding[0].System, NvdrsCustomCs.FirearmMake.Coding[0].Code, NvdrsCustomCs.FirearmMake.Coding[0].Display);
            component.Value = value;
        }
    }

    public string? FirearmModel
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(NvdrsCustomCs.FirearmModel.Coding[0].System, NvdrsCustomCs.FirearmModel.Coding[0].Code);
            return component?.Value.ToString();
        }

        set
        {
            Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(NvdrsCustomCs.FirearmModel.Coding[0].System, NvdrsCustomCs.FirearmModel.Coding[0].Code, NvdrsCustomCs.FirearmModel.Coding[0].Display);
            component.Value = new FhirString(value);
        }
    }

    public string? FirearmCaliber
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(NvdrsCustomCs.FirearmCaliber.Coding[0].System, NvdrsCustomCs.FirearmCaliber.Coding[0].Code);
            return component?.Value.ToString();
        }

        set
        {
            Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(NvdrsCustomCs.FirearmCaliber.Coding[0].System, NvdrsCustomCs.FirearmCaliber.Coding[0].Code, NvdrsCustomCs.FirearmCaliber.Coding[0].Display);
            component.Value = new FhirString(value);
        }
    }

    public string? FirearmGauge
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(NvdrsCustomCs.FirearmGauge.Coding[0].System, NvdrsCustomCs.FirearmGauge.Coding[0].Code);
            return component?.Value.ToString();
        }

        set
        {
            Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(NvdrsCustomCs.FirearmGauge.Coding[0].System, NvdrsCustomCs.FirearmGauge.Coding[0].Code, NvdrsCustomCs.FirearmGauge.Coding[0].Display);
            component.Value = new FhirString(value);
        }
    }
}
