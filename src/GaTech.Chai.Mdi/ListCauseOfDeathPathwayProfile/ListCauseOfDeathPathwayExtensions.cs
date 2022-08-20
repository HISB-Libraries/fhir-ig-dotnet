﻿using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ListCauseOfDeathPathwayProfile
{
    /// <summary>
    /// Class with List extensions for ListCauseOfDeathPathwayProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/List-cause-of-death-pathway
    /// </summary>
    [Obsolete("Removed from v1.0.0 - CI", true)]
    public static class MdiToEdrsDocumentBundleExtensions
    {
        public static ListCauseOfDeathPathway ListCauseOfDeathPathway(this List list)
        {
            return new ListCauseOfDeathPathway(list);
        }
    }
}
