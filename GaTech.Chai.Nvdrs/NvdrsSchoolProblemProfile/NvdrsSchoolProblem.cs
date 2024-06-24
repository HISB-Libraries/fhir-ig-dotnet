using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.Share.Common;
using GaTech.Chai.Nvdrs.Common;

namespace GaTech.Chai.Nvdrs;

public class NvdrsSchoolProblem
{
    readonly Observation observation;

    internal NvdrsSchoolProblem(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new()
        {
            Code = NvdrsCustomCs.SchoolProblem
        };

        observation.NvdrsSchoolProblem().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-school-problem";

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

}
