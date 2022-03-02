using System;
using GaTech.Chai.Cbs.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.FhirIg.Common
{
    /// <summary>
    /// Time window of interest in relationship to a specified event as determined by individual case based surveillance programs.
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-program-specific-time-window
    /// </summary>
    public class ProgramSpecificTimeWindow
    {
        readonly Observation observation;

        public ProgramSpecificTimeWindow(Observation observation)
        {
            this.observation = observation;
        }

        public const string ExtensionUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-program-specific-time-window";

        /// <summary>
        /// The quantity value of the program specific time window.
        /// </summary>
        public Quantity TimeWindow
        {
            set
            {
                var ext = AddOrUpdateExtension();
                ext.Extension.AddOrUpdateExtension(new Extension("timeWindow", value));
            }
            get
            {
                var ext = observation.GetExtension(ExtensionUrl);
                return ext?.GetExtension("timeWindow").Value as Quantity;
            }
        }

        /// <summary>
        /// Date to which Time Window is relative.
        /// </summary>
        public CodeableConcept RelativeTo
        {
            set
            {
                var ext = AddOrUpdateExtension();
                ext.Extension.AddOrUpdateExtension(new Extension("relativeTo", value));
            }
            get
            {
                var ext = observation.GetExtension(ExtensionUrl);
                return ext?.GetExtension("relativeTo").Value as CodeableConcept;
            }
        }

        /// <summary>
        /// Time Window relative To specified date in referenced Resource.
        /// </summary>
        public ResourceReference RelativeReference
        {
            set
            {
                var ext = AddOrUpdateExtension();
                ext.Extension.AddOrUpdateExtension(new Extension("relativeReference", value));
            }
            get
            {
                var ext = observation.GetExtension(ExtensionUrl);
                return ext?.GetExtension("relativeReference").Value as ResourceReference;
            }
        }

        private Extension AddOrUpdateExtension()
        {
            return observation.Extension.AddOrUpdateExtension(new Extension() { Url = ExtensionUrl });
        }
    }
}
