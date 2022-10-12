using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Share.Common
{
    public class CodeSystems
    {
        public class ObservationCategory
        {
            public static string officialUrl = "http://terminology.hl7.org/CodeSystem/observation-category";

            public static Coding SocialHistory = new (officialUrl, "social-history", "Social History");
            public static Coding VitalSigns = new (officialUrl, "vital-signs", "Vital Signs");
            public static Coding Imaging = new(officialUrl, "imaging", "Imaging");
            public static Coding Laboratory = new(officialUrl, "laboratory", "Laboratory");
            public static Coding Procedure = new(officialUrl, "procedure", "Procedure");
            public static Coding Survey = new(officialUrl, "survey", "Survey");
            public static Coding Exam = new(officialUrl, "exam", "Exam");
            public static Coding Therapy = new(officialUrl, "therapy", "Therapy");
            public static Coding Activity = new(officialUrl, "activity", "Activity");
        }
    }
}

