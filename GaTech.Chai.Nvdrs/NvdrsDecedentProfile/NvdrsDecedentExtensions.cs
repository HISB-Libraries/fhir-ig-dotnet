using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsDecedentExtensions
{
    public static NvdrsDecedent NvdrsDecedent(this Patient patient)
    {
        return new NvdrsDecedent(patient);
    }

}
