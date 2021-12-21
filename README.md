# cbs-ig-dotnet
A .NET Library for Case Based Surveillance FHIR IG \
IG Docs: http://cbsig.chai.gatech.edu/ \
**Brian Ritchie, GTRI (@dotnetpowered)**

Provides shortcuts for working with the CBS profiles built on top of standard .NET FHIR classes (https://github.com/FirelyTeam/firely-net-sdk)

## Example code

#### Travel History Profile
```
    using GaTech.Chai.Cbs.CbsTravelHistoryProfile;

    var travelHistory = CbsTravelHistory.Create();
    travelHistory.Status = ObservationStatus.Final;
    travelHistory.CbsTravelHistory().ProgramSpecificTimeWindow.RelativeTo =
        TimeWindowRelativeToValue.ConditionOnsetDatePeriodStart;
    travelHistory.CbsTravelHistory().ProgramSpecificTimeWindow.TimeWindow = new Quantity(1, "day");
    travelHistory.CbsTravelHistory().ProgramSpecificTimeWindow.RelativeReference = patient.AsReference();
    travelHistory.CbsTravelHistory().TravelHistoryAddress.Address = new Address() { City = "Dallas", State = "TX", Country = "USA" };
    travelHistory.CbsTravelHistory().TravelHistoryAddress.Location = CbsTravelHistory.GeographicalLocation.Encode("48", "Texas");
    travelHistory.CbsTravelHistory().TravelHistoryAddress.TimeSpent = FhirDateTime.Now();
```

#### Specimen Profile
```
    using GaTech.Chai.Cbs.CbsSpecimenProfile;

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
```
