using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vrdr
{
    public class VrdrDeathCertification
    {
        readonly Procedure procedure;

        internal VrdrDeathCertification(Procedure procedure)
        {
            this.procedure = procedure;
        }

        /// <summary>
        /// Factory for MannerOfDeathProfile
        /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-manner-of-death
        /// </summary>
        public static Procedure Create()
        {
            var procedure = new Procedure();
            procedure.VrdrDeathCertification().AddProfile();
            procedure.VrdrDeathCertification().AddFixedValue();

            return procedure;
        }

        public static Procedure Create(Patient patient)
        {
            var procedure = new Procedure();
            procedure.VrdrDeathCertification().AddProfile();
            procedure.VrdrDeathCertification().AddFixedValue();
            procedure.VrdrDeathCertification().SubjectAsResource = patient;

            return procedure;
        }

        public const string ProfileUrl = "http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-death-certification";

        public void AddFixedValue()
        {
            this.procedure.Code = VrdrCs.DeathCertificationSCT;
            this.procedure.Status = EventStatus.Completed;
            this.procedure.Category = new (UriString.SCT, "103693007");
            this.procedure.Code = new (UriString.SCT, "308646001");
        }

        /// <summary>
        /// Set profile for MannerOfDeathProfile
        /// </summary>
        public void AddProfile()
        {
            this.procedure.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for MannerOfDeathProfile
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
                Record.GetResources().TryGetValue(this.procedure.Subject.Reference, out value);

                return (Patient)value;
            }
            set
            {
                this.procedure.Subject = value.AsReference();
                Record.GetResources()[value.AsReference().Reference] = value;
            }
        }

        public void AddPerformer(Practitioner actorAsResource, CodeableConcept function)
        {
            if (actorAsResource is not Practitioner)
            {
                throw new Exception("Death Cetification Performer must be Practitioner.");
            }

            if (function == null)
            {
                throw new Exception("Death Cetification Performer must have function.");
            }

            bool exists = false;
            foreach (Procedure.PerformerComponent performer in this.procedure.Performer)
            {
                if (performer.Function.Matches(function))
                {
                    exists = true;
                }
                else
                {
                    exists = false;
                }

                Resource practitioner_;
                Record.GetResources().TryGetValue(performer.Actor.Reference, out practitioner_);
                if (practitioner_ is Practitioner)
                {
                    if (practitioner_.Matches(actorAsResource))
                    {
                        exists = true;
                    }
                    else
                    {
                        exists = false;
                    }
                }
                else
                {
                    exists = false;
                }

                if (exists)
                {
                    // we already have this. No need to add.
                    return;
                }
            }
            this.procedure.Performer.Add(new() { Actor = actorAsResource.AsReference(), Function = function });
            Record.GetResources()[actorAsResource.AsReference().Reference] = actorAsResource;            
        }
    }
}
