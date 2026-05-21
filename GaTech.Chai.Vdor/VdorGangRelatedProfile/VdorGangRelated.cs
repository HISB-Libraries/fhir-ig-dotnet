using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorGangRelated
{
    readonly Observation observation;

    internal VdorGangRelated(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = VdorCircumstances.Create();
        observation.VdorCircumstances().RemoveProfile();
        observation.Code = VdorCustomCs.GangRelated;

        observation.VdorGangRelated().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-gang-related";

    /// <summary>
    /// Set profile for the Nvdrs Current Depressed Mood
    /// </summary>
    public void AddProfile()
    {
        this.observation.AddProfile(ProfileUrl);
    }

    /// <summary>
    /// Clear profile for the Nvdrs Current Depressed Mood
    /// </summary>
    public void RemoveProfile()
    {
        this.observation.RemoveProfile(ProfileUrl);
    }

    public CodeableConcept? ValueOfGangRelated
    {
        get { return this.observation.Value as CodeableConcept; }
        set 
        { 
            if (NvdrsCodingManualCs.NoNotAvailableUnknown.Matches(value) 
                || NvdrsCodingManualCs.YesGangMotivated.Matches(value) 
                || NvdrsCodingManualCs.YesSusGangMemInv.Matches(value) 
                || NvdrsCodingManualCs.YesGangRelNotOthSpec.Matches(value)
                || NvdrsCodingManualCs.OrgCrimeIncMotorcycleGangsMafiaDrugCartels.Matches(value))
            {
                this.observation.Value = value; 
            }
            else
            {
                throw new ArgumentException($"Value must be one of the following: {NvdrsCodingManualCs.NoNotAvailableUnknown.Coding[0].Display}, {NvdrsCodingManualCs.YesGangMotivated.Coding[0].Display}, {NvdrsCodingManualCs.YesSusGangMemInv.Coding[0].Display}, {NvdrsCodingManualCs.YesGangRelNotOthSpec.Coding[0].Display}, {NvdrsCodingManualCs.OrgCrimeIncMotorcycleGangsMafiaDrugCartels.Coding[0].Display}");
            }
        }
    }

}
