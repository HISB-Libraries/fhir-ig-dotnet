using System;
using GaTech.Chai.Share;
using GaTech.Chai.UsCbs.LabObservationProfile;
using Hl7.Fhir.Model;

namespace CbsProfileInitialization
{
    public class HaicalLabObservation
    {
        public HaicalLabObservation()
        {
        }

        public static Observation Create(Patient patient)
        {
            Observation observation = UsCbsLabObservation.Create();
            observation.Subject = patient.AsReference();
            observation.Code = new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.232", "LAB723", "DNA Sequencing", null);
            observation.Value = new CodeableConcept("http://snomed.info/sct", "10828004", "Positive", null);
            observation.Method = new CodeableConcept(null, "D1D2", "D1/D2", null);

            return observation;
        }
    }
}
