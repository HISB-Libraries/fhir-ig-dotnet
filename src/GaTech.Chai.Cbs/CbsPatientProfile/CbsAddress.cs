using System;
using GaTech.Chai.Cbs.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsPatientProfile
{
    public class CbsAddress
    {
        readonly Address address;

        internal CbsAddress(Address address)
        {
            this.address = address;
        }

        /// <summary>
        /// Additional codes for Address.use
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-cdc-address-use
        /// </summary>
        public Coding CdcAddressUse
        {
            get => address.GetExtension(
                    "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-cdc-address-use")?.Value as Coding;
            set => address.Extension.AddOrUpdateExtension(
                    "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-cdc-address-use", value);
        }

        /// <summary>
        /// Census Tract
        /// http://hl7.org/fhir/StructureDefinition/iso21090-ADXP-censusTract
        /// </summary>
        public string CensusTract
        {
            get
            {
                var line = address.LineElement.Find(l =>
                    l.GetExtension("http://hl7.org/fhir/StructureDefinition/iso21090-ADXP-censusTract") != null);

                return (line?.GetExtension("http://hl7.org/fhir/StructureDefinition/iso21090-ADXP-censusTract")?.Value as FhirString)?.ToString();
            }
            set
            {
                var line = address.LineElement.Find(l =>
                    l.GetExtension("http://hl7.org/fhir/StructureDefinition/iso21090-ADXP-censusTract") != null);
                if (line == null)
                {
                    var ext = new Extension();
                    line = new FhirString();
                    line.AddExtension("http://hl7.org/fhir/StructureDefinition/iso21090-ADXP-censusTract", new FhirString(value));
                    address.LineElement.Add(line);
                }
            }
        }

        /// <summary>
        /// Additional codes for Address.use
        /// Codes for Address.use which are used as slice discriminators to capture address history at relevant points in time to case surveillance
        /// </summary>
        public static class AddressUse
        {
            public const string CodeSystemUrl = "http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system";

            public static Coding AddressAtDiagnosis => Encode("Address-at-Diagnosis", "Address at time of Diagnosis");
            public static Coding UsualResidence => Encode("Usual-Residence", "Usual Residence");
            public static Coding Encode(string value, string display) => new Coding(CodeSystemUrl, value, display);
        }
    }
}
