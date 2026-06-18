# fhir-ig-share-dotnet
A .NET Library for FHIR IGs

This library contains .net extensions and value sets for FHIR IGs. This library is based on .NET FHIR classes (https://github.com/FirelyTeam/firely-net-sdk).

Sources are available in https://github.com/HISB-Libraries/fhir-ig-dotnet/tree/main/GaTech.Chai.Share 

Example:
```
public static Extension AddOrUpdateExtension(this List<Extension> extensions, Extension extension, bool allowDuplicateUrl = false)
{
    var ext = extensions.Find(e => e.Url == extension.Url);
    if (ext == null || allowDuplicateUrl == true)
    {
        extensions.Add(extension);
        ext = extension;
    }
    else
        ext.Value = extension.Value;
    return ext;
}
```

This .net extension for FHIR extensions can be used as follows.

```
 this.diagnosticReport.Extension.AddOrUpdateExtension(ext, true);
```

where ext is a new FHIR Extension. 