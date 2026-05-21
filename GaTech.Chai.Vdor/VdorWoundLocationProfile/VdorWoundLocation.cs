using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public class VdorWoundLocation
{
    readonly Observation observation;

    internal VdorWoundLocation(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = VdorInjuryAndDeath.Create();
        observation.VdorInjuryAndDeath().RemoveProfile();
        observation.VdorWoundLocation().AddProfile();

        return observation;
    }

    public static Observation Create(CodeableConcept code)
    {
        if (VdorWoundLocationVs.WoundToHead.Matches(code)
            || VdorWoundLocationVs.WoundToFace.Matches(code)
            || VdorWoundLocationVs.WoundToNeck.Matches(code)
            || VdorWoundLocationVs.WoundToUpperExtremity.Matches(code)
            || VdorWoundLocationVs.WoundToSpine.Matches(code)
            || VdorWoundLocationVs.WoundToThorax.Matches(code)
            || VdorWoundLocationVs.WoundToAbdomen.Matches(code)
            || VdorWoundLocationVs.WoundToLowerExtremity.Matches(code)) {
            Observation observation = VdorInjuryAndDeath.Create();
            observation.VdorInjuryAndDeath().RemoveProfile();
            observation.VdorWoundLocation().AddProfile();
            observation.Code = code;

            return observation;
        } else
        {
            throw new ArgumentException("Code, " + code + " is not valid for VDOR Wound Location");
        }
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-wound-location";

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

    public CodeableConcept? ValueOfWoundLocation
    {
        get { return this.observation.Value as CodeableConcept; }
        set
        {
            if (NvdrsWoundLocationValuesVs.AbsentNotWounded.Matches(value)
                || NvdrsWoundLocationValuesVs.PresentWounded.Matches(value)
                || NvdrsWoundLocationValuesVs.NotApplicable.Matches(value)
                || NvdrsWoundLocationValuesVs.Unknown.Matches(value))
            {
                this.observation.Value = value;
            }
            else
            {
                throw new ArgumentException("Value, " + value + " is not valid for NVDRS Wound Location Value");
            }
        }
    }   
}
