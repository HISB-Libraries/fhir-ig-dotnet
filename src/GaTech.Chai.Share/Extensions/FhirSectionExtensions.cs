using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;

namespace GaTech.Chai.FhirIg.Extensions
{
    /// <summary>
    /// Composition section extension for FHIR Composition.section
    /// </summary>
    public static class FhirSectionExtensions
    {
        public static void AddOrUpdateSection(this List<Composition.SectionComponent> sections,
            string system, string code, string title, string display,
            Composition.SectionComponent section)
        {
            section.Title = title;

            bool? isExist = section.Code?.Coding?.Exists(c => c.System == system && c.Code == code);
            if (isExist == null)
                section.Code = new CodeableConcept(system, code, display, null);
            else if (isExist == false)
                section.Code.Coding.Add(new Coding() { System = system, Code = code, Display = display });
            var s = sections.GetSection(system, code);
            if (s != null)
                sections.Remove(s);
            sections.Add(section);
        }

        public static Composition.SectionComponent GetSection(this List<Composition.SectionComponent> sections,
                string system, string code)
        {
            return sections.Find(i => i.Code?.Coding?.Exists(c => c.System == system && c.Code == code) == true);
        }

        public static Composition.SectionComponent GetOrAddSection(this List<Composition.SectionComponent> sections,
            string system, string code, string title, string display)
        {
            var section = sections.GetSection(system, code);
            if (section == null)
            {
                section = new Composition.SectionComponent();
                sections.Add(section);
                section.Code = new CodeableConcept();
                section.Code.Coding.Add(new Coding() { System = system, Code = code, Display = display });
            }
            section.Title = title;
            return section;
        }
    }
}
