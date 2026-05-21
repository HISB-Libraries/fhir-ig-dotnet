using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public class VdorFirearm
{
    readonly Observation observation;

    internal VdorFirearm(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = VdorWeapons.Create();
        observation.VdorWeapons().RemoveProfile();
        observation.Code = VdorCustomCs.Firearm;

        observation.VdorFirearm().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-firearm";

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
            Extension ext = this.observation.GetExtension("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-firearm-stolen-extension");
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
                Extension ext = new("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-firearm-stolen-extension", value);
                this.observation.Extension.AddOrUpdateExtension(ext);
            }
        }
    }

    public CodeableConcept? FirearmStoredLoaded
    {
        get
        {
            Extension ext = this.observation.GetExtension("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-firearm-stored-loaded-extension");
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
                Extension ext = new("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-firearm-stored-loaded-extension", value);
                this.observation.Extension.AddOrUpdateExtension(ext);
            }
        }
    }

    public CodeableConcept? FirearmStoredLocked
    {
        get
        {
            Extension ext = this.observation.GetExtension("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-firearm-stored-locked-extension");
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
                Extension ext = new("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-firearm-stored-locked-extension", value);
                this.observation.Extension.AddOrUpdateExtension(ext);
            }
        }
    }

    public string? FirearmGunAccessNarrative
    {
        get
        {
            Extension ext = this.observation.GetExtension("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-firearm-gun-access-narrative-extension");
            if (ext == null)
            {
                return null;
            }

            return (ext.Value as FhirString)?.Value;
        }
        set
        {
            if (value != null)
            {
                Extension ext = new("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-firearm-gun-access-narrative-extension", new FhirString(value));
                this.observation.Extension.AddOrUpdateExtension(ext);
            }
        }
    }

    public (CodeableConcept?, string?, Resource?) FireamrOwner
    {
        get
        {
            CodeableConcept? firearmOwnerCode = null;
            FhirString? firearmOwnerNarrative = null;
            Resource? firearmOwnerResource = null;

            Extension ownerExt = this.observation.GetExtension("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-firearm-owner-extension");
            foreach (Extension ext in ownerExt.Extension)
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
                    if (ext.Value != null && ext.Value is ResourceReference reference)
                    {
                        if (reference != null) 
                        {
                            Record.GetResources().TryGetValue(reference.Reference, out Resource? ownerResource);
                            firearmOwnerResource = ownerResource;
                        }
                    }
                }
            }

            return (firearmOwnerCode, firearmOwnerNarrative?.Value, firearmOwnerResource);
        }
        set
        {
            Extension ext = new()
            {
                Url = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-firearm-owner-extension"
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
                Record.GetResources()[value.Item3.AsReference().Reference] = value.Item3;
                ext.AddExtension("reference", value.Item3.AsReference());
            }

            this.observation.Extension.AddOrUpdateExtension(ext);
        }
    }

    public string? SerialNumber
    {
        get
        {
            Extension ext = this.observation.GetExtension("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-firearm-serial-number");
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
                Extension ext = new("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-firearm-serial-number", identifierValue);
                this.observation.Extension.AddOrUpdateExtension(ext);
            }
        }
    }

    public CodeableConcept? FirearmType
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(VdorCustomCs.FirearmType.Coding[0].System, VdorCustomCs.FirearmType.Coding[0].Code);
            return component?.Value as CodeableConcept;
        }

        set
        {
            Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(VdorCustomCs.FirearmType.Coding[0].System, VdorCustomCs.FirearmType.Coding[0].Code, VdorCustomCs.FirearmType.Coding[0].Display);
            component.Value = value;
        }
    }

    public DataType? FirearmMake
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(VdorCustomCs.FirearmMake.Coding[0].System, VdorCustomCs.FirearmMake.Coding[0].Code);
            if (component?.Value is CodeableConcept)
                return component?.Value as CodeableConcept;
            else
                return component?.Value as FhirString;
        }

        set
        {
            Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(VdorCustomCs.FirearmMake.Coding[0].System, VdorCustomCs.FirearmMake.Coding[0].Code, VdorCustomCs.FirearmMake.Coding[0].Display);
            component.Value = value;
        }
    }

    public string? FirearmModel
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(VdorCustomCs.FirearmModel.Coding[0].System, VdorCustomCs.FirearmModel.Coding[0].Code);
            return component?.Value.ToString();
        }

        set
        {
            Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(VdorCustomCs.FirearmModel.Coding[0].System, VdorCustomCs.FirearmModel.Coding[0].Code, VdorCustomCs.FirearmModel.Coding[0].Display);
            component.Value = new FhirString(value);
        }
    }

    public CodeableConcept? FirearmCaliber
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(VdorCustomCs.FirearmCaliber.Coding[0].System, VdorCustomCs.FirearmCaliber.Coding[0].Code);
            return component?.Value as CodeableConcept;
        }

        set
        {
            if (NvdrsFirearmCaliberVs.FirearmCaliber556.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber6.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber635.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber65.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber7.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber735.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber75.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber762.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber763.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber765.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber8.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber9.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber10.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber11.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber17.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber22.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber221.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber222.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber223.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber243.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber25.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber250.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber256.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber257.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber264.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber270.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber280.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber30.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber300.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber303.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber308.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber32.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber338.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber35.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber351.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber357.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber36.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber375.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber38.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber380.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber40.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber401.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber405.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber41.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber44.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber444.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber455.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber458.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber460.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber50.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber54.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber58.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber60.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber1000.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber1001.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber1002.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber1003.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber6666.Matches(value)
                || NvdrsFirearmCaliberVs.FirearmCaliber8888.Matches(value)
                || NvdrsFirearmCaliberVs.Unknown.Matches(value))
            {
                Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(VdorCustomCs.FirearmCaliber.Coding[0].System, VdorCustomCs.FirearmCaliber.Coding[0].Code, VdorCustomCs.FirearmCaliber.Coding[0].Display);
                component.Value = value;
            } 
            else
            {
                throw new ArgumentException("Value must be one of the value in the value set, http://hl7.org/fhir/us/vdor/ValueSet/nvdrs-firearm-caliber-vs");
            }
        }
    }

    public CodeableConcept? FirearmGauge
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(VdorCustomCs.FirearmGauge.Coding[0].System, VdorCustomCs.FirearmGauge.Coding[0].Code);
            return component?.Value as CodeableConcept;
        }

        set
        {
            if (NvdrsFirearmGaugeVs.FirearmGauge10.Matches(value)
                || NvdrsFirearmGaugeVs.FirearmGauge12.Matches(value)
                || NvdrsFirearmGaugeVs.FirearmGauge16.Matches(value)
                || NvdrsFirearmGaugeVs.FirearmGauge20.Matches(value)
                || NvdrsFirearmGaugeVs.FirearmGauge28.Matches(value)
                || NvdrsFirearmGaugeVs.FirearmGauge410.Matches(value)
                || NvdrsFirearmGaugeVs.FirearmGauge666.Matches(value)
                || NvdrsFirearmGaugeVs.FirearmGauge888.Matches(value)
                || NvdrsFirearmGaugeVs.Unknown.Matches(value))
            {
                Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(VdorCustomCs.FirearmGauge.Coding[0].System, VdorCustomCs.FirearmGauge.Coding[0].Code, VdorCustomCs.FirearmGauge.Coding[0].Display);
                component.Value = value;
            }
            else
            {
                throw new ArgumentException("Value must be one of the value in the value set, http://hl7.org/fhir/us/vdor/ValueSet/nvdrs-firearm-gauge-vs");
            }
        }
    }
}
