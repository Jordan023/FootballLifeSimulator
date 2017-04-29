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
            new Club(1, "Aldershot Town", 1, 10, 10, 10),
            new Club(2, "Barrow", 1, 10, 10, 10),
            new Club(3, "Boreham Wood", 1, 10, 10, 10),
            new Club(4, "Braintree Town", 1, 10, 10, 10),
            new Club(5, "Bromley", 1, 10, 10, 10),
            new Club(6, "Chester", 1, 10, 10, 10),
            new Club(7, "Dagenham & Redbridge", 1, 10, 10, 10),
            new Club(8, "Dover Athletic", 1, 10, 10, 10),
            new Club(9, "Eastleigh", 1, 10, 10, 10),
            new Club(10, "Forest Green Rovers", 1, 10, 10, 10),
            new Club(11, "Gateshead", 1, 10, 10, 10),
            new Club(12, "Guiseley", 1, 10, 10, 10),
            new Club(13, "Lincoln City", 1, 10, 10, 10),
            new Club(14, "Macclesfield Town", 1, 10, 10, 10),
            new Club(15, "Maidstone United", 1, 10, 10, 10),
            new Club(16, "North Ferriby United", 1, 10, 10, 10),
            new Club(17, "Solihull Moors", 1, 10, 10, 10),
            new Club(18, "Southport", 1, 10, 10, 10),
            new Club(19, "Sutton United", 1, 10, 10, 10),
            new Club(20, "Torquay United", 1, 10, 10, 10),
            new Club(21, "Tranmere Rovers", 1, 10, 10, 10),
            new Club(22, "Woking", 1, 10, 10, 10),
            new Club(23, "Wrexham", 1, 10, 10, 10),
            new Club(24, "York City", 1, 10, 10, 10),
        };

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

    public void addResult(int teamA, int teamB, int homeGoals, int awayGoals, int season)
    {
        results.Add(new GameResults(teamA, teamB, homeGoals, awayGoals, season));
    }
}
