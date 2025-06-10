using System;
using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Odh;

public class OdhCodeSystemsValueSets
{
    /// OID for PHIN VADS code systems for ODH
    /// </summary>
    public static CodeableConcept HistoryOfUsualOccupation = new(UriString.LOINC, "21843-8");
    public static CodeableConcept HistoryOfUsualIndustry = new(UriString.LOINC, "21844-6");
    public static CodeableConcept UsualOccupationDuration = new(UriString.LOINC, "74163-7");
    public const string OccupationCdcCensus2010Oid = "urn:oid:2.16.840.1.114222.4.5.314";
    public const string OccupationONETSOCDetailODHOid = "urn:oid:2.16.840.1.114222.4.5.327";
    public const string OccupationCdcCensus2018Oid = "urn:oid:2.16.840.1.114222.4.5.339";
    public const string IndustryCdcCensus2010Oid = "urn:oid:2.16.840.1.114222.4.5.315";
    public const string IndustryONETSOCDetailODHOid = "urn:oid:2.16.840.1.114222.4.5.327";
    public const string IndustryCdcCensus2018Oid = "urn:oid:2.16.840.1.114222.4.5.336";
}
