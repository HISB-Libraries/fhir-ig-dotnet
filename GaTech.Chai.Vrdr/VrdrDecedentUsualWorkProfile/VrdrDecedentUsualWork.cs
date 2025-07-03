using GaTech.Chai.Share;
using GaTech.Chai.Vrcl;
using Hl7.Fhir.Model;
using GaTech.Chai.Odh;
using System;
using System.Collections.Generic;

namespace GaTech.Chai.Vrdr;

public class VrdrDecedentUsualWork
{
    readonly Observation observation;

    internal VrdrDecedentUsualWork(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = OdhUsualWork.Create();
        observation.OdhUsualWork().RemoveProfile();
        observation.VrdrDecedentUsualWork().AddProfile();

        return observation;
    }

    public static Observation Create(Patient patient)
    {
        Observation observation = new();
        observation.VrdrDecedentUsualWork().AddProfile();
        observation.VrdrDecedentUsualWork().SubjectAsResource = patient;

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-decedent-usual-work";

    public void AddProfile()
    {
        this.observation.AddProfile(ProfileUrl);
    }

    public void RemoveProfile()
    {
        this.observation.RemoveProfile(ProfileUrl);
    }

   public Patient SubjectAsResource
    {
        get
        {
        Record.GetResources().TryGetValue(this.observation.Subject.Reference, out Resource value);

        return (Patient)value;
        }
        set
        {
            this.observation.Subject = value.AsReference();
            Record.GetResources()[value.AsReference().Reference] = value;
        }
    }

    public Coding OccupationCdcCensus2018
    {
        get
        {
            return this.observation.OdhUsualWork().OccupationCdcCensus2018;
        }
        set
        {
            this.observation.OdhUsualWork().OccupationCdcCensus2018 = value;
        }
    }

    public Coding OccupationCdcSoc2018
    {
        get
        {
            return (this.observation.Value as CodeableConcept)?.Coding?.Find(c => c.System == VrdrCodeSystemsValueSets.OccupationCdcSoc2018Oid);
        }
        set
        {
            if (value.System != VrdrCodeSystemsValueSets.OccupationCdcSoc2018Oid)
            {
                throw (new ArgumentException("System must be " + VrdrCodeSystemsValueSets.OccupationCdcSoc2018Oid));
            }

            Coding coding = (this.observation.Value as CodeableConcept)?.Coding?.Find(c => c.System == VrdrCodeSystemsValueSets.OccupationCdcSoc2018Oid);
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

    public Coding IndustryCDCCensus2018
    {
        get
        {
            return this.observation.OdhUsualWork().IndustryCdcCensus2018;
        }
        set
        {
            this.observation.OdhUsualWork().IndustryCdcCensus2018 = value;
        }
    }

    public Coding IndustryCDCNaics2017
    {
        get
        {
            return (this.observation.Value as CodeableConcept)?.Coding?.Find(c => c.System == VrdrCodeSystemsValueSets.IndustryCdcNaics2017Oid);
        }
        set
        {
            if (value.System != VrdrCodeSystemsValueSets.IndustryCdcNaics2017Oid)
            {
                throw (new ArgumentException("System must be " + VrdrCodeSystemsValueSets.IndustryCdcNaics2017Oid));
            }

            Coding coding = (this.observation.Value as CodeableConcept)?.Coding?.Find(c => c.System == VrdrCodeSystemsValueSets.IndustryCdcNaics2017Oid);
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
}

