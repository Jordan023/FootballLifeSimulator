using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ScoreManager : MonoBehaviour {
    
    Dictionary<string, Dictionary<string, int>> league_1;
    Dictionary<string, Dictionary<string, int>> league_2;
    Dictionary<string, Dictionary<string, int>> league_3;
    Dictionary<string, Dictionary<string, int>> league_4;
    Dictionary<string, Dictionary<string, int>> league_5;
    public PlayerManager playerManager;
    public LeagueManager leagueManager;
    public bool nextWeek = true;

    int changeCounter = 0;

    void Update()
    {
        if (nextWeek)
        {
            for (int i = 0; i < leagueManager.clubs.Length; i++)
            {
                    setScore(leagueManager.clubs[i].TeamName, "played", leagueManager.getGamesPlayed(leagueManager.clubs[i].TeamID), leagueManager.clubs[i].LeagueID);
                    setScore(leagueManager.clubs[i].TeamName, "won", leagueManager.getGamesWon(leagueManager.clubs[i].TeamID), leagueManager.clubs[i].LeagueID);
                    setScore(leagueManager.clubs[i].TeamName, "draw", leagueManager.getGamesDraw(leagueManager.clubs[i].TeamID), leagueManager.clubs[i].LeagueID);
                    setScore(leagueManager.clubs[i].TeamName, "lost", leagueManager.getGamesLost(leagueManager.clubs[i].TeamID), leagueManager.clubs[i].LeagueID);
                    setScore(leagueManager.clubs[i].TeamName, "goalsHome", leagueManager.getGoalsScored(leagueManager.clubs[i].TeamID), leagueManager.clubs[i].LeagueID);
                    setScore(leagueManager.clubs[i].TeamName, "goalsAway", leagueManager.getGoalsAgainst(leagueManager.clubs[i].TeamID), leagueManager.clubs[i].LeagueID);
                    setScore(leagueManager.clubs[i].TeamName, "goalsDifference", leagueManager.getGoalDifference(leagueManager.clubs[i].TeamID), leagueManager.clubs[i].LeagueID);
                    setScore(leagueManager.clubs[i].TeamName, "points", leagueManager.getPoints(leagueManager.clubs[i].TeamID), leagueManager.clubs[i].LeagueID);
            }
            nextWeek = false;
        }
    }

    void Init()
    {
        if (league_1 != null && league_2 != null && league_3 != null && league_4 != null && league_5 != null)
            return;

        league_1 = new Dictionary<string, Dictionary<string, int>>();
        league_2 = new Dictionary<string, Dictionary<string, int>>();
        league_3 = new Dictionary<string, Dictionary<string, int>>();
        league_4 = new Dictionary<string, Dictionary<string, int>>();
        league_5 = new Dictionary<string, Dictionary<string, int>>();
    }

    public void resetLists()
    {
        league_1.Clear();
        league_2.Clear();
        league_3.Clear();
        league_4.Clear();
        league_5.Clear();
    }

    public int getScore(string team, string scoreType, int leagueID)
    {
        Init();

        switch (leagueID)
        {
            case 1:
                if (league_1.ContainsKey(team) == false || league_1[team].ContainsKey(scoreType) == false)
                {
                    return 0;
                }

                return league_1[team][scoreType];
            case 2:
                if (league_2.ContainsKey(team) == false || league_2[team].ContainsKey(scoreType) == false)
                {
                    return 0;
                }

                return league_2[team][scoreType];
            case 3:
                if (league_3.ContainsKey(team) == false || league_3[team].ContainsKey(scoreType) == false)
                {
                    return 0;
                }

                return league_3[team][scoreType];
            case 4:
                if (league_4.ContainsKey(team) == false || league_4[team].ContainsKey(scoreType) == false)
                {
                    return 0;
                }

                return league_4[team][scoreType];
            case 5:
                if (league_5.ContainsKey(team) == false || league_5[team].ContainsKey(scoreType) == false)
                {
                    return 0;
                }

                return league_5[team][scoreType];
        }

        return 0;
    }

    public void setScore(string team, string scoreType, int value, int leagueID)
    {
        Init();

        changeCounter++;

        switch (leagueID)
        {
            case 1:
                if (league_1.ContainsKey(team) == false)
                {
                    league_1[team] = new Dictionary<string, int>();
                }

                league_1[team][scoreType] = value;
                break;
            case 2:
                if (league_2.ContainsKey(team) == false)
                {
                    league_2[team] = new Dictionary<string, int>();
                }

                league_2[team][scoreType] = value;
                break;
            case 3:
                if (league_3.ContainsKey(team) == false)
                {
                    league_3[team] = new Dictionary<string, int>();
                }

                league_3[team][scoreType] = value;
                break;
            case 4:
                if (league_4.ContainsKey(team) == false)
                {
                    league_4[team] = new Dictionary<string, int>();
                }

                league_4[team][scoreType] = value;
                break;
            case 5:
                if (league_5.ContainsKey(team) == false)
                {
                    league_5[team] = new Dictionary<string, int>();
                }

                league_5[team][scoreType] = value;
                break;
        }
    }

    public void changeScore(string team, string scoreType, int amount, int leagueID)
    {
        Init();
        int currScore = getScore(team, scoreType, leagueID);
        setScore(team, scoreType, currScore + amount, leagueID);
    }

    public string[] getTeamNames(string sortingScoreType, string sortingScoreType2, int leagueID)
    {
        Init();

        switch (leagueID)
        {
            case 1:
                return league_1.Keys.OrderByDescending(n => getScore(n, sortingScoreType, leagueID)).ThenBy(name => getScore(name, sortingScoreType2, leagueID)).ToArray();
            case 2:
                return league_2.Keys.OrderByDescending(n => getScore(n, sortingScoreType, leagueID)).ThenBy(name => getScore(name, sortingScoreType2, leagueID)).ToArray();
            case 3:
                return league_3.Keys.OrderByDescending(n => getScore(n, sortingScoreType, leagueID)).ThenBy(name => getScore(name, sortingScoreType2, leagueID)).ToArray();
            case 4:
                return league_4.Keys.OrderByDescending(n => getScore(n, sortingScoreType, leagueID)).ThenBy(name => getScore(name, sortingScoreType2, leagueID)).ToArray();
            case 5:
                return league_5.Keys.OrderByDescending(n => getScore(n, sortingScoreType, leagueID)).ThenBy(name => getScore(name, sortingScoreType2, leagueID)).ToArray();
        }

        return null;

       }

    public int getChangeCounter()
    {
        return changeCounter;
    }

}
