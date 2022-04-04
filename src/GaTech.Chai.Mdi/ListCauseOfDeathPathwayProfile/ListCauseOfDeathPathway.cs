using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Mdi.ListCauseOfDeathPathwayProfile
{
    /// <summary>
    /// List - ListCauseOfDeathPathwayProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/List-cause-of-death-pathway
    /// </summary>
    public class ListCauseOfDeathPathway
    {
        readonly List list;

        internal ListCauseOfDeathPathway(List list)
        {
            this.list = list;
            list.Status = List.ListStatus.Current;
            list.Mode = ListMode.Snapshot;
        }

        /// <summary>
        /// Factory for ListCauseOfDeathPathwayProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/List-cause-of-death-pathway
        /// </summary>
        public static List Create()
        {
            var list = new List();
            list.ListCauseOfDeathPathway().AddProfile();
            return list;
        }

        /// <summary>
        /// The official URL for the ListCauseOfDeathPathwayProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/List-cause-of-death-pathway";

        /// <summary>
        /// Set profile for the ListCauseOfDeathPathwayProfile
        /// </summary>
        public void AddProfile()
        {
            list.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the ListCauseOfDeathPathwayProfile
        /// </summary>
        public void RemoveProfile()
        {
            list.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Number of Entry control for Cause of Death Condition. Should not exceed 5.
        /// </summary>
        public void AddCauseOfDeathCondition(ResourceReference reference)
        {
            int? currentCount = this.list.Entry?.Count;
            if (currentCount == null || currentCount < 5)
            {
                this.list.Entry.Add(new List.EntryComponent() { Item = reference });
            }
            else
            {
                throw (new ArgumentException("The number of causes of death condition exceeded the allowed limit (5)."));
            }
        }
    }
}