using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsRandomViolenceExtensions
{
    public static NvdrsRandomViolence NvdrsRandomViolence(this Observation observation)
    {
        return new NvdrsRandomViolence(observation);
    }
}
