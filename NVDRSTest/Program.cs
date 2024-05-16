using System.Text.Json;
using System.Text.Json.Nodes;
using GaTech.Chai.Mdi.BundleDocumentMdiAndEdrsProfile;
using GaTech.Chai.Nvdrs;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        FlatObjectCMELE myFlat = new("./ExportConfigCMELE.json");

        Console.WriteLine("myVersion is " + myFlat.Version);

        FileStream SourceStream = File.Open("FHIRMessage-CaseId-718701.json", FileMode.Open);
        JsonNode? bundleJson = JsonNode.Parse(SourceStream);

        var options = new JsonSerializerOptions().ForFhir(ModelInfo.ModelInspector);
        var bundle = JsonSerializer.Deserialize<Bundle>(bundleJson!.ToJsonString(), options);
        bundle.BundleDocumentMdiAndEdrs().ImportResourcesInEntry();
        
        myFlat.MapToNVDRS(bundle!);
        myFlat.ExportToFile("");
    }

}