using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeagueManager : MonoBehaviour {

    public List<GameResults> results = new List<GameResults>();

    public Text tableDisplay;
    public string tableText;

    public League[] leagues = {
        new League(1, "National League", 1),
        new League(2, "League Two", 1),
        new League(3, "League One", 1),
        new League(4, "Championship", 1),
        new League(5, "Premier League", 1)
        };

    public Club[] clubs =
       {
            //National League
            new Club(1, "Aldershot Town", 1, 18, 18, 18),
            new Club(2, "Barrow", 1, 17, 18, 18),
            new Club(3, "Boreham Wood", 1, 17, 16, 16),
            new Club(4, "Braintree Town", 1, 11, 11, 11),
            new Club(5, "Bromley", 1, 17, 18, 15),
            new Club(6, "Chester", 1, 12, 12, 11),
            new Club(7, "Dagenham & Redbridge", 1, 19, 20, 16),
            new Club(8, "Dover Athletic", 1, 20, 18, 14),
            new Club(9, "Eastleigh", 1, 14, 13, 13),
            new Club(10, "Forest Green Rovers", 1, 20, 19, 18),
            new Club(11, "Gateshead", 1, 17, 17, 17),
            new Club(12, "Guiseley", 1, 12, 12, 11),
            new Club(13, "Lincoln City", 1, 20, 20, 20),
            new Club(14, "Macclesfield Town", 1, 17, 18, 15),
            new Club(15, "Maidstone United", 1, 15, 13, 12),
            new Club(16, "North Ferriby United", 1, 10, 10, 10),
            new Club(17, "Solihull Moors", 1, 13, 12, 13),
            new Club(18, "Southport", 1, 10, 11, 10),
            new Club(19, "Sutton United", 1, 15, 15, 15),
            new Club(20, "Torquay United", 1, 12, 13, 14),
            new Club(21, "Tranmere Rovers", 1, 19, 20, 20),
            new Club(22, "Woking", 1, 12, 12, 12),
            new Club(23, "Wrexham", 1, 15, 15, 14),
      //      new Club(24, "York City", 1, 11, 12, 11),
            new Club(24, "Chelsea", 1, 98, 97, 98)
        };

    private void Start()
    {
        //Add results dummy
        //addResult(1, 2, 3, 0, 1);
        //addResult(3, 4, 4, 0, 1);
        //addResult(5, 6, 6, 0, 1);
        //addResult(7, 8, 5, 0, 1);
        //addResult(9, 10, 8, 0, 1);
    }

    private void Update()
    {
        //tableDisplay.text = "Position | Team | P | W | D | L | F | A | GD | PTS" + tableText;
        //printTable(1);
    }

    public string getTeamName(int teamID)
    {
        for (int i = 0; i < clubs.Length; i++)
        {
            if(clubs[i].TeamID == teamID)
            {
                return clubs[i].TeamName;
            }
        }

        return null;
    }

    public int getGamesPlayed(int teamID)
    {
        int gamesPlayed = 0;

        foreach (GameResults result in results)
        {
            if (result.TeamA == teamID || result.TeamB == teamID)
                gamesPlayed++;
        }

        return gamesPlayed;
    }

    public int getGamesWon(int teamID)
    {
        int gamesWon = 0;

        foreach (GameResults result in results)
        {
            if (result.TeamA == teamID)
                if (result.HomeGoals > result.AwayGoals)
                    gamesWon++;

            if (result.TeamB == teamID)
                if (result.AwayGoals > result.HomeGoals)
                    gamesWon++;
        }

        return gamesWon;
    }

    public int getGamesDraw(int teamID)
    {
        int gamesDraw = 0;

        foreach (GameResults result in results)
        {
            if (result.TeamA == teamID || result.TeamB == teamID)
                if (result.HomeGoals == result.AwayGoals)
                    gamesDraw++;
        }

        return gamesDraw;
    }

    public int getGamesLost(int teamID)
    {
        int gamesLost = 0;

        foreach (GameResults result in results)
        {
            if (result.TeamA == teamID)
                if (result.HomeGoals < result.AwayGoals)
                    gamesLost++;

            if (result.TeamB == teamID)
                if (result.AwayGoals < result.HomeGoals)
                    gamesLost++;
        }

        return gamesLost;
    }

    public int getGoalsScored(int teamID)
    {
        int goalsScored = 0;

        foreach (GameResults result in results)
        {
            if (result.TeamA == teamID)
                goalsScored = goalsScored + result.HomeGoals;

            if (result.TeamB == teamID)
                goalsScored = goalsScored + result.AwayGoals;

        }

        return goalsScored;
    }

    public int getGoalsAgainst(int teamID)
    {
        int goalsAgainst = 0;

        foreach (GameResults result in results)
        {
            if (result.TeamA == teamID)
                goalsAgainst = goalsAgainst + result.AwayGoals;

            if (result.TeamB == teamID)
                goalsAgainst = goalsAgainst + result.HomeGoals;

        }

        return goalsAgainst;
    }

    public int getGoalDifference(int teamID)
    {
        return getGoalsScored(teamID) - getGoalsAgainst(teamID);
    }

    public int getPoints(int teamID)
    {
        return getGamesWon(teamID) * 3 + getGamesDraw(teamID);
    }

    public void addResult(int teamA, int teamB, int homeGoals, int awayGoals, int season)
    {
        results.Add(new GameResults(teamA, teamB, homeGoals, awayGoals, season));
    }
}
