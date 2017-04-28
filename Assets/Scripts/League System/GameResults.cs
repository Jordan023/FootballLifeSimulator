using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResults {

    private int teamA;
    private int teamB;
    private int homeGoals;
    private int awayGoals;
    private int season;

    public int TeamA
    {
        get { return teamA; }
        set { teamA = value; }
    }
    public int TeamB
    {
        get { return teamB; }
        set { teamB = value; }
    }
    public int HomeGoals
    {
        get { return homeGoals; }
        set { homeGoals = value; }
    }
    public int AwayGoals
    {
        get { return awayGoals; }
        set { awayGoals = value; }
    }
    public int Season
    {
        get { return season; }
        set { season = value; }
    }

    public GameResults(int teamA, int teamB, int homeGoals, int awayGoals, int season)
    {
        this.TeamA = teamA;
        this.TeamB = teamB;
        this.HomeGoals = homeGoals;
        this.AwayGoals = awayGoals;
        this.Season = season;
    }
}
