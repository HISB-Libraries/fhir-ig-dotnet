# mdi-fhir-ig-dotnet
A .NET Library for [Medicolegal Death Investigation (MDI) FHIR IG (Current version)](https://build.fhir.org/ig/HL7/fhir-mdi-ig/)

All profiles built on top of standard .NET FHIR classes (https://github.com/FirelyTeam/firely-net-sdk). Only referenced profiles of US PH, US Core, VRDR, and VRCL are implemented. Rest of profiles will be added as needed. 

## Development Note
Firely .net FHIR classes are used as a basis for FHIR objects. All profiles are implemented using C# extensions. Invidual profiles can be used to extend the basic FHIR objects. Whenever the profile extensions are used, the profile names are automatically added to the meta section of FHIR resources that are being implemeted. The class extensions that are used create the fixed elements as defined in the IG. However, any fixed values that are not required (with cardinality 0..) will not be created. Instead, the fixed values should be available as a static value or C# property.

Hl7.Fhir.R4 and Hl7.Fhir.Specification.R4 NuGet Packages are required. 

## How to use the FHIR IG .net Library
Pleaase refer to the example codes availablel in https://github.com/HISB-Libraries/fhir-ig-dotnet/tree/main/MdiExample. The name of extension is in most cases from the name of profile. For any specific values or structures defined in the IG, helper methods are available in either properties or class functions. Please refer to the source code of the profile to get the list of available helpers in https://github.com/HISB-Libraries/fhir-ig-dotnet/tree/main/GaTech.Chai.Mdi. 

There are extensions that are applicable to multiple IG profile libraries. Thsse are implemented in Gatech.Chai.Share project. Please include this namespace to use those extensions.

First step of using this library is starting from the profile you are trying to use. If you are trying to create UsCore FHIR patient, then use the static Create() - note that all profile libraries have a static method called, "Create()". See below for a patient example.
```
Patient patient = PatientVr.Create();

patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino") };
patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

This will create the Ethnicity in FHIR:
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

The follwoing will create the Cause of Death Part 1 Observation.
```
Observation causeOfDeath1 = ObservationMdiCauseOfDeathPart1.Create(patient, practitioner, "Fentanyl toxicity", 1, "minutes to hours");
```