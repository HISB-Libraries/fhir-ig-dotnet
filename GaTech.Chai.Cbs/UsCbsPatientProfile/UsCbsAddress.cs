using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCbs.PatientProfile
{
    /// <summary>
    /// Us CBS Address Helper for Us CBS Patient profile
    /// </summary>
    public class UsCbsAddress
    {
        readonly Address address;

        internal UsCbsAddress(Address address)
        {
            this.address = address;
        }

        /// <summary>
        /// Additional codes for Address.use
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-cdc-address-use
        /// </summary>
        public Coding CbsCdcAddressUse
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
    }
}
