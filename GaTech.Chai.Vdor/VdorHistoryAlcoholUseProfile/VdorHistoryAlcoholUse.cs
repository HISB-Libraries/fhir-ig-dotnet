using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using static GaTech.Chai.Vrcl.VrclCodeSystemsValueSets;

namespace GaTech.Chai.Vdor;

public class VdorHistoryAlcoholUse
{
    readonly Observation observation;

    internal VdorHistoryAlcoholUse(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = VdorCircumstances.Create();
        observation.VdorCircumstances().RemoveProfile();
        observation.Code = new CodeableConcept(UriString.LOINC, "11331-6", "History of Alcohol Use", "");

        observation.VdorHistoryAlcoholUse().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-history-alcohol-use";

    /// <summary>
    /// Set profile for the Nvdrs Current Depressed Mood
    /// </summary>
    public void AddProfile()
    {
        this.observation.AddProfile(ProfileUrl);
    }

    /// <summary>
    /// Clear profile for the Nvdrs Current Depressed Mood
    /// </summary>
    public void RemoveProfile()
    {
        this.observation.RemoveProfile(ProfileUrl);
    }

    public CodeableConcept? ValueOfHistoryAlcoholUse
    {
        get { return this.observation.Value as CodeableConcept; }
        set 
        { 
            if (VrclValueSetYesNoUnknownNotApplicableVr.Yes.Matches(value) 
                || VrclValueSetYesNoUnknownNotApplicableVr.No.Matches(value) 
                || VrclValueSetYesNoUnknownNotApplicableVr.Unknown.Matches(value) 
                || VrclValueSetYesNoUnknownNotApplicableVr.NotApplicable.Matches(value))
            {
                this.observation.Value = value; 
            }
            else
            {
                throw new ArgumentException($"Value must be one of the following: {VrclValueSetYesNoUnknownNotApplicableVr.Yes.Coding[0].Display}, {VrclValueSetYesNoUnknownNotApplicableVr.No.Coding[0].Display}, {VrclValueSetYesNoUnknownNotApplicableVr.Unknown.Coding[0].Display}, {VrclValueSetYesNoUnknownNotApplicableVr.NotApplicable.Coding[0].Display}");
            }
        }
    }
}
