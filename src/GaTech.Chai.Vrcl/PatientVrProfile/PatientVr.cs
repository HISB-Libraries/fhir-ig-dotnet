using System;
using System.Collections.Generic;
using GaTech.Chai.Share.Common;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.UsCore.PatientProfile;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrcl.PatientVrProfile
{
	public class PatientVr
	{
		readonly Patient patient;
        readonly PatientVrBirthPlace birthPlace;
        readonly PatientVrParentReportedAgeAtDelivery parentReportedAgeAtDelivery;

        internal PatientVr(Patient patient)
		{
			this.patient = patient;
            this.birthPlace = new PatientVrBirthPlace(patient);
            this.parentReportedAgeAtDelivery = new PatientVrParentReportedAgeAtDelivery(patient);
		}

		public static Patient Create()
		{
			var patient = new Patient();
            patient.PatientVr().AddProfile();

			return patient;
		}

        public const string ProfileUrl = "http://hl7.org/fhir/us/vr-common-library/StructureDefinition/Patient-vr";

        public void AddProfile()
        {
            this.patient.AddProfile(ProfileUrl);
        }

        public void RemoveProfile()
        {
            this.patient.RemoveProfile(ProfileUrl);
        }

        public PatientVrBirthPlace BirthPlace => birthPlace;

        public PatientVrParentReportedAgeAtDelivery ParentReportedAgeAtDelivery => parentReportedAgeAtDelivery;

        public string MRN
        {
            set
            {
                this.patient.Identifier.AddOrUpdateIdentifier(Hl7V2Tables.V20203.MRN, value);
            }
            get
            {
                return this.patient.Identifier.GetIdentifier(Hl7V2Tables.V20203.MRN)?.Value;
            }
        }

        public string SSN
        {
            set
            {
                this.patient.Identifier.AddOrUpdateIdentifier(Hl7V2Tables.V20203.SS, UriString.UsSsnUri, value);
            }
            get
            {
                List<Identifier> _identifiers = this.patient.Identifier.GetIdentifiers(Hl7V2Tables.V20203.SS);
                var id = _identifiers.Find(c => c.System == UriString.UsSsnUri);
                if (id != null)
                {
                    return id.Value;
                }

                return null;
            }
        }

        public Coding RaceCategory
        {
            set
            {
                this.patient.UsCorePatient().Race.Category = value;
            }
            get
            {
                return this.patient.UsCorePatient().Race.Category;
            }
        }

        public List<Coding> RaceExtendedRaceCodes
        {
            set
            {
                this.patient.UsCorePatient().Race.ExtendedRaceCodes = value;
            }
            get
            {
                return (List<Coding>)this.patient.UsCorePatient().Race.ExtendedRaceCodes;
            }
        }

        public string RaceText
        {
            set
            {
                this.patient.UsCorePatient().Race.RaceText = value;
            }
            get
            {
                return this.patient.UsCorePatient().Race.RaceText;
            }
        }

        public Coding EthnicityCategory
        {
            set
            {
                this.patient.UsCorePatient().Ethnicity.Category = value;
            }
            get
            {
                return this.patient.UsCorePatient().Ethnicity.Category;
            }
        }

        public List<Coding> EthnicityExtendedRaceCodes
        {
            set
            {
                this.patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = value;
            }
            get
            {
                return (List<Coding>)this.patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes;
            }
        }

        public string EthnicityText
        {
            set
            {
                this.patient.UsCorePatient().Ethnicity.EthnicityText = value;
            }
            get
            {
                return this.patient.UsCorePatient().Ethnicity.EthnicityText;
            }
        }

        public Code BirthSexExtensionCode
        {
            set
            {
                this.patient.UsCorePatient().BirthSex.Extension = value;
            }
            get
            {
                return this.patient.UsCorePatient().BirthSex.Extension;
            }
        }
    }
}

