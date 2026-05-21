using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorOdRecentEmergencyDepartmentVisitExtensions
{
    public static VdorOdRecentEmergencyDepartmentVisit VdorOdRecentEmergencyDepartmentVisit(this Observation observation)
    {
        return new VdorOdRecentEmergencyDepartmentVisit(observation);
    }
}
