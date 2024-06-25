using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// ProcecureDeathCertificationProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Procedure-death-certification
    /// </summary>
    public class ProcedureDeathCertification
    {
        readonly Procedure procedure;
        readonly static Dictionary<string, Resource> resources = new();

        internal ProcedureDeathCertification(Procedure procedure)
        {
            this.procedure = procedure;
        }

        /// <summary>
        /// Factory for ProcecureDeathCertificationProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Procedure-death-certification
        /// </summary>
        public static Procedure Create()
        {
            // clear static resource container.
            resources.Clear();

            var procedure = new Procedure();

            procedure.ProcedureDeathCertification().AddProfile();
            procedure.Category = new CodeableConcept("http://snomed.info/sct", "103693007", "Diagnostic procedure", null);
            procedure.Code = new CodeableConcept("http://snomed.info/sct", "308646001", "Death certification", null);

            return procedure;
        }

        /// <summary>
        /// Factory for ProcecureDeathCertificationProfile with Subject
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Procedure-death-certification
        /// </summary>
        public static Procedure Create(Patient subject)
        {
            // clear static resource container.
            resources.Clear();

            var procedure = new Procedure();

            procedure.ProcedureDeathCertification().AddProfile();
            procedure.Category = new CodeableConcept("http://snomed.info/sct", "103693007", "Diagnostic procedure", null);
            procedure.Code = new CodeableConcept("http://snomed.info/sct", "308646001", "Death certification", null);
            procedure.ProcedureDeathCertification().SubjectAsResource = subject;

            return procedure;
        }

        /// <summary>
        /// The official URL for the ProcecureDeathCertificationProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Procedure-death-certification";

        /// <summary>
        /// Set profile for ProcecureDeathCertificationProfile
        /// </summary>
        public void AddProfile()
        {
            this.procedure.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for ProcecureDeathCertificationProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.procedure.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// setting subject reference and store the resource for future use
        /// </summary>
        public Patient SubjectAsResource
        {
            get
            {
                Resource value;
                resources.TryGetValue(this.procedure.Subject.Reference, out value);

                return (Patient)value;
            }
            set
            {
                this.procedure.Subject = value.AsReference();
                resources[value.AsReference().Reference] = value;
            }
        }

        /// <summary>
        /// setting or getting Certifier
        /// value = (CertifierType, Practitioner)
        /// </summary>
        public (CodeableConcept, Practitioner) Certifier
        {
            get
            {
                CodeableConcept certifierType = this.procedure.Performer?[0].Function;
                ResourceReference practitionerReference = this.procedure.Performer?[0].Actor;


                Practitioner practitioner = null;
                if (practitionerReference != null)
                {
                    practitioner = (Practitioner) resources[practitionerReference.Reference];
                }

                return (certifierType, practitioner);
            }
            set
            {
                this.procedure.Performer = new List<Procedure.PerformerComponent> { new Procedure.PerformerComponent { Function = value.Item1 } };
                this.procedure.Performer[0].Actor = value.Item2.AsReference();
                resources[value.Item2.AsReference().Reference] = value.Item2;
            }
        }

        public Dictionary<String, Resource> GetReferencedResources()
        {
            return resources;
        }
    }
}
