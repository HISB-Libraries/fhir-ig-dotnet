using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using Hl7.Fhir.Utility;

namespace GaTech.Chai.Vdor;

public class VdorWeaponType
{
    readonly Observation observation;

    internal VdorWeaponType(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new()
        {
            Code = VdorCustomCs.WeaponType
        };
        observation.VdorWeaponType().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-weapon-type";

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

    public Resource? FocusOnFirearm
    {
        get
        {
            if (!this.observation.Focus.IsNullOrEmpty())
            {
                Record.GetResources().TryGetValue(this.observation.Focus[0].Reference, out Resource? value);
                return value;
            }

            return null;
        }

        set
        {
            this.observation.Focus.Add(value.AsReference());
            Record.GetResources()[value.AsReference().Reference] = value;
        }
    }

    public CodeableConcept? ValueWeaponType
    {
        get { return this.observation.Value as CodeableConcept; }
        set 
        {
            if (NvdrsWeaponTypeVs.Firearm.Matches(value) 
                || NvdrsWeaponTypeVs.NonPowderGun.Matches(value) 
                || NvdrsWeaponTypeVs.SharpInstrument.Matches(value) 
                || NvdrsWeaponTypeVs.BluntInstrument.Matches(value) 
                || NvdrsWeaponTypeVs.Poisoning.Matches(value)
                || NvdrsWeaponTypeVs.HangingStrangulationSuffocation.Matches(value)
                || NvdrsWeaponTypeVs.PersonalWeapons.Matches(value)
                || NvdrsWeaponTypeVs.Fall.Matches(value)
                || NvdrsWeaponTypeVs.Explosive.Matches(value)
                || NvdrsWeaponTypeVs.Drowning.Matches(value)
                || NvdrsWeaponTypeVs.FireOrBurns.Matches(value) 
                || NvdrsWeaponTypeVs.Shaking.Matches(value) 
                || NvdrsWeaponTypeVs.MotorVehicle.Matches(value) 
                || NvdrsWeaponTypeVs.OtherTransport.Matches(value) 
                || NvdrsWeaponTypeVs.IntentionalNeglect.Matches(value) 
                || NvdrsWeaponTypeVs.BiologicalWeapons.Matches(value) 
                || NvdrsWeaponTypeVs.Other.Matches(value)
                || NvdrsWeaponTypeVs.Unknown.Matches(value))
            {
                this.observation.Value = value; 
            }
            else
            {
                throw new ArgumentException($"Value must be one of the valueset in http://hl7.org/fhir/us/vdor/ValueSet/nvdrs-weapon-type-vs");
            }
            this.observation.Value = value; 
        }
    }
}
