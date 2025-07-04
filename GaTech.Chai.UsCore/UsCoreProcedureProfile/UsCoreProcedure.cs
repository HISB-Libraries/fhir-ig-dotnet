using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore
{
    /// <summary>
    /// US Core Procedure Profile
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-procedure
    /// </summary>
    public class UsCoreProcedure
    {
        readonly Procedure procedure;

        internal UsCoreProcedure(Procedure procedure)
        {
            this.procedure = procedure;
        }

        /// <summary>
        /// Factory for US Core Procedure Profile
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-procedure
        /// </summary>
        public static Procedure Create()
        {
            var procedure = new Procedure();
            procedure.UsCoreProcedure().AddProfile();
            procedure.Status = EventStatus.Completed;

            return procedure;
        }

        public static Procedure Create(Patient patient)
        {
            var procedure = new Procedure();
            procedure.UsCoreProcedure().AddProfile();
            procedure.Status = EventStatus.Completed;
            procedure.UsCoreProcedure().SubjectAsResource = patient;

            return procedure;
        }

        /// <summary>
        /// The official URL for the US Core Procedure profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-procedure";

        /// <summary>
        /// Set profile for US Core Organization Profile
        /// </summary>
        public void AddProfile()
        {
            this.procedure.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Core Organization Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.procedure.RemoveProfile(ProfileUrl);
        }

         public Patient SubjectAsResource
        {
            get
            {
                Record.GetResources().TryGetValue(this.procedure.Subject.Reference, out Resource value);
                return (Patient)value;
            }
            set
            {
                this.procedure.Subject = value.AsReference();
                Record.GetResources()[value.AsReference().Reference] = value;
            }
        }
    }
}
