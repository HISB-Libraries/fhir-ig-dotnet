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
    public class VrdrDeathCertificate
    {
        readonly Composition composition;

        internal VrdrDeathCertificate(Composition composition)
        {
            this.composition = composition;
        }

        /// <summary>
        /// Factory for VrdrDeathCertificateProfile
        /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-death-certificate
        /// </summary>
        public static Composition Create(Identifier identifier, CompositionStatus status, Patient subject, Practitioner author, Practitioner certifier)
        {
            var composition = new Composition();
            composition.Type = new CodeableConcept(UriString.LOINC, "64297-5", "Death certificate", null);

            if (identifier != null) composition.Identifier = identifier;
            composition.Status = status;
            if (subject != null) composition.VrdrDeathCertificate().SubjectAsResource = subject;
            if (author != null)
            {
                composition.VrdrDeathCertificate().Author = author;
            }
            if (certifier != null)
            {
                composition.VrdrDeathCertificate().Certifier = certifier;
            }

            composition.VrdrDeathCertificate().AddProfile();
            composition.Title = "Death Certficate";

            return composition;
        }

        /// <summary>
        /// Factory for VrdrDeathCertificateProfile with empty parameters
        /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-death-certificate
        /// Note: required parameters must be set individually.
        /// </summary>
        public static Composition Create()
        {
            var composition = new Composition();
            composition.Type = new CodeableConcept(UriString.LOINC, "64297-5", "Death certificate", null);
            composition.VrdrDeathCertificate().AddProfile();
            composition.Title = "Death Certficate";

            return composition;
        }

        /// <summary>
        /// The official URL for the VrdrDeathCertificateProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-death-certificate";

        /// <summary>
        /// Set profile for the VrdrDeathCertificateProfile
        /// </summary>
        public void AddProfile()
        {
            composition.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the VrdrDeathCertificateProfile
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
        public Practitioner Author
        {
            get
            {
                if (this.composition.Author.Count > 0)
                {
                    if (Record.GetResources()[this.composition.Author[0].Reference] is not Practitioner practitioner)
                    {
                        return null;
                    }
                    else
                    {
                        return practitioner;
                    }
                }

                return null;
            }
            set
            {
                if (value != null)
                {
                    if (this.composition.Author.Count > 0)
                    {
                        if (this.composition.Attester.Count > 0)
                        {
                            if (this.composition.Attester[0].Party?.Reference != value.AsReference().Reference)
                            {
                                Record.GetResources().Remove(this.composition.Attester[0].Party.Reference);
                            }
                        }
                        this.composition.Author.Clear();
                    }
                    this.composition.Author = [value.AsReference()];

                    Record.GetResources()[value.AsReference().Reference] = value;
                }
            }
        }

        /// <summary>
        /// Certifier: sets or gets certifier information
        /// DC certifier is set in Attester. Only one certifiier can exist.
        /// </summary>
        public Practitioner Certifier
        {
            get
            {
                if (this.composition.Attester.Count > 0)
                {
                    if (Record.GetResources()[this.composition.Attester[0].Party.Reference] is not Practitioner practitioner)
                    {
                        return null;
                    }
                    else
                    {
                        return practitioner;
                    }
                }

                return null;
            }

            set
            {
                // input values: (mode, practitioner, data absent reason)
                // Clear the attester if we have someone.
                if (this.composition.Attester.Count > 0)
                {
                    ResourceReference certifier = this.composition.Attester[0].Party;

                    // see if certifier is also used in author
                    if (this.composition.Author != null && this.composition.Author.Count > 0)
                    {
                        if (this.composition.Author[0] != certifier)
                        {
                            // Author is different from the certifier. We remove the certifier from Record.
                            Record.GetResources().Remove(certifier.Reference);
                        }
                    }
                    this.composition.Attester.Clear();
                }

                // we must have one attester.
                AttesterComponent attester = new();
                if (value != null)
                {
                    attester.Mode = CompositionAttestationMode.Legal;
                    attester.Party = value.AsReference();
                    Record.GetResources()[value.AsReference().Reference] = value;
                }

                this.composition.Attester.Add(attester);
            }
        }

        /// <summary>
        /// FilingFormat Extension
        /// </summary>
        public CodeableConcept FilingFormat
        {
            get
            {
                Extension ext = this.composition.GetExtension(VrdrUrls.FilingFormatUrl);
                if (ext != null)
                {
                    return (ext.Value as CodeableConcept);
                }

                return null;
            }
            set
            {
                if (!VrdrFilingFormatCs.Electronic.CodingExist(value) &&
                    !VrdrFilingFormatCs.Paper.CodingExist(value) &&
                    !VrdrFilingFormatCs.Mixed.CodingExist(value))
                {
                    throw new Exception("The value for FilingFormat must be either Electronic, Paper or Mixed");
                }

                Extension ext = new()
                {
                    Url = VrdrUrls.FilingFormatUrl,
                    Value = value
                };

                this.composition.Extension.AddOrUpdateExtension(ext, false);
            }
        }

        /// <summary>
        /// ReplaceStatus Extension
        /// </summary>
        public CodeableConcept ReplaceStatus
        {
            get
            {
                Extension ext = this.composition.GetExtension(VrdrUrls.ReplaceStatusUrl);
                if (ext != null)
                {
                    return (ext.Value as CodeableConcept);
                }

                return null;
            }
            set
            {
                if (!VrdrReplaceStatusCs.Original.CodingExist(value) &&
                    !VrdrReplaceStatusCs.Updated.CodingExist(value) &&
                    !VrdrReplaceStatusCs.UpdatedNotforNCHS.CodingExist(value))
                {
                    throw new Exception("The value for ReplaceStatus must be either Original, Updated or UpdatedNotforNCHS");
                }

                Extension ext = new()
                {
                    Url = VrdrUrls.ReplaceStatusUrl,
                    Value = value
                };

                this.composition.Extension.AddOrUpdateExtension(ext, false);
            }
        }

        /// <summary>
        /// ReplaceStatus Extension
        /// </summary>
        public string StateSpecificField
        {
            get
            {
                Extension ext = this.composition.GetExtension(VrdrUrls.StateSpecificFieldUrl);
                if (ext != null)
                {
                    return (ext.Value as FhirString).ToString();
                }

                return null;
            }
            set
            {
                Extension ext = new()
                {
                    Url = VrdrUrls.StateSpecificFieldUrl,
                    Value = new FhirString(value)
                };

                this.composition.Extension.AddOrUpdateExtension(ext, false);
            }
        }

        /// <summary>
        /// Circumstances: gets or sets list of DecedentDemographics references
        ///     value = (List<Resource>, SectionText, EmptyReasonCode)
        ///     List of Resources:
        ///         As defined in the IG
        ///     EmptyReasonCode:
        ///         GaTech.Chai.Share.Common.ListEmptyReason
        /// </summary>
        public (List<Resource>, Narrative, CodeableConcept) DecedentDemographics
        {
            get
            {
                return GetSectionAndEntry(VrdrDocumentSectionCs.DecedentDemographics.Coding[0].Code, VrdrDocumentSectionCs.DecedentDemographics);
            }

            set
            {
                SetSectionAndEntry(VrdrDocumentSectionCs.DecedentDemographics.Coding[0].Code, VrdrDocumentSectionCs.DecedentDemographics, value);
            }
        }

        /// <summary>
        /// Circumstances: gets or sets list of DeathInvestigation references
        ///     value = (List<Resource>, SectionText, EmptyReasonCode)
        ///     List of Resources:
        ///         As defined in the IG
        ///     EmptyReasonCode:
        ///         GaTech.Chai.Share.Common.ListEmptyReason
        /// </summary>
        public (List<Resource>, Narrative, CodeableConcept) DeathInvestigation
        {
            get
            {
                return GetSectionAndEntry(VrdrDocumentSectionCs.DeathInvestigation.Coding[0].Code, VrdrDocumentSectionCs.DeathInvestigation);
            }

            set
            {
                SetSectionAndEntry(VrdrDocumentSectionCs.DeathInvestigation.Coding[0].Code, VrdrDocumentSectionCs.DeathInvestigation, value);
            }
        }

        /// <summary>
        /// Circumstances: gets or sets list of DeathCertification references
        ///     value = (List<Resource>, SectionText, EmptyReasonCode)
        ///     List of Resources:
        ///         As defined in the IG
        ///     EmptyReasonCode:
        ///         GaTech.Chai.Share.Common.ListEmptyReason
        /// </summary>
        public (List<Resource>, Narrative, CodeableConcept) DeathCertification
        {
            get
            {
                return GetSectionAndEntry(VrdrDocumentSectionCs.DeathCertification.Coding[0].Code, VrdrDocumentSectionCs.DeathCertification);
            }

            set
            {
                SetSectionAndEntry(VrdrDocumentSectionCs.DeathCertification.Coding[0].Code, VrdrDocumentSectionCs.DeathCertification, value);
            }
        }

        /// <summary>
        /// Circumstances: gets or sets list of DecedentDisposition references
        ///     value = (List<Resource>, SectionText, EmptyReasonCode)
        ///     List of Resources:
        ///         As defined in the IG
        ///     EmptyReasonCode:
        ///         GaTech.Chai.Share.Common.ListEmptyReason
        /// </summary>
        public (List<Resource>, Narrative, CodeableConcept) DecedentDisposition
        {
            get
            {
                return GetSectionAndEntry(VrdrDocumentSectionCs.DecedentDisposition.Coding[0].Code, VrdrDocumentSectionCs.DecedentDisposition);
            }

            set
            {
                SetSectionAndEntry(VrdrDocumentSectionCs.DecedentDisposition.Coding[0].Code, VrdrDocumentSectionCs.DecedentDisposition, value);
            }
        }

        /// <summary>
        /// Circumstances: gets or sets list of DecedentDisposition references
        ///     value = (List<Resource>, SectionText, EmptyReasonCode)
        ///     List of Resources:
        ///         As defined in the IG
        ///     EmptyReasonCode:
        ///         GaTech.Chai.Share.Common.ListEmptyReason
        /// </summary>
        public (List<Resource>, Narrative, CodeableConcept) CodedContent
        {
            get
            {
                return GetSectionAndEntry(VrdrDocumentSectionCs.CodedContent.Coding[0].Code, VrdrDocumentSectionCs.CodedContent);
            }

            set
            {
                SetSectionAndEntry(VrdrDocumentSectionCs.CodedContent.Coding[0].Code, VrdrDocumentSectionCs.CodedContent, value);
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

        public Observation MannerOfDeath
        {
            get
            {
                SectionComponent sectionComponent = GetOrAddSection(VrdrDocumentSectionCs.DeathCertification.Coding[0].Code, VrdrDocumentSectionCs.DeathCertification.Coding[0].Display);
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
                SectionComponent sectionComponent = GetOrAddSection(VrdrDocumentSectionCs.DeathCertification.Coding[0].Code, VrdrDocumentSectionCs.DeathCertification.Coding[0].Display);
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

                if (mannerOfDeath != null)
                {
                    sectionComponent.Entry.Remove(mannerOfDeath.AsReference());
                }

                sectionComponent.Entry.Add(value.AsReference());
                Record.GetResources().Add(value.AsReference().Reference, value);

            }
        }

        protected SectionComponent GetOrAddSection(Coding coding)
        {
            return composition.Section.GetOrAddSection(coding.System, coding.Code,
                    coding.Display, coding.Display);
        }

        protected SectionComponent GetOrAddSection(string code, string display)
        {
            return composition.Section.GetOrAddSection(VrdrDocumentSectionCs.officialUrl, code, display, display);
        }

        protected SectionComponent GetOrAddSection(string code, string display, string title)
        {
            return composition.Section.GetOrAddSection(VrdrDocumentSectionCs.officialUrl, code, title, display);
        }

        protected void AddOrUpdateSection(string code, string display, Composition.SectionComponent section)
        {
            string system = VrdrDocumentSectionCs.officialUrl;
            if (section.Code != null)
            {
                if (section.Code.Coding.Count != 0)
                {
                    system = section.Code.Coding[0].System;
                }
            }

            composition.Section.AddOrUpdateSection(system, code, display, display, section);
        }

        protected void AddOrUpdateSection(string code, string display, string title, Composition.SectionComponent section)
        {
            string system = VrdrDocumentSectionCs.officialUrl;
            if (section.Code != null)
            {
                if (section.Code.Coding.Count != 0)
                {
                    system = section.Code.Coding[0].System;
                }
            }

            composition.Section.AddOrUpdateSection(system, code, title, display, section);
        }
    }
}