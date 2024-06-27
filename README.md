# fhir-ig-dotnet
A .NET Library for the following FHIR Implementation Guides (IG)
* Case Based Surveillance (CBS) FHIR IG | https://cbsig.chai.gatech.edu/
* Medicolegal Death Investigation (MDI) FHIR IG | https://build.fhir.org/ig/HL7/fhir-mdi-ig/
* National Violent Death Reporting System (NVDRS) FHIR IG | https://mortalityreporting.github.io/nvdrs-ig/
* US Public Health (US PH) FHIR IG | https://build.fhir.org/ig/HL7/fhir-us-ph-common-library-ig/
* US Core FHIR IG | https://www.hl7.org/fhir/us/core/
* Occupational Data for Health (ODH) FHIR IG | http://hl7.org/fhir/us/odh/STU1.1/

All profiles built on top of standard .NET FHIR classes (https://github.com/FirelyTeam/firely-net-sdk). Only referenced profiles of US PH, US Core, and ODH by CBS and MDI are implemented. Rest of profiles will be added based on the needs. 

## Authors
**Myung Choi, GTRI (@myungchoi)**<br/>
**Brian Ritchie, GTRI (@dotnetpowered)**

## Development Note
Firely .net FHIR classes are used as a basis for FHIR objects. All profiles are implemented using C# extensions. Invidual profiles can be used to extend the basic FHIR objects. Whenever the profile extensions are used, the profile names are automatically added to the meta section of FHIR resources that are being implemeted. The class extensions that are used create the fixed elements as defined in the IG. However, any fixed values that are not required (with cardinality 0..) will not be created. Instead, the fixed values should be available as a static value or C# property.

Hl7.Fhir.R4 and Hl7.Fhir.Specification.R4 NuGet Packages are required. 

## Distribution
The FHIR IG .net packages are still in the early stage. Once it reaches certain stage, they can be available in the NuGet.org. In the mean time (before they are registered in the NuGet.org), the NuGet packages will be available in the github release page.

## How to use the FHIR IG .net Library
Pleaase refer to the example codes below to see how to use the library. Name of extensions is in most cases from the name of profile. For any specific values or structures defined in the IG, helper methods in either properties or class functions should be available. Please refer to the source code of the profile to get the list of available helpers. 

There are extensions that are applicable to multiple IG profiles. Those are implemented in Gatech.Chai.Share project. Please include this namespace to use those extensions.

First step of using this library is starting from the profile you are trying to use. If Us CBS Patient profile is the one you are trying to implement, then use the static Create() - note that all profiles have a static method called, "Create()". 
```
var patient = UsCbsPatient.Create();

 "meta": {
    "profile": [
      "http://hl7.org/fhir/us/core/StructureDefinition/us-core-patient",
      "http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-patient",
      "http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-patient"
    ]
  },
  
----- 

patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino") };
patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

{
   "extension": [
     {
       "url": "ombCategory",
       "valueCoding": {
         "system": "urn:oid:2.16.840.1.113883.6.238",
         "code": "2186-5",
         "display": "Not Hispanic or Latino"
          }
     },
     {
       "url": "detailed",
       "valueCoding": {
         "system": "urn:oid:2.16.840.1.113883.6.238",
         "code": "2186-5",
         "display": "Not Hispanic or Latino"
       }
     },
     {
       "url": "text",
       "valueString": "Not Hispanic or Latino"
     }
   ],
   "url": "http://hl7.org/fhir/us/core/StructureDefinition/us-core-ethnicity"
},

```
This will create patient resource with all based IGs' profiles. Since US CBS Patient profile is based on US Public Health Patient, and US Public Health Patient is based on US Core, all profile URLs will be added to the Meta section of your patient resource. Also, there are helpers for US Public Health and US Core data elements. Thses helpers will make developers' life easier. Race and ethincity in US Core and birth place and TribalAffiliation in US Public Health are the examples of the helpers.

Another example is US CBS Lab Observation. 
```
Observation observation = UsCbsLabObservation.Create();
```
This will create the US CBS Lab Observation profile, which is based on US Core Lab Result Observation profile. This helper, Create(), will then add necessary profiles and fixed value of Category. 
```
 "meta": {
    "profile": [
      "http://hl7.org/fhir/us/core/StructureDefinition/us-core-observation-lab",
      "http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-lab-observation"
    ]
  },

"category": [
    {
      "coding": [
        {
          "system": "http://terminology.hl7.org/CodeSystem/observation-category",
          "code": "laboratory",
          "display": "Laboratory"
        }
      ]
    }
  ],
  ```

#### US CBS Patient Profile
In this example, UsCbsPatient and UsCorePatient are the C# extensions to Patient class. To start with US CBS Patient, UsCbsPatient.Create() will return Patient object with IG specific intialization(s). 
```
// Patient Profile
var patient = UsCbsPatient.Create();

// Race
patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2106-3", "White");
patient.UsCorePatient().Race.RaceText = "White";

// Ethnicity
patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino") };
patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

// Birth Related
// patient.BirthDateElement = new Date(1965, 5, 2);
patient.UsCorePatient().BirthSex.Extension = new Code("F");

patient.UsPublicHealthPatient().SetBrithDateDataAbsentReason();
patient.UsPublicHealthPatient().BirthPlace = new Address() { Country = "USA" };
patient.UsPublicHealthPatient().GenderIdentity = UsPublicHealthPatient.GenderFemale;
patient.UsPublicHealthPatient().TribalAffiliation.TribeName = UsPublicHealthTribalAffiliation.TribalEntityUS.Encode("91", "Fort Mojave Indian Tribe of Arizona, California");
patient.UsPublicHealthPatient().TribalAffiliation.EnrolledTribeMember = new FhirBoolean(true);
patient.BirthDate = "1974-11-24";
patient.Gender = AdministrativeGender.Female;
patient.Identifier.Add(new Identifier() { Use = Identifier.IdentifierUse.Usual, Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "MR", "Medical Record Number", "Medical Record Number"), System = "http://hospital.smarthealthit.org", Value = "1032702" });
patient.Active = true;
patient.Name.Add(new HumanName() { Family = "Everywoman", Given = new List<string> { "Eve", "L" } });

// Address
var address = new Address() { Use = Address.AddressUse.Home, Line = new List<string> { "5101 Peachtree St NE" }, City = "Atlanta", State = "GA", PostalCode = "30302", Country = "US" };
address.UsCbsAddress().CensusTract = "030500";
patient.Address.Add(address);

// Contact
patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "1-(404)555-1212");
patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "1-(404)555-1212");
patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "1-(404)555-1212"); // duplicate entry demo
patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Work, "mywork@gtri.org");
```
#### JSON or XML Serialization
Firely FHIR library has serialization classes for both JSON and XML. Your FHIR object(s) can be serialized to JSON or XML in the following way.
```
FhirJsonSerializer fhirJsonSerializer = new(new SerializerSettings() { Pretty = true });
string jsonText = fhirJsonSerializer.SerializeToString(patient);

FhirXmlSerializer fhirXmlSerializer = new(new SerializerSettings() { Pretty = true });
string xmlText = fhirXmlSerializer.SerializeToString(res);
```
