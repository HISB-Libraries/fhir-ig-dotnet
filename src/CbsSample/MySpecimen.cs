using System;
using GaTech.Chai.Cbs.CbsSpecimenProfile;
using GaTech.Chai.FhirIg.Extensions;
using Hl7.Fhir.Model;

namespace CbsProfileInitialization
{
    public class MySpecimen
    {
        public MySpecimen()
        {
        }

        public static Specimen Create(Patient patient)
        {
            var specimen = CbsSpecimen.Create();
            specimen.CbsSpecimen().SpecimenRole = CbsSpecimen.Roles.BlindSample;
            specimen.CbsSpecimen().FillerAssignedId = new Identifier() { Value = "IDR908765140" };
            specimen.CbsSpecimen().PlacerAssignedId = new Identifier() { Value = "198374-9" };
            specimen.Type = CbsSpecimen.Types.Encode("258497007", "Abscess swab (specimen)");
            specimen.Subject = patient.AsReference();
            specimen.Collection = new Specimen.CollectionComponent()
            {
                Collected = FhirDateTime.Now(),
                Quantity = new Quantity(1, "ml"),
                BodySite = CbsSpecimen.BodySites.Encode("64700008", "7 nm filaments(cell structure)")
            };
            return specimen;
        }
    }
}
