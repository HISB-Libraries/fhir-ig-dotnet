using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.Nvdrs.Common;
using GaTech.Chai.Share.Common;
using Hl7.Fhir.Utility;

namespace GaTech.Chai.Nvdrs;

public class ObservationWeaponType
{
    readonly Observation observation;

    internal ObservationWeaponType(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new();

        observation.Code = NvdrsCodeSystem.NvdrsResourceCodes.WeaponType;
        observation.ObservationWeaponType().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-weapon-type";

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
}
