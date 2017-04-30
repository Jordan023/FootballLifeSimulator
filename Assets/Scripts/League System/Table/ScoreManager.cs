using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ScoreManager : MonoBehaviour {
    
    Dictionary<string, Dictionary<string, int>> playerScores;
    public PlayerManager playerManager;
    public LeagueManager leagueManager;

    int changeCounter = 0;

    void Start()
    {
        for (int i = 0; i < leagueManager.clubs.Length; i++)
        {
            if (leagueManager.clubs[i].LeagueID == 1)
            {
                setScore(leagueManager.clubs[i].TeamName, "played", leagueManager.getGamesPlayed(leagueManager.clubs[i].TeamID));
                setScore(leagueManager.clubs[i].TeamName, "won", leagueManager.getGamesWon(leagueManager.clubs[i].TeamID));
                setScore(leagueManager.clubs[i].TeamName, "draw", leagueManager.getGamesDraw(leagueManager.clubs[i].TeamID));
                setScore(leagueManager.clubs[i].TeamName, "lost", leagueManager.getGamesLost(leagueManager.clubs[i].TeamID));
                setScore(leagueManager.clubs[i].TeamName, "goalsHome", leagueManager.getGoalsScored(leagueManager.clubs[i].TeamID));
                setScore(leagueManager.clubs[i].TeamName, "goalsAway", leagueManager.getGoalsAgainst(leagueManager.clubs[i].TeamID));
                setScore(leagueManager.clubs[i].TeamName, "goalsDifference", leagueManager.getGoalDifference(leagueManager.clubs[i].TeamID));
                setScore(leagueManager.clubs[i].TeamName, "points", leagueManager.getPoints(leagueManager.clubs[i].TeamID));
            }     
        }
    }

    void Init()
    {
        if (playerScores != null)
            return;

        playerScores = new Dictionary<string, Dictionary<string, int>>();
    }

    public int getScore(string team, string scoreType)
    {
        Init();

        if(playerScores.ContainsKey(team) == false)
        {
            //We have no score record at all for this username
            return 0;
        }

        if (playerScores[team].ContainsKey(scoreType) == false)
        {
            return 0;
        }

        return playerScores[team][scoreType];
    }

    public void setScore(string team, string scoreType, int value)
    {
        Init();

        changeCounter++;

        if (playerScores.ContainsKey(team) == false)
        {
            playerScores[team] = new Dictionary<string, int>();
        }

        playerScores[team][scoreType] = value;
    }

    public void changeScore(string team, string scoreType, int amount)
    {
        Init();
        int currScore = getScore(team, scoreType);
        setScore(team, scoreType, currScore + amount);
    }

    public string[] getTeamNames(string sortingScoreType, string sortingScoreType2)
    {
        Init();

       return playerScores.Keys.OrderByDescending(n => getScore(n, sortingScoreType)).ThenBy(name => getScore(name, sortingScoreType2)).ToArray();
        
    }

    public int getChangeCounter()
    {
        return changeCounter;
    }

}
