using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorOdRecentEmergencyDepartmentVisit
{
    readonly Observation observation;

    internal VdorOdRecentEmergencyDepartmentVisit(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdRecentEmergencyDepartmentVisit().AddProfile();
        observation.Code = VdorCustomCs.RecentEmergencyDepartmentVisitOrUrgentCareVisit;

        return observation;
    }

    public static Observation Create(Patient decedent, CodeableConcept? value)
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdRecentEmergencyDepartmentVisit().AddProfile();
        observation.Code = VdorCustomCs.RecentEmergencyDepartmentVisitOrUrgentCareVisit;

            observation.VdorOdRecentEmergencyDepartmentVisit().SubjectAsResource = decedent;
            observation.VdorOdRecentEmergencyDepartmentVisit().ValueOfRecentEmergencyDepartmentVisit = value;
        
        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-od-recent-emergency-department-visit";

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

    public Patient? SubjectAsResource
    {
        get
        {
            Record.GetResources().TryGetValue(this.observation.Subject.Reference, out Resource? value);
            return value as Patient;
        }
        set
        {
            this.observation.Subject = value.AsReference();
            Record.GetResources()[value.AsReference().Reference] = value;
        }
    }

    public CodeableConcept? ValueOfRecentEmergencyDepartmentVisit
    {
        get => this.observation.Value as CodeableConcept;
        set
        {
            if (VdorRecentEmergencyDepartmentVisitVs.NoEvidenceOfEdOrUrgentCareVisitWithinLastYearBeforeDeath.Matches(value)
            || VdorRecentEmergencyDepartmentVisitVs.EdOrUrgentCareVisitWithinTheLastMonthBeforeDeath.Matches(value)
            || VdorRecentEmergencyDepartmentVisitVs.EdOrUrgentCareVisitBetweenOneAndThreeMonthsBeforeDeath.Matches(value)
            || VdorRecentEmergencyDepartmentVisitVs.EdOrUrgentCareVisitBetweenThreeAndSixMonthsBeforeDeath.Matches(value)
            || VdorRecentEmergencyDepartmentVisitVs.EdOrUrgentCareVisitBetweenSixMonthsAndOneYearBeforeDeath.Matches(value)
            || VdorRecentEmergencyDepartmentVisitVs.RecentEdOrUrgentCareVisitNotedTimingUnknown.Matches(value))
            {
                this.observation.Value = value;
            }
            else
            {
                throw new ArgumentException("Value must be one of the value in the value set, http://hl7.org/fhir/us/vdor/ValueSet/vdor-recent-emergency-department-visit-vs");
            }
        }
    }
}
