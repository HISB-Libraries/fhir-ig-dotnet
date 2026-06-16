using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorToxicologySpecimenExtensions
{
    public static VdorToxicologySpecimen VdorToxicologySpecimen(this Specimen specimen)
    {
        return new VdorToxicologySpecimen(specimen);
    }
}