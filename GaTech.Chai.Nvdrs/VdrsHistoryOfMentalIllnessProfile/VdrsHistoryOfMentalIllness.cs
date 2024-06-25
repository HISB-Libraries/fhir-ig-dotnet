﻿using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Nvdrs;

public class VdrsHistoryOfMentalIllness
{
    readonly Observation observation;

    internal VdrsHistoryOfMentalIllness(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new()
        {
            Code = NvdrsCustomCs.HistoryOfMentalIllness
        };

        observation.VdrsHistoryOfMentalIllness().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/vdrs-history-of-mental-illness";

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

}
