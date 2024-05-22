using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs.ObservationFirearm;

public static class ObservationFirearmExtensions
{
    public static ObservationFirearm ObservationFirearm(this Observation observation)
    {
        return new ObservationFirearm(observation);
    }
}
