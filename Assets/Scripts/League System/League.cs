using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class League {

    private int leagueID;
    private string leagueName;
    private int countryID;

    public int LeagueID
    {
        get { return leagueID; }
        set { leagueID = value; }
    }
    public string LeagueName
    {
        get { return leagueName; }
        set { leagueName = value; }
    }
    public int CountryID
    {
        get { return countryID; }
        set { countryID = value; }
    }

    public League(int leagueID, string leagueName, int countryID)
    {
        this.LeagueID = leagueID;
        this.LeagueName = leagueName;
        this.CountryID = countryID;
    }
}
