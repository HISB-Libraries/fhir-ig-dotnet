using GaTech.Chai.Mdi.BundleDocumentMdiAndEdrsProfile;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace MDIEDRSBundleRead
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new FhirJsonParser();

            string bundleText = System.IO.File.ReadAllText("/Users/mc142/Documents/workspace/MMG/cbs-ig-dotnet/MDIout/MDItoEDRS_Alice_Freeman_Document.json");
            var bundle = parser.Parse<Bundle>(bundleText);
            BundleDocumentMdiAndEdrs mdiAndEdrsBundle = bundle.BundleDocumentMdiAndEdrs();

            (String value, String interval) = mdiAndEdrsBundle.CauseOfDeathPart1A;

            Console.WriteLine("From MDI, CoA1.value=" + value + ", interval=" + interval);

            Console.WriteLine("From VRDR way, CoA1.value=" + mdiAndEdrsBundle.COD1A + ", interval=" + mdiAndEdrsBundle.INTERVAL1A);
            Console.WriteLine("From VRDR way, CoA1.value=" + mdiAndEdrsBundle.COD1B + ", interval=" + mdiAndEdrsBundle.INTERVAL1B);
            Console.WriteLine("From VRDR way, CoA1.value=" + mdiAndEdrsBundle.COD1C + ", interval=" + mdiAndEdrsBundle.INTERVAL1C);
            Console.WriteLine("From VRDR way, CoA1.value=" + mdiAndEdrsBundle.COD1D + ", interval=" + mdiAndEdrsBundle.INTERVAL1D);
        }
    }

}