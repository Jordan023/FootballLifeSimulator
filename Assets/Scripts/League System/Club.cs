using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club {
    int teamID;
    string teamName;

    int leagueID;

    int defRating;
    int midRating;
    int attRating;

    public int TeamID
    {
        get { return teamID; }
        set { teamID = value; }
    }
    public string TeamName
    {
        get { return teamName; }
        set { teamName = value; }
    }
    public int LeagueID
    {
        get { return leagueID; }
        set { leagueID = value; }
    }
    public int DefRating
    {
        get { return defRating; }
        set { defRating = value; }
    }
    public int MidRating
    {
        get { return midRating; }
        set { midRating = value; }
    }
    public int AttRating
    {
        get { return attRating; }
        set { attRating = value; }
    }

    public Club(int teamID, string teamName, int leagueID, int defRating, int midRating, int attRating)
    {
        this.TeamID = teamID;
        this.TeamName = teamName;
        this.LeagueID = leagueID;
        this.DefRating = defRating;
        this.MidRating = midRating;
        this.AttRating = attRating;
    }

    public int getOverallRating()
    {
        return (DefRating + MidRating + AttRating) / 3;
    }
}
