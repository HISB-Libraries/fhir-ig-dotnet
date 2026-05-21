using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorDecedentExtensions
{
    public static VdorDecedent VdorDecedent(this Patient patient)
    {
        return new VdorDecedent(patient);
    }

}
