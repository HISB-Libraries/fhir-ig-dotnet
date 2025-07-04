using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using static Hl7.Fhir.Model.Composition;
using System.Collections.Generic;
using Code = Hl7.Fhir.Model.Code;
using GaTech.Chai.Vrcl;
using System.Linq;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// The body of a document exchanged between an EDRS and an MDI CMS for a death certificate review
    /// for the purpose of death data quality improvement, cremation clearance, or other workflow. 
    /// It can contain EDRS death certificate structured data.
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-dcr
    /// </summary>
    public class CompositionMdiDcr
    {
        readonly Composition composition;

        internal CompositionMdiDcr(Composition composition)
        {
            this.composition = composition;
        }

        /// <summary>
        /// Factory for CompositionMdiDcrProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-dcr
        /// </summary>
        public static Composition Create(Identifier identifier, CompositionStatus status, Patient subject, Practitioner author)
        {
            var composition = new Composition();
            composition.CompositionMdiDcr().Initialize();

            if (identifier != null) composition.Identifier = identifier;
            composition.Status = status;
            if (subject != null) composition.CompositionMdiDcr().SubjectAsResource = subject;
            if (author != null) composition.CompositionMdiDcr().SetAuthor(author, null);

            return composition;
        }

        /// <summary>
        /// Factory for CompositionMdiDcrProfile with empty parameters
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-dcr
        /// Note: required parameters must be set individually.
        /// </summary>
        public static Composition Create()
        {
            var composition = new Composition();
            composition.CompositionMdiDcr().Initialize();

            return composition;
        }

        private void Initialize()
        {
            AddProfile();
            this.composition.Type = MdiCodeSystem.MdiCodes.DeathCertificateDataReviewDoc;
            this.composition.Title = "Death Certification Data Review Document";
            this.composition.DateElement = FhirDateTime.Now();
            this.composition.Status = CompositionStatus.Final;
        }

        /// <summary>
        /// The official URL for the CompositionMditoEdrsProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-dcr";

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
        /// (string cms-system-url, string cms-caseid)
        /// </summary>
        public (string, string) MdiCaseNumber
        {
            get
            {
                foreach (Extension ext in this.composition.GetExtensions(MdiStructureDefinition.ExtensionTrackingNumberUrl))
                {
                    Coding coding = (ext.Value as Identifier).Type?.Coding?.Find(e => e.System == MdiCodeSystem.MdiCodes.officialUrl && e.Code == MdiCodeSystem.MdiCodes.MdiCaseNumber.Coding[0].Code);
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
                    Url = MdiStructureDefinition.ExtensionTrackingNumberUrl,
                    Value = new Identifier() { Type = MdiCodeSystem.MdiCodes.MdiCaseNumber, System = value.Item1, Value = value.Item2 }
                };
                this.composition.Extension.AddOrUpdateExtension(ext, true);
            }
        }

        /// <summary>
        /// EDRS File Number
        /// (string edrs-system-url, string edrs-caseid)
        /// </summary>
        public (string, string) EdrsFileNumber
        {
            get
            {
                foreach (Extension ext in this.composition.GetExtensions(MdiStructureDefinition.ExtensionTrackingNumberUrl))
                {
                    Coding coding = (ext.Value as Identifier).Type?.Coding?.Find(e => e.System == MdiCodeSystem.MdiCodes.officialUrl && e.Code == MdiCodeSystem.MdiCodes.EdrsFileNumber.Coding[0].Code);
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
                    Url = MdiStructureDefinition.ExtensionTrackingNumberUrl,
                    Value = new Identifier() { Type = MdiCodeSystem.MdiCodes.EdrsFileNumber, System = value.Item1, Value = value.Item2 }
                };
                this.composition.Extension.AddOrUpdateExtension(ext, true);
            }
        }

        /// <summary>
        /// get or set Funeral Home Case Number
        /// </summary>
        public (string, string) FuneralHomeCaseNumber
        {
            get
            {
                foreach (Extension ext in this.composition.GetExtensions(MdiStructureDefinition.ExtensionTrackingNumberUrl))
                {
                    Coding coding = (ext.Value as Identifier).Type?.Coding?.Find(e => e.System == MdiCodeSystem.MdiCodes.officialUrl && e.Code == MdiCodeSystem.MdiCodes.FuneralHomeCaseNumber.Coding[0].Code);
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
                    Url = MdiStructureDefinition.ExtensionTrackingNumberUrl,
                    Value = new Identifier() { Type = MdiCodeSystem.MdiCodes.FuneralHomeCaseNumber, System = value.Item1, Value = value.Item2 }
                };
                this.composition.Extension.AddOrUpdateExtension(ext, true);
            }
        }

        /// <summary>
        /// get and set Death Certificate Status
        /// value = (CodeableConcept deathCertificateCertification, CodeableConcept deathCertificateRegistration)
        /// </summary>
        public (CodeableConcept, CodeableConcept) DeathCertificateStatus
        {
            get
            {
                foreach (Extension ext in this.composition.GetExtensions(MdiStructureDefinition.ExtensionDeathCertificateStatus))
                {
                    Extension extDcCertification = ext.GetExtension("DCcertification");
                    CodeableConcept DcCertification = extDcCertification.Value as CodeableConcept;

                    Extension extDcRegistration = ext.GetExtension("DCregistration");
                    CodeableConcept DcRegistration = extDcRegistration.Value as CodeableConcept;

                    return (DcCertification, DcRegistration);
                }

                return (null, null);
            }
            set
            {
                Extension ext = new()
                {
                    Url = MdiStructureDefinition.ExtensionDeathCertificateStatus,
                };

                Extension extDcCertification = new()
                {
                    Url = "DCcertification",
                    Value = value.Item1
                };

                Extension extDcRegistration = new()
                {
                    Url = "DCregistration",
                    Value = value.Item2
                };

                ext.Extension.AddOrUpdateExtension(extDcCertification, false);
                ext.Extension.AddOrUpdateExtension(extDcRegistration, false);

                this.composition.Extension.AddOrUpdateExtension(ext, true);
            }
        }

        /// <summary>
        /// get and set Cremation Clearance Status
        /// value = (CodeableConcept cremationClearanceStatus)
        /// </summary>
        public CodeableConcept CremationClearanceStatus
        {
            get
            {
                Extension ext = this.composition.GetExtension(MdiStructureDefinition.ExtensionCremationClearanceStatus);
                if (ext != null)
                {
                    return (ext.Value as CodeableConcept);
                }

                return null;
            }
            set
            {
                if (!VsCremationClearanceStatus.CremCRequested.CodingExist(value) &&
                    !VsCremationClearanceStatus.CremCPending.CodingExist(value) &&
                    !VsCremationClearanceStatus.CremCRejected.CodingExist(value) &&
                    !VsCremationClearanceStatus.CremCApproved.CodingExist(value))
                {
                    throw new Exception("The value for Cremation Clearance Status must be either CREM_C_REQUESTED, CREM_C_PENDING, CREM_C_REJECTED, or CREM_C_APPROVED");
                }

                Extension ext = new()
                {
                    Url = MdiStructureDefinition.ExtensionCremationClearanceStatus,
                    Value = value
                };

                this.composition.Extension.AddOrUpdateExtension(ext, false);
            }
        }

        /// <summary>
        /// get and set Medical Examiner Certification Affirmation
        /// value = (CodeableConcept meCertificationAffirmation)
        /// </summary>
        public CodeableConcept MeCertAffirmation
        {
            get
            {
                Extension ext = this.composition.GetExtension(MdiStructureDefinition.ExtensionMeCertificationAffirmation);
                if (ext != null)
                {
                    return (ext.Value as CodeableConcept);
                }

                return null;
            }
            set
            {
                if (!VsMeCertAffirmation.MeAffirmCertificationAffirmed.CodingExist(value) &&
                    !VsMeCertAffirmation.MeAffirmCertificationNotAffirmed.CodingExist(value))
                {
                    throw new Exception("The value for Cremation Clearance Status must be either ME_AFFIRM_CERTIFICATION_AFFIRMED or ME_AFFIRM_CERTIFICATION_NOT_AFFIRMED");
                }

                Extension ext = new()
                {
                    Url = MdiStructureDefinition.ExtensionMeCertificationAffirmation,
                    Value = value
                };

                this.composition.Extension.AddOrUpdateExtension(ext, false);
            }
        }

        /// <summary>
        /// get and set Cremation Clearance Coroner
        /// value = (CodeableConcept cremationClearanceCoroner)
        /// </summary>
        public CodeableConcept CremationClearanceCoroner
        {
            get
            {
                Extension ext = this.composition.GetExtension(MdiStructureDefinition.ExtensionCremationClearanceCoroner);
                if (ext != null)
                {
                    return (ext.Value as CodeableConcept);
                }

                return null;
            }
            set
            {
                if (!VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes.CodingExist(value) &&
                    !VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.No.CodingExist(value) &&
                    !VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Unknown.CodingExist(value))
                {
                    throw new Exception("The value for Cremation Clearance Coroner must be either Yes, No or Unknown");
                }

                Extension ext = new()
                {
                    Url = MdiStructureDefinition.ExtensionCremationClearanceCoroner,
                    Value = value
                };

                this.composition.Extension.AddOrUpdateExtension(ext, false);
            }
        }

        /// <summary>
        /// get and set Cremation Clearance Signature
        /// value = (CodeableConcept clearanceClearanceSignature)
        /// </summary>
        public CodeableConcept CremationClearanceSignature
        {
            get
            {
                Extension ext = this.composition.GetExtension(MdiStructureDefinition.ExtensionCremationClearanceSignature);
                if (ext != null)
                {
                    return (ext.Value as CodeableConcept);
                }

                return null;
            }
            set
            {
                if (!VsSignatureStatus.CremCSigned.CodingExist(value) &&
                    !VsSignatureStatus.CremCUnsigned.CodingExist(value))
                {
                    throw new Exception("The value for Cremation Clearance Signature must be either CREM_C_SIGNED or CREM_C_UNSIGNED");
                }

                Extension ext = new()
                {
                    Url = MdiStructureDefinition.ExtensionCremationClearanceSignature,
                    Value = value
                };

                this.composition.Extension.AddOrUpdateExtension(ext, false);
            }
        }

        public (List<Resource>, CodeableConcept) DecedentDemographics
        {
            get
            {
                return GetSectionAndEntry(MdiDcrCompositionSections.DecedentDemographics);
            }
            set
            {
                SetSectionAndEntry(MdiDcrCompositionSections.DecedentDemographics, value);
            }
        }

        public (List<Resource>, CodeableConcept) DeathInvestigation
        {
            get
            {
                return GetSectionAndEntry(MdiDcrCompositionSections.DeathInvestigation);
            }
            set
            {
                SetSectionAndEntry(MdiDcrCompositionSections.DeathInvestigation, value);
            }
        }

        public (List<Resource>, CodeableConcept) DeathCertification
        {
            get
            {
                return GetSectionAndEntry(MdiDcrCompositionSections.DeathCertification);
            }
            set
            {
                SetSectionAndEntry(MdiDcrCompositionSections.DeathCertification, value);
            }
        }

        public (List<Resource>, CodeableConcept) DecedentDisposition
        {
            get
            {
                return GetSectionAndEntry(MdiDcrCompositionSections.DecedentDisposition);
            }
            set
            {
                SetSectionAndEntry(MdiDcrCompositionSections.DecedentDisposition, value);
            }
        }

        public (List<Resource>, CodeableConcept) DeathCertificateDataReview
        {
            get
            {
                return GetSectionAndEntry(MdiCodeSystem.MdiCodes.DeathCertificateDataReview);
            }
            set
            {
                SetSectionAndEntry(MdiCodeSystem.MdiCodes.DeathCertificateDataReview, value);
            }
        }

        public (List<Resource>, CodeableConcept) CremationClearanceInfo
        {
            get
            {
                return GetSectionAndEntry(MdiCodeSystem.MdiCodes.CremationClearanceInfo);
            }
            set
            {
                SetSectionAndEntry(MdiCodeSystem.MdiCodes.CremationClearanceInfo, value);
            }
        }

        /// <summary>
        /// getSectionAndEntry: Helper function returns gets/adds section and get entry or list empty reason if available
        /// </summary>
        /// <param name="code"></param>
        /// <param name="mdiCodeSystem"></param>
        /// <returns></returns>
        private (List<Resource>, CodeableConcept) GetSectionAndEntry(CodeableConcept mdiDocumentSectionCs)
        {
            SectionComponent sectionComponent = GetOrAddSection(mdiDocumentSectionCs.Coding[0].Code, mdiDocumentSectionCs.Coding[0].Display);
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
                    throw new Exception(reference.Reference + " is not found from resource dictionary");
                }
            }

            return (valueResource, sectionComponent.EmptyReason);
        }

        /// <summary>
        /// setSectionAndEntry: Helper function that sets section and entry or list empty reason if appropriate
        /// </summary>
        /// <param name="code"></param>
        /// <param name="mdiCodeSystem"></param>
        /// <param name="value"></param>
        private void SetSectionAndEntry(CodeableConcept sectionCodeCodeableConcept, (List<Resource>, CodeableConcept) value)
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

            SectionComponent sectionComponent = new() { Code = sectionCodeCodeableConcept, Entry = references };
            if (value.Item2 != null)
            {
                sectionComponent.EmptyReason = value.Item2;
            }

            AddOrUpdateSection(sectionCodeCodeableConcept.Coding[0].Code, sectionCodeCodeableConcept.Coding[0].Display, sectionComponent);
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
            string system = MdiCodeSystem.MdiCodes.officialUrl;
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
            string system = MdiCodeSystem.MdiCodes.officialUrl;
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