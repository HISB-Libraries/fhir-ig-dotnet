using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using static Hl7.Fhir.Model.Composition;
using System.Collections.Generic;
using Code = Hl7.Fhir.Model.Code;
using GaTech.Chai.Vrdr;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// This Composition profile represents data exchanged between an MDI CMS and an EDRS.
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-and-edrs
    /// </summary>
    public class CompositionMdiAndEdrs
    {
        readonly Composition composition;

        internal CompositionMdiAndEdrs(Composition composition)
        {
            this.composition = composition;
        }

        /// <summary>
        /// Factory for CompositionMdiAndEdrsProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-and-edrs
        /// </summary>
        public static Composition Create(Identifier identifier, CompositionStatus status, Patient subject, Practitioner author, Code authorAbsentReason, Practitioner certifier, Code certifierAbsentReason, CompositionAttestationMode? attestationMode)
        {
            var composition = new Composition();
            composition.Type = new CodeableConcept("http://loinc.org", "86807-5", "Death administrative information Document", null);

            if (identifier != null) composition.Identifier = identifier;
            composition.Status = status;
            if (subject != null) composition.CompositionMdiAndEdrs().SubjectAsResource = subject;
            if (author != null)
            {
                composition.CompositionMdiAndEdrs().SetAuthor(author, null);
            } else
            {
                composition.CompositionMdiAndEdrs().SetAuthor(author, authorAbsentReason);
            }
            if (certifier != null)
            {
                composition.CompositionMdiAndEdrs().Certifier = (attestationMode, certifier, null);
            } else
            {
                composition.CompositionMdiAndEdrs().Certifier = (attestationMode, certifier, certifierAbsentReason);
            }

            composition.CompositionMdiAndEdrs().AddProfile();

            return composition;
        }

        /// <summary>
        /// Factory for CompositionMdiToEdresProfile with empty parameters
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-and-edrs
        /// Note: required parameters must be set individually.
        /// </summary>
        public static Composition Create()
        {
            var composition = new Composition();
            composition.Type = new CodeableConcept("http://loinc.org", "86807-5", "Death administrative information Document", null);
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
                Record.GetResources().TryGetValue(this.composition.Subject.Reference, out Resource value);

                return (Patient)value;
            }
            set
            {
                this.composition.Subject = value.AsReference();
                Record.GetResources()[value.AsReference().Reference] = value;
            }
        }

        /// <summary>
        /// Set Authors. 1..1
        /// </summary>
        public void SetAuthor(Practitioner practitioner, Code code)
        {
            if (practitioner == null)
            {
                ResourceReference practitionerReference = new();
                practitionerReference.AddDataAbsentReason(code);
                this.composition.Author = new List<ResourceReference>{practitionerReference};
            }
            else
            {
                if (this.composition.Author.Count > 0)
                {
                    if (this.composition.Attester.Count > 0) {
                        if (this.composition.Attester[0].Party?.Reference != practitioner.AsReference().Reference) {
                            Record.GetResources().Remove(this.composition.Attester[0].Party.Reference);
                        }
                    }
                    this.composition.Author.Clear();
                }
                this.composition.Author = new List<ResourceReference> { practitioner.AsReference() };

                Record.GetResources()[practitioner.AsReference().Reference] = practitioner;
            }
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
                Extension ext = new()
                {
                    Url = "http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number",
                    Value = new Identifier() { Type = MdiCodeSystem.MdiCodes.EdrsFileNumber, System = value.Item1, Value = value.Item2 }
                };
                this.composition.Extension.AddOrUpdateExtension(ext, true);
            }
        }

        /// <summary>
        /// Certifier: sets or gets certifier information
        /// DC certifier is set in Attester. Only one certifiier can exist.
        /// </summary>
        public (CompositionAttestationMode?, Practitioner, Code) Certifier
        {
            get
            {
                if (this.composition.Attester.Count > 0)
                {
                    if (Record.GetResources()[this.composition.Attester[0].Party.Reference] is not Practitioner practitioner)
                    {
                        Extension extension = this.composition.Attester[0].GetExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason");
                        Code codeValue = extension.Value as Code;
                        return (null, null, codeValue);
                    }
                    else
                    {
                        return (composition.Attester[0].Mode, practitioner, null);
                    }
                }

                return (null, null, null);
            }

            set
            {
                // input values: (mode, practitioner, data absent reason)
                // Clear the attester if we have someone.
                if (this.composition.Attester.Count > 0)
                {
                    ResourceReference certifier = this.composition.Attester[0].Party;

                    // see if certifier is also used in author
                    if (this.composition.Author != null && this.composition.Author.Count > 0) {
                        if (this.composition.Author[0] != certifier) {
                            Record.GetResources().Remove(certifier.Reference);
                        }
                    }
                    this.composition.Attester.Clear();
                }

                // we must have one attester.
                AttesterComponent attester = new();
                if (value.Item2 == null && value.Item3 != null)
                {
                    // Certifier is now empty, and dataabsentreason is available.
                    attester.AddDataAbsentReason(value.Item3);
                }
                else
                {
                    attester.Mode = value.Item1;
                    attester.Party = value.Item2.AsReference();
                    Record.GetResources()[value.Item2.AsReference().Reference] = value.Item2;
                }

                this.composition.Attester.Add(attester);
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
                if (Record.GetResources().TryGetValue(reference.Reference, out resource))
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
                    Record.GetResources()[valueResource.AsReference().Reference] = valueResource;
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
                return GetOrAddSection("demographics", MdiCompositionSections.AdditionalDemographics.Coding[0].Display).Text;
            }
            set
            {
                SectionComponent sectionComponent = new() { Code = MdiCompositionSections.AdditionalDemographics, Text = value };
                AddOrUpdateSection("demographics", MdiCompositionSections.AdditionalDemographics.Coding[0].Display, sectionComponent);
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
                return GetSectionAndEntry("circumstances", MdiCompositionSections.Circumstances);
            }

            set
            {
                SetSectionAndEntry("circumstances", MdiCompositionSections.Circumstances, value);
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
                return GetSectionAndEntry("jurisdiction", MdiCompositionSections.Jurisdiction);
            }

            set
            {
                SetSectionAndEntry("jurisdiction", MdiCompositionSections.Jurisdiction, value);
            }
        }

        private Observation GetCOD1(int lineNumber)
        {
            SectionComponent sectionComponent = GetOrAddSection("cause-manner", MdiCompositionSections.CauseManner.Coding[0].Display);
            foreach (ResourceReference reference in sectionComponent.Entry)
            {
                if (Record.GetResources().TryGetValue(reference.Reference, out Resource entryResource))
                {
                    Observation ob = (Observation)entryResource;
                    if (ob.hasProfile(ObservationMdiCauseOfDeathPart1.ProfileUrl))
                    {
                        if (ob.ObservationMdiCauseOfDeathPart1().LineNumber.Value == lineNumber)
                        {
                            return ob;
                        }
                    }
                }
            }

            return null;
        }

        public Observation SetCOD1(int lineNumber, string valueText, DataType interval)
        {
            if (lineNumber < 1 || lineNumber >4)
            {
                throw new ArgumentException("Cause of Death Part 1 can have line number 1..4.");
            }

            if (valueText == null || interval == null)
            {
                throw new ArgumentException("Cause of Death Part 1 must have both value and interval.");
            }

            Patient patient = (Patient) composition.CompositionMdiAndEdrs().SubjectAsResource;
            (CompositionAttestationMode? mode, Practitioner certifier, Code dataAbsentReason) = composition.CompositionMdiAndEdrs().Certifier;

            Observation cod1 = null;
            
            SectionComponent sectionComponent = GetOrAddSection("cause-manner", MdiCompositionSections.CauseManner.Coding[0].Display);
            foreach (ResourceReference reference in sectionComponent.Entry)
            {
                if (Record.GetResources().TryGetValue(reference.Reference, out Resource entryResource))
                {
                    Observation ob = (Observation)entryResource;
                    if (ob.hasProfile(ObservationMdiCauseOfDeathPart1.ProfileUrl))
                    {
                        if (ob.ObservationMdiCauseOfDeathPart1().LineNumber.Value == lineNumber)
                        {
                            cod1 = ob;
                            break;
                            // return ob;
                        }
                    }
                }
            }

            if (cod1 == null)
            {
                // create a new and add to entry
                cod1 = ObservationMdiCauseOfDeathPart1.Create();
                
                sectionComponent.Entry.Add(cod1.AsReference());
                Record.GetResources().Add(cod1.AsReference().Reference, cod1);
            }

            // update subject and certifier as well in case that's changed.
            if (patient != null)
            {
                cod1.ObservationMdiCauseOfDeathPart1().SubjectAsResource = patient;
            }

            if (certifier != null)
            {
                cod1.ObservationMdiCauseOfDeathPart1().PerformerAsResource = (Practitioner)certifier;
            }
            else 
            {
                ResourceReference certifierReference = new();
                certifierReference.AddDataAbsentReason(dataAbsentReason);
                cod1.Performer = new List<ResourceReference>() { certifierReference };
            }

            cod1.ObservationMdiCauseOfDeathPart1().ValueText = valueText;
            cod1.ObservationMdiCauseOfDeathPart1().Interval = interval;

            return cod1;
        }

        public Observation SetCOD1Value(int lineNumber, string valueText)
        {
            if (lineNumber < 1 || lineNumber >4)
            {
                throw new ArgumentException("Cause of Death Part 1 can have line number 1..4.");
            }

            Patient patient = (Patient) composition.CompositionMdiAndEdrs().SubjectAsResource;
            (CompositionAttestationMode? mode, Practitioner certifier, Code dataAbsentReason) = composition.CompositionMdiAndEdrs().Certifier;

            Observation cod1 = null;
            
            SectionComponent sectionComponent = GetOrAddSection("cause-manner", MdiCompositionSections.CauseManner.Coding[0].Display);
            foreach (ResourceReference reference in sectionComponent.Entry)
            {
                if (Record.GetResources().TryGetValue(reference.Reference, out Resource entryResource))
                {
                    Observation ob = (Observation)entryResource;
                    if (ob.hasProfile("http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-cause-of-death-part1"))
                    {
                        if (ob.ObservationMdiCauseOfDeathPart1().LineNumber.Value == lineNumber)
                        {
                            cod1 = ob;
                            break;
                            // return ob;
                        }
                    }
                }
            }

            if (cod1 == null)
            {
                // create a new and add to entry
                cod1 = ObservationMdiCauseOfDeathPart1.Create();
                
                sectionComponent.Entry.Add(cod1.AsReference());
                Record.GetResources().Add(cod1.AsReference().Reference, cod1);
            }

            // update subject and certifier as well in case that's changed.
            if (patient != null)
            {
                cod1.ObservationMdiCauseOfDeathPart1().SubjectAsResource = patient;
            }

            if (certifier != null)
            {
                cod1.ObservationMdiCauseOfDeathPart1().PerformerAsResource = (Practitioner)certifier;
            }
            else 
            {
                ResourceReference certifierReference = new();
                certifierReference.AddDataAbsentReason(dataAbsentReason);
                cod1.Performer = new List<ResourceReference>() { certifierReference };
            }

            cod1.ObservationMdiCauseOfDeathPart1().ValueText = valueText;

            return cod1;
        }

        public Observation SetCOD1Interval(int lineNumber, DataType interval)
        {
            if (lineNumber < 1 || lineNumber >4)
            {
                throw new ArgumentException("Cause of Death Part 1 can have line number 1..4.");
            }

            Patient patient = (Patient) composition.CompositionMdiAndEdrs().SubjectAsResource;
            (CompositionAttestationMode? mode, Practitioner certifier, Code dataAbsentReason) = composition.CompositionMdiAndEdrs().Certifier;

            Observation cod1 = null;
            
            SectionComponent sectionComponent = GetOrAddSection("cause-manner", MdiCompositionSections.CauseManner.Coding[0].Display);
            foreach (ResourceReference reference in sectionComponent.Entry)
            {
                if (Record.GetResources().TryGetValue(reference.Reference, out Resource entryResource))
                {
                    Observation ob = (Observation)entryResource;
                    if (ob.hasProfile(ObservationMdiCauseOfDeathPart1.ProfileUrl))
                    {
                        if (ob.ObservationMdiCauseOfDeathPart1().LineNumber.Value == lineNumber)
                        {
                            cod1 = ob;
                            break;
                            // return ob;
                        }
                    }
                }
            }

            if (cod1 == null)
            {
                // create a new and add to entry
                cod1 = ObservationMdiCauseOfDeathPart1.Create();
                
                sectionComponent.Entry.Add(cod1.AsReference());
                Record.GetResources().Add(cod1.AsReference().Reference, cod1);
            }

            // update subject and certifier as well in case that's changed.
            if (patient != null)
            {
                cod1.ObservationMdiCauseOfDeathPart1().SubjectAsResource = patient;
            }

            if (certifier != null)
            {
                cod1.ObservationMdiCauseOfDeathPart1().PerformerAsResource = (Practitioner)certifier;
            }
            else 
            {
                ResourceReference certifierReference = new();
                certifierReference.AddDataAbsentReason(dataAbsentReason);
                cod1.Performer = new List<ResourceReference>() { certifierReference };
            }

            cod1.ObservationMdiCauseOfDeathPart1().Interval = interval;

            return cod1;
        }

        public string COD1A
        {
            get
            {
                Observation ob = GetCOD1(1);
                if (ob != null)
                {
                    return ob.ObservationMdiCauseOfDeathPart1().ValueText;
                }

                return null;
            }
            set
            {
                SetCOD1Value(1, value);
            }
        }

        public string INTERVAL1A
        {
            get
            {

                Observation ob = GetCOD1(1);
                if (ob != null)
                {
                    return ob.ObservationMdiCauseOfDeathPart1().IntervalAsString;
                }

                return null;
            }
            set
            {
                SetCOD1Interval(1, new FhirString(value));
            }
        }

        public string COD1B
        {
            get
            {
                Observation ob = GetCOD1(2);
                if (ob != null)
                {
                    return ob.ObservationMdiCauseOfDeathPart1().ValueText;
                }

                return null;
            }
            set
            {
                SetCOD1Value(2, value);

            }
        }

        public string INTERVAL1B
        {
            get
            {

                Observation ob = GetCOD1(2);
                if (ob != null)
                {
                    return ob.ObservationMdiCauseOfDeathPart1().IntervalAsString;
                }

                return null;
            }
            set
            {
                SetCOD1Interval(2, new FhirString(value));
            }
        }

        public string COD1C
        {
            get
            {
                Observation ob = GetCOD1(3);
                if (ob != null)
                {
                    return ob.ObservationMdiCauseOfDeathPart1().ValueText;
                }

                return null;
            }
            set
            {
                SetCOD1Value(3, value);
            }
        }

        public string INTERVAL1C
        {
            get
            {

                Observation ob = GetCOD1(3);
                if (ob != null)
                {
                    return ob.ObservationMdiCauseOfDeathPart1().IntervalAsString;
                }

                return null;
            }
            set
            {
                SetCOD1Interval(3, new FhirString(value));
            }
        }

        public string COD1D
        {
            get
            {
                Observation ob = GetCOD1(4);
                if (ob != null)
                {
                    return ob.ObservationMdiCauseOfDeathPart1().ValueText;
                }

                return null;
            }
            set
            {
                SetCOD1Value(4, value);
            }
        }

        public string INTERVAL1D
        {
            get
            {

                Observation ob = GetCOD1(4);
                if (ob != null)
                {
                    return ob.ObservationMdiCauseOfDeathPart1().IntervalAsString;
                }

                return null;
            }
            set
            {
                SetCOD1Interval(4, new FhirString(value));
            }
        }

        public Observation GetCOD2()
        {
            SectionComponent sectionComponent = GetOrAddSection("cause-manner", MdiCompositionSections.CauseManner.Coding[0].Display);
            foreach (ResourceReference reference in sectionComponent.Entry)
            {
                if (Record.GetResources().TryGetValue(reference.Reference, out Resource entryResource))
                {
                    Observation ob = (Observation)entryResource;
                    if (ob.hasProfile(VrdrCauseOfDeathPart2.ProfileUrl))
                    {
                        return ob;
                    }
                }
            }

            return null;
        }

        public Observation SetCOD2(string valueText)
        {
            Patient patient = (Patient) composition.CompositionMdiAndEdrs().SubjectAsResource;
            (CompositionAttestationMode? mode, Practitioner certifier, Code dataAbsentReason) = composition.CompositionMdiAndEdrs().Certifier;

            Observation cod2 = null;
            
            SectionComponent sectionComponent = GetOrAddSection("cause-manner", MdiCompositionSections.CauseManner.Coding[0].Display);
            foreach (ResourceReference reference in sectionComponent.Entry)
            {
                if (Record.GetResources().TryGetValue(reference.Reference, out Resource entryResource))
                {
                    Observation ob = (Observation)entryResource;
                    if (ob.hasProfile(VrdrCauseOfDeathPart2.ProfileUrl))
                    {
                            cod2 = ob;
                            break;
                    }
                }
            }

            if (cod2 == null)
            {
                // create a new and add to entry
                cod2 = VrdrCauseOfDeathPart2.Create();
                
                sectionComponent.Entry.Add(cod2.AsReference());
                Record.GetResources().Add(cod2.AsReference().Reference, cod2);
            }

            // update subject and certifier as well in case that's changed.
            if (patient != null)
            {
                cod2.VrdrCauseOfDeathPart2().SubjectAsResource = patient;
            }

            if (certifier != null)
            {
                cod2.VrdrCauseOfDeathPart2().PerformerAsResource = (Practitioner)certifier;
            }

            cod2.VrdrCauseOfDeathPart2().ValueText = valueText ?? throw new ArgumentException("Cause of Death Part 1 must have both value and interval.");

            return cod2;
        }

        public string COD2
        {
            get
            {
                Observation ob = GetCOD2();
                return (ob.Value as CodeableConcept)?.Text;
            }
            set
            {
                SetCOD2(value);
            }
        }

        public Observation SetMannerOfDeath(CodeableConcept value)
        {
            Patient patient = (Patient) composition.CompositionMdiAndEdrs().SubjectAsResource;
            (CompositionAttestationMode? mode, Practitioner certifier, Code dataAbsentReason) = composition.CompositionMdiAndEdrs().Certifier;

            Observation mannerOfDeath = null;
            
            SectionComponent sectionComponent = GetOrAddSection("cause-manner", MdiCompositionSections.CauseManner.Coding[0].Display);
            foreach (ResourceReference reference in sectionComponent.Entry)
            {
                if (Record.GetResources().TryGetValue(reference.Reference, out Resource entryResource))
                {
                    Observation ob = (Observation)entryResource;
                    if (ob.hasProfile(VrdrMannerOfDeath.ProfileUrl))
                    {
                            mannerOfDeath = ob;
                            break;
                    }
                }
            }

            if (mannerOfDeath == null)
            {
                // create a new and add to entry
                mannerOfDeath = VrdrMannerOfDeath.Create();
                
                sectionComponent.Entry.Add(mannerOfDeath.AsReference());
                Record.GetResources().Add(mannerOfDeath.AsReference().Reference, mannerOfDeath);
            }

            // update subject and certifier as well in case that's changed.
            if (patient != null)
            {
                mannerOfDeath.VrdrMannerOfDeath().SubjectAsResource = patient;
            }

            mannerOfDeath.Value = value ?? throw new ArgumentException("Manner of death must have both value.");

            return mannerOfDeath;
        }

        public Observation MannerOfDeath
        {
            get
            {
                SectionComponent sectionComponent = GetOrAddSection("cause-manner", MdiCompositionSections.CauseManner.Coding[0].Display);
                foreach (ResourceReference reference in sectionComponent.Entry)
                {
                    if (Record.GetResources().TryGetValue(reference.Reference, out Resource entryResource))
                    {
                        Observation ob = (Observation)entryResource;
                        if (ob.hasProfile(VrdrMannerOfDeath.ProfileUrl))
                        {
                                return ob;
                        }
                    }
                }
                return null;
            }
            set
            {
                Observation mannerOfDeath = null;
                SectionComponent sectionComponent = GetOrAddSection("cause-manner", MdiCompositionSections.CauseManner.Coding[0].Display);
                foreach (ResourceReference reference in sectionComponent.Entry)
                {
                    if (Record.GetResources().TryGetValue(reference.Reference, out Resource entryResource))
                    {
                        Observation ob = (Observation)entryResource;
                        if (ob.hasProfile(VrdrMannerOfDeath.ProfileUrl))
                        {
                                mannerOfDeath = ob;
                                break;
                        }
                    }
                }

                if (mannerOfDeath == null)
                {
                    sectionComponent.Entry.Add(value.AsReference());
                }

                // this may have a newer contents. So updating glbal record.
                Record.GetResources().Add(value.AsReference().Reference, value);

            }
        }
        
        /// <summary>
        /// CauseManner: gets or sets lists of cause and manner references
        ///     value = (List<ResourceReference>, ResourceReference, ResourceReference, ResourceReference, EmptyReasonCode)
        ///         List of Resources: 4 Observations - Cause of Death Part 1 (a, b, c, d)
        ///         Resource: Observation - Contributing Cause of Death Part 2 (0..1)
        ///         Resource: Observation - Manner of Death (0..1)
        ///         Resource: Observation - How Death Injury Occurred (0..1)
        ///         EmptyReasonCode: GaTech.Chai.Share.Common.ListEmptyReason
        /// </summary>
        public (List<Observation>, Observation, Observation, Observation, CodeableConcept) CauseManner
        {
            get
            {
                List<Observation> causeOfDeathPart1 = new();
                Observation contributingCauseOfDeathPart2 = null;
                Observation mannerOfDeath = null;
                Observation deathInjuryOccurred = null;

                SectionComponent sectionComponent = GetOrAddSection("cause-manner", MdiCompositionSections.CauseManner.Coding[0].Display);
                foreach (ResourceReference reference in sectionComponent.Entry)
                {
                    if (Record.GetResources().TryGetValue(reference.Reference, out Resource resource))
                    {
                        if (resource.Meta == null)
                        {
                            continue;
                        }

                        foreach (string profile in resource.Meta.Profile)
                        {
                            if (ObservationMdiCauseOfDeathPart1.ProfileUrl.Equals(profile))
                            {
                                causeOfDeathPart1.Add(resource as Observation);
                            }
                            else if (VrdrCauseOfDeathPart2.ProfileUrl.Equals(profile))
                            {
                                contributingCauseOfDeathPart2 = resource as Observation;
                            }
                            else if (VrdrMannerOfDeath.ProfileUrl.Equals(profile))
                            {
                                mannerOfDeath = resource as Observation;
                            }
                            else if (VrdrInjuryIncident.ProfileUrl.Equals(profile))
                            {
                                deathInjuryOccurred = resource as Observation;
                            }
                        }
                    }
                }

                return (causeOfDeathPart1, contributingCauseOfDeathPart2, mannerOfDeath, deathInjuryOccurred, sectionComponent.EmptyReason);
            }

            set
            {
                SectionComponent sectionComponent = GetOrAddSection("cause-manner", MdiCompositionSections.CauseManner.Coding[0].Display);
                AddOrUpdateSection("cause-manner", MdiCompositionSections.CauseManner.Coding[0].Display, sectionComponent);

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
                            Record.GetResources().Add(resource.AsReference().Reference, resource);
                        }
                        else
                        {
                            // This exists. However, many the content got changed. Since the entry only stores
                            // reference, we just update global static Record.
                            Record.GetResources()[resource.AsReference().Reference] = resource;
                        }
                    }
                }

                // Contributing Cause of Death Part 2
                if (value.Item2 != null)
                {
                    if (!sectionComponent.Entry.Exists(x => x.Reference.Equals(value.Item2.AsReference().Reference)))
                    {
                        sectionComponent.Entry.Add(value.Item2.AsReference());
                        Record.GetResources().Add(value.Item2.AsReference().Reference, value.Item2);
                    }
                    else
                    {
                        // This exists. However, many the content got changed. Since the entry only stores
                        // reference, we just update global static Record.
                        Record.GetResources()[value.Item2.AsReference().Reference] = value.Item2;
                    }
                }

                // Manner of Death
                if (value.Item3 != null)
                {
                    if (!sectionComponent.Entry.Exists(x => x.Reference.Equals(value.Item3.AsReference().Reference)))
                    {
                        sectionComponent.Entry.Add(value.Item3.AsReference());
                        Record.GetResources().Add(value.Item3.AsReference().Reference, value.Item3);
                    }
                    else
                    {
                        // This exists. However, many the content got changed. Since the entry only stores
                        // reference, we just update global static Record.
                        Record.GetResources()[value.Item3.AsReference().Reference] = value.Item3;
                    }
                }

                // How Death Injury Occurred
                if (value.Item4 != null)
                {
                    if (!sectionComponent.Entry.Exists(x => x.Reference.Equals(value.Item4.AsReference().Reference)))
                    {
                        sectionComponent.Entry.Add(value.Item4.AsReference());
                        Record.GetResources().Add(value.Item4.AsReference().Reference, value.Item4);
                    }
                    else
                    {
                        // This exists. However, many the content got changed. Since the entry only stores
                        // reference, we just update global static Record.
                        Record.GetResources()[value.Item4.AsReference().Reference] = value.Item4;
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
                return GetSectionAndEntry("medical-history", MdiCompositionSections.MedicalHistory);
            }

            set
            {
                SetSectionAndEntry("medical-history", MdiCompositionSections.MedicalHistory, value);
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
                return GetSectionAndEntry("exam-autopsy", MdiCompositionSections.ExamAutopsy);
            }

            set
            {
                SetSectionAndEntry("exam-autopsy", MdiCompositionSections.ExamAutopsy, value);
            }
        }

        /// <summary>
        /// Narratives: gets or sets 
        /// </summary>
        public Narrative Narratives
        {
            get
            {
                return GetOrAddSection("narratives", MdiCompositionSections.Narratives.Coding[0].Display).Text;
            }

            set
            {
                SectionComponent sectionComponent = GetOrAddSection("narratives", MdiCompositionSections.Narratives.Coding[0].Display);
                sectionComponent.Text = value;
                AddOrUpdateSection("narratives", MdiCompositionSections.Narratives.Coding[0].Display, sectionComponent);
            }
        }

        protected SectionComponent GetOrAddSection(Coding coding)
        {
            return composition.Section.GetOrAddSection(coding.System, coding.Code,
                    coding.Display, coding.Display);
        }

        protected SectionComponent GetOrAddSection(string code, string display)
        {
            return composition.Section.GetOrAddSection(MdiCodeSystem.MdiCodes.officialUrl, code, display, display);
        }

        protected SectionComponent GetOrAddSection(string code, string display, string title)
        {
            return composition.Section.GetOrAddSection(MdiCodeSystem.MdiCodes.officialUrl, code, title, display);
        }

        protected void AddOrUpdateSection(string code, string display, Composition.SectionComponent section)
        {
            composition.Section.AddOrUpdateSection(MdiCodeSystem.MdiCodes.officialUrl, code, display, display, section);
        }

        protected void AddOrUpdateSection(string code, string display, string title, Composition.SectionComponent section)
        {
            composition.Section.AddOrUpdateSection(MdiCodeSystem.MdiCodes.officialUrl, code, title, display, section);
        }
    }
}