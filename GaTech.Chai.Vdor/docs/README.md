# fhir-ig-vdor-dotnet
A .NET Library for VDOR FHIR IG, https://build.fhir.org/ig/HL7/fhir-mdi-ig/ 

This library provides 
* supporting functions, 
* extensions
* value sets
* NVDRS flatfile and cvs files

Sources are available in https://github.com/HISB-Libraries/fhir-ig-dotnet/tree/main/GaTech.Chai.Vdor 

Example:
```
Composition nvdrsTestComp = VdorComposition.Create(patient, null, ValueSets.Hl7VsDataAbsentReason.NotAsked, NvdrsDocTypesVs.CMEReport);
nvdrsTestComp.VdorComposition().ForceNewRecord = false;
nvdrsTestComp.VdorComposition().OverwriteConflicts = true;
nvdrsTestComp.VdorComposition().IncidentNumber = "12";
nvdrsTestComp.VdorComposition().IncidentYear = new Date(2025);
nvdrsTestComp.VdorComposition().VictimNumber = "1";
```

Generating NVDRS Import CSV file from Bundle

```
FlatObjectCMELE flatCMEObject = new("csv");
FlatObjectTox flatToxFindingsObject = new("csv");

nvdrsTestBundle.VdorDocumentBundle().ExportToNVDRS(flatCMEObject);
nvdrsTestBundle.VdorDocumentBundle().ExportToNVDRS(flatToxFindingsObject);
```