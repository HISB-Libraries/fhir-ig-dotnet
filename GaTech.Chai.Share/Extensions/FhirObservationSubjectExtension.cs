using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Share;

public static class FhirObservationSubjectExtension
{
    public static void FhirSubject(this Observation observation, Patient patient)
    {
        ResourceReference subjectReference = patient.AsReference();
        observation.Subject = subjectReference;
        
        Record.GetResources()[patient.AsReference().Reference] = patient;
    }
}
