using System;
using GaTech.Chai.Share.Common;
using GaTech.Chai.Share.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrcl.PatientVrProfile
{
	public class PatientVrParentReportedAgeAtDelivery
	{
		readonly Patient patient;

        internal PatientVrParentReportedAgeAtDelivery(Patient patient)
		{
			this.patient = patient;
		}

        public const string ExtUrl = "http://hl7.org/fhir/us/vr-common-library/StructureDefinition/Extension-reported-parent-age-at-delivery-vr";

        public Extension Extension
        {
            set
            {
                var parentReportedAgeAtDeliveryExt = AddOrUpdateReportedAgeAtDeliveryExtension();
                parentReportedAgeAtDeliveryExt.Value = value;
            }
            get
            {
                var parentReportedAgeAtDeliveryExt = patient.GetExtension(ExtUrl);
                return parentReportedAgeAtDeliveryExt?.Value as Extension;
            }
        }

        private Extension AddOrUpdateReportedAgeAtDeliveryExtension()
        {
            var parentReportedAgeAtDeliveryExt = new Extension() { Url = ExtUrl };
            return patient.Extension.AddOrUpdateExtension(parentReportedAgeAtDeliveryExt);
        }

        public const string ReportedAgeExtUrl = "reportedAge";

        public FhirDecimal ReportedAgeElement
        {
            set
            {
                Extension ext = Extension ?? new();
                Quantity qty = new()
                {
                    ValueElement = value,
                    Code = "a"
                };
                ext.SetExtension(ReportedAgeExtUrl, qty);
                Extension = ext;
            }
            get
            {
                Extension ext = Extension;
                if (ext != null)
                {
                    Quantity qty = ext.GetExtension(ReportedAgeExtUrl)?.Value as Quantity;
                    return qty.ValueElement;
                }

                return null;
            }
        }

        public decimal ReportedAge
        {
            set
            {
                ReportedAgeElement = new FhirDecimal(value);
            }
            get
            {
                return (decimal)ReportedAgeElement?.Value;
            }
        }

        public const string MotherOrFatherExtUrl = "motherOrFather";

        public CodeableConcept MotherOrFather
        {
            set
            {
                Extension ext = Extension ?? new();
                ext.SetExtension(MotherOrFatherExtUrl, value);
                Extension = ext;
            }
            get
            {
                Extension ext = Extension;
                return ext?.GetExtension(MotherOrFatherExtUrl)?.Value as CodeableConcept;
            }
        }

        public const string ReporterExtUrl = "reporter";

        public Resource Reporter
        {
            set
            {
                Extension ext = Extension ?? new();
                ext.SetExtension(ReporterExtUrl, value.AsReference());
                Extension = ext;

                Record.GetResources()[value.AsReference().Reference] = value;
            }
            get
            {
                Extension ext = Extension;
                ResourceReference reference = ext?.GetExtension(ReporterExtUrl)?.Value as ResourceReference;
                Record.GetResources().TryGetValue(reference.Reference, out Resource value);
                return value;
            }
        }
    }
}

