using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Specification.Source;
using Hl7.Fhir.Validation;

namespace CbsSample
{
    public class ValidatorHelper
    {
        public static void ValidateResources(IEnumerable<Resource> resources)
        {
            var resolver = ZipSource.CreateValidationSource();
            var directoryResolver = new DirectorySource("profiles");

            var settings = ValidationSettings.CreateDefault();
            settings.ResourceResolver = new CachedResolver(
                new MultiResolver(resolver, directoryResolver));

            var validator = new Validator(settings);

            foreach (var r in resources)
            {
                // validate resource against custom profile
                var outcome = validator.Validate(r, r.Meta.Profile.ToArray());
                WriteOutcome(outcome, r);
            }
        }

        private static void WriteOutcome(OperationOutcome outcome, Resource resource)
        {
            Console.WriteLine($"Validation of {resource.TypeName} ({resource.Meta.Profile.First()}) {(outcome.Success ? "is successful" : "has failed:")}");
            if (!outcome.Success)
            {
                FhirJsonSerializer serializer = new(new SerializerSettings() { Pretty = true });
                //Console.WriteLine(serializer.SerializeToString(resource));
                Console.WriteLine("Issues:");
                outcome.Issue.ForEach(i => Console.WriteLine($"  {i}"));
            }
        }
    }
}
