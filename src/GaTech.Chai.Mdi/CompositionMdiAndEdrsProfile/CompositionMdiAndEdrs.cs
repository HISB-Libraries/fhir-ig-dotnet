using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using static Hl7.Fhir.Model.Composition;
using GaTech.Chai.Mdi.Common;
using System.Collections.Generic;
using Hl7.Fhir.Language.Debugging;
using Newtonsoft.Json.Linq;

namespace GaTech.Chai.Mdi.CompositionMdiAndEdrsProfile
{
    /// <summary>
    /// CompositionMditoEdrsProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-and-edrs
    /// </summary>
    public class CompositionMdiAndEdrs
    {
        readonly Composition composition;
        readonly static Dictionary<string, Resource> resources = new ();

        internal CompositionMdiAndEdrs(Composition composition)
        {
            this.composition = composition;
            composition.Type = new CodeableConcept("http://loinc.org", "86807-5", "Death administrative information Document", null);
        }

        /// <summary>
        /// Factory for CompositionMdiAndEdrsProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-and-edrs
        /// </summary>
        public static Composition Create(Identifier identifier, CompositionStatus status, Patient subject, Practitioner author, Practitioner certifier, CompositionAttestationMode? attestationMode)
        {
            // clear static resource container.
            resources.Clear();

            var composition = new Composition();
            composition.CompositionMdiAndEdrs().AddProfile();

            if (identifier != null) composition.Identifier = identifier;
            composition.Status = status;
            if (subject != null) composition.CompositionMdiAndEdrs().SubjectAsResource = subject;
            if (author != null) composition.CompositionMdiAndEdrs().SetAuthor(author);
            if (certifier != null) composition.CompositionMdiAndEdrs().Certifier = (attestationMode, certifier, DataAbsentReason.NotApplicable);

            return composition;
        }

        /// <summary>
        /// Factory for CompositionMdiToEdresProfile with empty parameters
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-and-edrs
        /// Note: required parameters must be set individually.
        /// </summary>
        public static Composition Create()
        {
            // clear static resource container.
            resources.Clear();

            var composition = new Composition();
            composition.CompositionMdiAndEdrs().AddProfile();

            return composition;
        }

        /// <summary>
        /// The official URL for the CompositionMditoEdrsProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-and-edrs";

        /// <summary>
        /// Set profile for the CompositionMditoEdrsProfile
        /// </summary>
        public void AddProfile()
        {
            composition.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the CompositionMditoEdrsProfile
        /// </summary>
        public void RemoveProfile()
        {
            composition.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Get and Set subject as Patient
        /// </summary>
        public Patient SubjectAsResource
        {
            get
            {
                Resource value;
                resources.TryGetValue(this.composition.Subject.Reference, out value);

                return (Patient)value;
            }
            set
            {
                this.composition.Subject = value.AsReference();
                resources[value.AsReference().Reference] = value;
            }
        }

        /// <summary>
        /// Set Authors. 1..1
        /// </summary>
        public void SetAuthor(Practitioner practitioner)
        {
            if (this.composition.Author.Count > 0)
            {
                this.composition.Author.Clear();
            }
            this.composition.Author = new List<ResourceReference> { new ResourceReference(practitioner.AsReference().Reference) };

            resources[practitioner.AsReference().Reference] = practitioner;
        }

        /// <summary>
        /// MDI Case Number:
        /// </summary>
        public (string, string) MdiCaseNumber
        {
            get
            {
                foreach (Extension ext in this.composition.GetExtensions("http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number"))
                {
                    Coding coding = (ext.Value as Identifier).Type?.Coding?.Find(e => e.System == "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes" && e.Code == "mdi-case-number");
                    if (coding != null)
                    {
                        return ((ext.Value as Identifier).System, (ext.Value as Identifier).Value);
                    }
                }

                return (null, null);
            }

            set
            {
                Extension ext = new ()
                {
                    Url = "http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number",
                    Value = new Identifier() { Type = MdiCodeSystem.MdiCodes.MdiCaseNumber, System = value.Item1, Value = value.Item2 }
                };
                this.composition.Extension.AddOrUpdateExtension(ext, true);
            }
        }

        /// <summary>
        /// EDRS File Number
        /// </summary>
        public (string, string) EdrsFileNumber
        {
            get
            {
                foreach (Extension ext in this.composition.GetExtensions("http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number"))
                {
                    Coding coding = (ext.Value as Identifier).Type?.Coding?.Find(e => e.System == "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes" && e.Code == "edrs-file-number");
                    if (coding != null)
                    {
                        return ((ext.Value as Identifier).System, (ext.Value as Identifier).Value);
                    }
                }

                return (null, null);
            }

            set
            {
                Extension ext = new Extension() { Url = "http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number" };
                ext.Value = new Identifier() { Type = MdiCodeSystem.MdiCodes.EdrsFileNumber, System = value.Item1, Value = value.Item2 };
                this.composition.Extension.AddOrUpdateExtension(ext, true);
            }
        }

        /// <summary>
        /// Certifier: sets or gets certifier information
        /// DC certifier is set in Attester. Only one certifiier can exist.
        public (CompositionAttestationMode?, Resource, DataAbsentReason) Certifier
        {
            get
            {
                if (this.composition.Attester != null && this.composition.Attester.Count > 0)
                {
                    Resource resource = resources[this.composition.Attester[0].Party.Reference];
                    if (resource == null)
                    {
                        Extension extension = this.composition.Attester[0].GetExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason");
                        Code codeValue = extension.Value as Code;
                        DataAbsentReason dataAbsentReason = codeValue.Value.GetEnumValueFromCode<DataAbsentReason>();
                        return (null, null, dataAbsentReason);
                    }
                    else
                    {
                        return (composition.Attester[0].Mode, resource, DataAbsentReason.NotApplicable);
                    }
                }

                return (null, null, DataAbsentReason.NotApplicable);
            }

            set
            {
                // Clear the attester if we have someone.
                if (this.composition.Attester != null && this.composition.Attester.Count > 0)
                {
                    ResourceReference certifier = this.composition.Attester[0].Party;
                    resources.Remove(certifier.Reference);
                    this.composition.Attester.Clear();
                }

                if (value.Item2 == null)
                {
                    // Certifier is now empty. Put dataabsentreason.
                    this.composition.Attester.Add(new AttesterComponent() {
                        Extension = new List<Extension> { new Extension(value.Item3.GetEnumSystem(), new Code(value.Item3.GetEnumCode())) } });
                }
                else
                {
                    this.composition.Attester.Add(new AttesterComponent() { Mode = value.Item1, Party = value.Item2.AsReference() });
                    resources[value.Item2.AsReference().Reference] = value.Item2;
                }
            }
        }

        /// <summary>
        /// getSectionAndEntry: Helper function returns gets/adds section and get entry or list empty reason if available
        /// </summary>
        /// <param name="code"></param>
        /// <param name="mdiCodeSystem"></param>
        /// <returns></returns>
        private (List<Resource>, Narrative, CodeableConcept) GetSectionAndEntry(string code, CodeableConcept mdiCodeSystem)
        {
            SectionComponent sectionComponent = GetOrAddSection(code, mdiCodeSystem.Coding[0].Display);
            List<Resource> valueResource = new();
            foreach (ResourceReference reference in sectionComponent.Entry)
            {
                Resource resource;
                if (resources.TryGetValue(reference.Reference, out resource))
                {
                    valueResource.Add(resource);
                }
                else
                {
                    Console.WriteLine(reference.Reference + " is not found from resource dictionary");
                }
            }

            return (valueResource, sectionComponent.Text, sectionComponent.EmptyReason);
        }

        /// <summary>
        /// setSectionAndEntry: Helper function that sets section and entry or list empty reason if appropriate
        /// </summary>
        /// <param name="code"></param>
        /// <param name="mdiCodeSystem"></param>
        /// <param name="value"></param>
        private void SetSectionAndEntry(string code, CodeableConcept mdiCodeSystem, (List<Resource>, Narrative, CodeableConcept) value)
        {
            List<ResourceReference> references = new();

            if (value.Item1 != null)
            {
                foreach (Resource valueResource in value.Item1)
                {
                    references.Add(valueResource.AsReference());
                    resources[valueResource.AsReference().Reference] = valueResource;
                }
            }

            SectionComponent sectionComponent = new() { Code = mdiCodeSystem, Entry = references };
            if (value.Item2 != null)
            {
                sectionComponent.Text = value.Item2;
            }

            if (value.Item1 == null || value.Item1.Count == 0)
            {
                sectionComponent.EmptyReason = value.Item3;
            }

            AddOrUpdateSection(code, mdiCodeSystem.Coding[0].Display, sectionComponent);
        }

        /// </summary>
        /// <summary>
        /// Additional Demographics: gets or sets additional demographics that are not covered by demographics
        ///     value = string of present or past work/occupation
        /// </summary>
        public Narrative AdditionalDemographics
        {
            get
            {
                return GetOrAddSection("demographics", MdiCodeSystem.MdiCodes.AdditionalDemographics.Coding[0].Display).Text;
            }
            set
            {
                SectionComponent sectionComponent = new() { Code = MdiCodeSystem.MdiCodes.AdditionalDemographics, Text = value };
                AddOrUpdateSection("demographics", MdiCodeSystem.MdiCodes.AdditionalDemographics.Coding[0].Display, sectionComponent);
            }
        }

        /// <summary>
        /// Circumstances: gets or sets list of circumstance references
        ///     value = (List<Resource>, SectionText, EmptyReasonCode)
        ///     Possible Resources:
        ///         Location - Death,
        ///         Observation - Tobacco Use Contributed to Death,
        ///         Observation - Decedent Pregnancy,
        ///         Location - Injury
        ///     EmptyReasonCode:
        ///         GaTech.Chai.Share.Common.ListEmptyReason
        /// </summary>
        public (List<Resource>, Narrative, CodeableConcept) Circumstances
        {
            get
            {
                return GetSectionAndEntry("circumstances", MdiCodeSystem.MdiCodes.Circumstances);
            }

            set
            {
                SetSectionAndEntry("circumstances", MdiCodeSystem.MdiCodes.Circumstances, value);
            }
        }

        /// <summary>
        /// Jurisdiction: gets or sets lists of references for Jurisdiction
        ///     value = (List<Resource>, SectionText, EmptyReasonCode)
        ///     Resource:
        ///         Observation - Death Date,
        ///         Procedure - Death Certification
        ///     EmptyReasonCode:
        ///         GaTech.Chai.Share.Common.ListEmptyReason
        /// </summary>
        public (List<Resource>, Narrative, CodeableConcept) Jurisdiction
        {
            get
            {
                return GetSectionAndEntry("jurisdiction", MdiCodeSystem.MdiCodes.Jurisdiction);
            }

            set
            {
                SetSectionAndEntry("jurisdiction", MdiCodeSystem.MdiCodes.Jurisdiction, value);
            }
        }

        /// <summary>
        /// CauseManner: gets or sets lists of cause and manner references
        ///     value = (List<ResourceReference>, ResourceReference, ResourceReference, ResourceReference, EmptyReasonCode)
        ///         List1 of Resource: Observation - Cause of Death Part 1 (0..4)
        ///         List2 of Resource: Observation - Contributing Cause of Death Part 2 (0..1)
        ///         List3 of Resource: Observation - Manner of Death (0..1)
        ///         List4 of Resource: Observation - How Death Injury Occurred (0..1)
        ///         EmptyReasonCode:
        ///             GaTech.Chai.Share.Common.ListEmptyReaso
        /// </summary>
        public (List<Resource>, Resource, Resource, Resource, CodeableConcept) CauseManner
        {
            get
            {
                List<Resource> causeOfDeathPart1 = new();
                Resource contributingCauseOfDeathPart2 = null;
                Resource mannerOfDeath = null;
                Resource deathInjuryOccurred = null;

                SectionComponent sectionComponent = GetOrAddSection("cause-manner", MdiCodeSystem.MdiCodes.CauseManner.Coding[0].Display);
                foreach (ResourceReference reference in sectionComponent.Entry)
                {
                    Resource resource;
                    if (resources.TryGetValue(reference.Reference, out resource))
                    {
                        if (resource.Meta == null)
                        {
                            resource.Meta = new Meta();
                        }

                        foreach (string profile in resource.Meta.Profile)
                        {
                            if ("http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-cause-of-death-part1".Equals(profile))
                            {
                                causeOfDeathPart1.Add(resource);
                            }
                            else if ("http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-contributing-cause-of-death-part2".Equals(profile))
                            {
                                contributingCauseOfDeathPart2 = resource;
                            }
                            else if ("http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-manner-of-death".Equals(profile))
                            {
                                mannerOfDeath = resource;
                            }
                            else if ("http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-how-death-injury-occurred".Equals(profile))
                            {
                                deathInjuryOccurred = resource;
                            }
                        }
                    }
                }

                return (causeOfDeathPart1, contributingCauseOfDeathPart2, mannerOfDeath, deathInjuryOccurred, sectionComponent.EmptyReason);
            }

            set
            {
                SectionComponent sectionComponent = GetOrAddSection("cause-manner", MdiCodeSystem.MdiCodes.CauseManner.Coding[0].Display);
                AddOrUpdateSection("cause-manner", MdiCodeSystem.MdiCodes.CauseManner.Coding[0].Display, sectionComponent);

                // Cause of Death Part 1
                if (value.Item1 != null)
                {
                    if (value.Item1.Count > 4)
                    {
                        throw (new ArgumentException("Cause-Manner : Causes of Death cannot be more than 4."));
                    }

                    foreach (Resource resource in value.Item1)
                    {
                        if (!sectionComponent.Entry.Exists(x => x.Reference.Equals(resource.AsReference().Reference)))
                        {
                            sectionComponent.Entry.Add(resource.AsReference());
                            resources.Add(resource.AsReference().Reference, resource);
                        }
                    }
                }

                // Contributing Cause of Death Part 2
                if (value.Item2 != null)
                {
                    if (!sectionComponent.Entry.Exists(x => x.Reference.Equals(value.Item2.AsReference().Reference)))
                    {
                        sectionComponent.Entry.Add(value.Item2.AsReference());
                        resources.Add(value.Item2.AsReference().Reference, value.Item2);
                    }
                }

                // Manner of Death
                if (value.Item3 != null)
                {
                    if (!sectionComponent.Entry.Exists(x => x.Reference.Equals(value.Item3.AsReference().Reference)))
                    {
                        sectionComponent.Entry.Add(value.Item3.AsReference());
                        resources.Add(value.Item3.AsReference().Reference, value.Item3);
                    }
                }

                // How Death Injury Occurred
                if (value.Item4 != null)
                {
                    if (!sectionComponent.Entry.Exists(x => x.Reference.Equals(value.Item4.AsReference().Reference)))
                    {
                        sectionComponent.Entry.Add(value.Item4.AsReference());
                        resources.Add(value.Item4.AsReference().Reference, value.Item4);
                    }
                }

                if ((value.Item1 == null || value.Item1.Count == 0) && value.Item2 == null && value.Item3 == null && value.Item4 == null)
                {
                    if (value.Item5 == null)
                    {
                        throw (new ArgumentException("Cause-Manner sections are empty. ListEmptyReason must be provided."));
                    } else
                    {
                        sectionComponent.EmptyReason = value.Item5;
                    }
                }
            }
        }

        /// <summary>
        /// MedicalHistory: gets or sets list of relevant medical history.
        ///     value = (List<ResourceReference>, Narrative, EmptyReasonCode)
        ///     Resource:
        ///         US Core Condition Encounter Diagnosis Profile |
        ///         US Core Condition Problems and Health Concerns Profile
        ///     EmptyReasonCode:
        ///         GaTech.Chai.Share.Common.ListEmptyReason
        /// </summary>
        public (List<Resource>, Narrative, CodeableConcept) MedicalHistory
        {
            get
            {
                return GetSectionAndEntry("medical-history", MdiCodeSystem.MdiCodes.MedicalHistory);
            }

            set
            {
                SetSectionAndEntry("medical-history", MdiCodeSystem.MdiCodes.MedicalHistory, value);
            }
        }

        /// <summary>
        /// ExamAutopsy: gets or sets list of Exam Autopsy.
        ///     value = (List<ResourceReference>, Narrative, EmptyReasonCode)
        ///     Resource:
        ///         Observation - Autopsy Performed Indicator,
        ///         Organization or Location - Autopsy Location
        ///     EmptyReasonCode:
        ///         GaTech.Chai.Share.Common.ListEmptyReason
        /// </summary>
        public (List<Resource>, Narrative, CodeableConcept) ExamAutopsy
        {
            get
            {
                return GetSectionAndEntry("exam-autopsy", MdiCodeSystem.MdiCodes.ExamAutopsy);
            }

            set
            {
                SetSectionAndEntry("exam-autopsy", MdiCodeSystem.MdiCodes.ExamAutopsy, value);
            }
        }

        /// <summary>
        /// Narratives: gets or sets 
        /// </summary>
        public string Narratives
        {
            get
            {
                SectionComponent sectionComponent = GetOrAddSection("narratives", null);
                return sectionComponent.Text?.Div;
            }

            set
            {
                SectionComponent sectionComponent = GetOrAddSection("narratives", MdiCodeSystem.MdiCodes.Narratives.Coding[0].Display);
                sectionComponent.Text = new Narrative() { Div = value };
                AddOrUpdateSection("narratives", MdiCodeSystem.MdiCodes.Narratives.Coding[0].Display, sectionComponent);
            }
        }

        protected SectionComponent GetOrAddSection(Coding coding)
        {
            return composition.Section.GetOrAddSection(coding.System, coding.Code,
                    coding.Display, coding.Display);
        }

        protected SectionComponent GetOrAddSection(string code, string display)
        {
            return composition.Section.GetOrAddSection(
                    "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", code,
                    display, display);
        }

        protected SectionComponent GetOrAddSection(string code, string display, string title)
        {
            return composition.Section.GetOrAddSection(
                    "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes",
                    code, title, display);
        }

        protected void AddOrUpdateSection(string code, string display, Composition.SectionComponent section)
        {
            composition.Section.AddOrUpdateSection(
                    "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", code,
                    display, display, section);
        }

        protected void AddOrUpdateSection(string code, string display, string title, Composition.SectionComponent section)
        {
            composition.Section.AddOrUpdateSection(
                    "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes",
                    code, title, display, section);
        }

        public Dictionary<String, Resource> GetResourcesInSections()
        {
            return resources;
        }
    }
}