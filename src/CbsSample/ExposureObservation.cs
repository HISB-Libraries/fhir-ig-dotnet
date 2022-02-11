using System;
using GaTech.Chai.Cbs.CbsCaseNotificationPanelProfile;
using GaTech.Chai.Cbs.Extensions;
using Hl7.Fhir.Model;

namespace CbsProfileInitialization
{
    public class ExposureObservation
    {
        public ExposureObservation()
        {
        }

        public static Observation Create(Patient patient, Condition condition, CodeableConcept countryOfExposure, CodeableConcept stateOrProvinceOfExposure, String cityOfExposure, String countyOfExposure)
        {
            var exposure = CbsExposureObservation.Create();
            exposure.CbsExposureObservation().CountryOfExposure = countryOfExposure;
            exposure.CbsExposureObservation().StateOrProvinceOfExposure = stateOrProvinceOfExposure;
            exposure.CbsExposureObservation().CityOfExposure = cityOfExposure;
            exposure.CbsExposureObservation().CountyOfExposure = countyOfExposure;
            exposure.Subject = patient.AsReference();
            exposure.Focus.Add(condition.AsReference());

            return exposure;
        }
    }
}
