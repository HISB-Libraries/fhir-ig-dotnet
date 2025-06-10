using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using System.Collections.Generic;

namespace GaTech.Chai.Odh
{
    /// <summary>
    /// UsualWorkProfile
    /// http://hl7.org/fhir/us/odh/StructureDefinition/odh-UsualWork
    /// </summary>
    public class OdhUsualWork
    {
        readonly Observation observation;

        internal OdhUsualWork(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Factory for ODH Profile
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.Category.SetCategory(new Coding("http://terminology.hl7.org/CodeSystem/observation-category", "social-history"));
            observation.Code = OdhCodeSystemsValueSets.HistoryOfUsualOccupation;
            observation.OdhUsualWork().AddProfile();

            return observation;
        }

        /// <summary>
        /// The official URL for UsualWorkProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/odh/StructureDefinition/odh-UsualWork";

        /// <summary>
        /// Set profile for UsualWorkProfile
        /// </summary>
        public void AddProfile()
        {
            observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for UsualWorkProfile
        /// </summary>
        public void RemoveProfile()
        {
            observation.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Occupation CDC Census 2010 value. Only one coding is allowed.
        /// </summary>
        public Coding OccupationCdcCensus2010
        {
            get
            {
                return (this.observation.Value as CodeableConcept)?.Coding?.Find(c => c.System == OdhCodeSystemsValueSets.OccupationCdcCensus2010Oid);
            }
            set
            {
                if (value.System != OdhCodeSystemsValueSets.OccupationCdcCensus2010Oid)
                {
                    throw (new ArgumentException("System must be " + OdhCodeSystemsValueSets.OccupationCdcCensus2010Oid));
                }

                Coding coding = (this.observation.Value as CodeableConcept)?.Coding?.Find(c => c.System == OdhCodeSystemsValueSets.OccupationCdcCensus2010Oid);
                if (coding == null)
                {
                    CodeableConcept valueCodeable = this.observation.Value as CodeableConcept;
                    if (valueCodeable == null)
                    {
                        this.observation.Value = new CodeableConcept() { Coding = new List<Coding> { value } };
                    }
                    else
                    {
                        valueCodeable.Coding.Add(value);
                    }
                }
                else
                {
                    coding.Code = value.Code;
                    coding.Display = value.Display;
                }
            }
        }

        /// <summary>
        /// Occupation ONETSOC Detail. Only one coding is allowed.
        /// </summary>
        public Coding OccupationONETSOCDetailODH
        {
            get
            {
                return (this.observation.Value as CodeableConcept)?.Coding?.Find(c => c.System == OdhCodeSystemsValueSets.OccupationONETSOCDetailODHOid);
            }
            set
            {
                if (value.System != OdhCodeSystemsValueSets.OccupationONETSOCDetailODHOid)
                {
                    throw (new ArgumentException("System must be " + OdhCodeSystemsValueSets.OccupationONETSOCDetailODHOid));
                }

                Coding coding = (this.observation.Value as CodeableConcept)?.Coding?.Find(c => c.System == OdhCodeSystemsValueSets.OccupationONETSOCDetailODHOid);
                if (coding == null)
                {
                    CodeableConcept valueCodeable = this.observation.Value as CodeableConcept;
                    if (valueCodeable == null)
                    {
                        this.observation.Value = new CodeableConcept() { Coding = new List<Coding> { value } };
                    }
                    else
                    {
                        valueCodeable.Coding.Add(value);
                    }
                }
                else
                {
                    coding.Code = value.Code;
                    coding.Display = value.Display;
                }
            }
        }

        public Coding OccupationCdcCensus2018
        {
            get
            {
                return (this.observation.Value as CodeableConcept)?.Coding?.Find(c => c.System == OdhCodeSystemsValueSets.OccupationCdcCensus2018Oid);
            }
            set
            {
                if (value.System != OdhCodeSystemsValueSets.OccupationCdcCensus2018Oid)
                {
                    throw (new ArgumentException("System must be " + OdhCodeSystemsValueSets.OccupationCdcCensus2010Oid));
                }

                Coding coding = (this.observation.Value as CodeableConcept)?.Coding?.Find(c => c.System == OdhCodeSystemsValueSets.OccupationCdcCensus2018Oid);
                if (coding == null)
                {
                    CodeableConcept valueCodeable = this.observation.Value as CodeableConcept;
                    if (valueCodeable == null)
                    {
                        this.observation.Value = new CodeableConcept() { Coding = new List<Coding> { value } };
                    }
                    else
                    {
                        valueCodeable.Coding.Add(value);
                    }
                }
                else
                {
                    coding.Code = value.Code;
                    coding.Display = value.Display;
                }
            }
        }

        /// <summary>
        /// Usual Industry component
        /// </summary>
        public CodeableConcept OdhUsualIndustry
        {
            get
            {
                Observation.ComponentComponent component = this.observation.Component.GetComponent(OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].System, OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].Code);
                if (component != null)
                {
                    return component.Value as CodeableConcept;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].System, OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].Code, null);
                component.Value = value;
            }
        }

        public Coding IndustryCdcCensus2010
        {
            get
            {
                Observation.ComponentComponent component = this.observation.Component.GetComponent(OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].System, OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].Code);
                if (component != null)
                {
                    return (component.Value as CodeableConcept)?.Coding?.Find(c => c.System == OdhCodeSystemsValueSets.IndustryCdcCensus2010Oid);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value.System != OdhCodeSystemsValueSets.IndustryCdcCensus2010Oid)
                {
                    throw (new ArgumentException("System must be " + OdhCodeSystemsValueSets.IndustryCdcCensus2010Oid));
                }

                Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].System, OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].Code, null);
                Coding coding = (component.Value as CodeableConcept)?.Coding?.Find(c => c.System == OdhCodeSystemsValueSets.IndustryCdcCensus2010Oid);
                if (coding == null)
                {
                    component.Value = new CodeableConcept() { Coding = new List<Coding> { value } };
                }
                else
                {
                    (component.Value as CodeableConcept).Coding.Add(value);
                }
            }
        }

        public Coding IndustryONETSOCDetailODH
        {
            get
            {
                Observation.ComponentComponent component = this.observation.Component.GetComponent(OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].System, OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].Code);
                if (component != null)
                {
                    return (component.Value as CodeableConcept)?.Coding?.Find(c => c.System == OdhCodeSystemsValueSets.IndustryONETSOCDetailODHOid);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value.System != OdhCodeSystemsValueSets.IndustryONETSOCDetailODHOid)
                {
                    throw (new ArgumentException("System must be " + OdhCodeSystemsValueSets.IndustryONETSOCDetailODHOid));
                }

                Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].System, OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].Code, null);
                Coding coding = (component.Value as CodeableConcept)?.Coding?.Find(c => c.System == OdhCodeSystemsValueSets.IndustryONETSOCDetailODHOid);
                if (coding == null)
                {
                    component.Value = new CodeableConcept() { Coding = new List<Coding> { value } };
                }
                else
                {
                    (component.Value as CodeableConcept).Coding.Add(value);
                }
            }
        }

        public Coding IndustryCdcCensus2018
        {
            get
            {
                Observation.ComponentComponent component = this.observation.Component.GetComponent(OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].System, OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].Code);
                if (component != null)
                {
                    return (component.Value as CodeableConcept)?.Coding?.Find(c => c.System == OdhCodeSystemsValueSets.IndustryCdcCensus2018Oid);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value.System != OdhCodeSystemsValueSets.IndustryCdcCensus2018Oid)
                {
                    throw (new ArgumentException("System must be " + OdhCodeSystemsValueSets.IndustryCdcCensus2018Oid));
                }

                Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].System, OdhCodeSystemsValueSets.HistoryOfUsualIndustry.Coding[0].Code, null);
                Coding coding = (component.Value as CodeableConcept)?.Coding?.Find(c => c.System == OdhCodeSystemsValueSets.IndustryCdcCensus2018Oid);
                if (coding == null)
                {
                    component.Value = new CodeableConcept() { Coding = new List<Coding> { value } };
                }
                else
                {
                    (component.Value as CodeableConcept).Coding.Add(value);
                }
            }
        }

        /// <summary>
        /// Usual Occupation Duration component
        /// <summary>
        public Decimal? UsualOccupationDuration
        {
            get
            {
                return (this.observation.Component?.GetComponent(OdhCodeSystemsValueSets.UsualOccupationDuration.Coding[0].System, OdhCodeSystemsValueSets.UsualOccupationDuration.Coding[0].Code)?.Value as Quantity)?.Value;
            }
            set
            {
                Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(OdhCodeSystemsValueSets.UsualOccupationDuration.Coding[0].System, OdhCodeSystemsValueSets.UsualOccupationDuration.Coding[0].Code, null);
                component.Value = new Quantity() { System = UriString.UnitsOfMeasure, Code = "a", Unit = "year", Value = value };
            }
        }

        /// <summary>
        /// UsualOccupationDuration's reference range property
        /// </summary>
        public CodeableConcept UsualOccupationDurationReferenceType
        {
            get
            {
                return this.observation.Component?.GetComponent(OdhCodeSystemsValueSets.UsualOccupationDuration.Coding[0].System, OdhCodeSystemsValueSets.UsualOccupationDuration.Coding[0].Code)?.ReferenceRange?[0].Type;
            }
            set
            {
                Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(OdhCodeSystemsValueSets.UsualOccupationDuration.Coding[0].System, OdhCodeSystemsValueSets.UsualOccupationDuration.Coding[0].Code, null);
                if (component.ReferenceRange == null)
                {
                    component.ReferenceRange = new List<Observation.ReferenceRangeComponent> { new Observation.ReferenceRangeComponent() { Type = value } };
                }
                else
                {
                    component.ReferenceRange[0].Type = value;
                }
            }
        }
        public CodeableConcept UsualOccupationDurationReferenceAppliesTo
        {
            get
            {
                return this.observation.Component?.GetComponent(OdhCodeSystemsValueSets.UsualOccupationDuration.Coding[0].System, OdhCodeSystemsValueSets.UsualOccupationDuration.Coding[0].Code)?.ReferenceRange?[0].AppliesTo?[0];
            }
            set
            {
                Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(OdhCodeSystemsValueSets.UsualOccupationDuration.Coding[0].System, OdhCodeSystemsValueSets.UsualOccupationDuration.Coding[0].Code, null);
                if (component.ReferenceRange == null)
                {
                    component.ReferenceRange = new List<Observation.ReferenceRangeComponent> { new Observation.ReferenceRangeComponent() { AppliesTo = new List<CodeableConcept> { value } } };
                }
                else
                {
                    component.ReferenceRange[0].AppliesTo = new List<CodeableConcept> { value };
                }
            }
        }
    }
}