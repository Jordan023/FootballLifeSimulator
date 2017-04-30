using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {
    public PlayerManager playerManager;
    public LeagueManager leagueManager;

    private void Start()
    {
        giveResult(2, 1);
    }

    public void giveResult(int teamA, int teamB)
    {
        int teamA_def;
        int teamA_mid;
        int teamA_att;

        int teamB_def;
        int teamB_mid;
        int teamB_att;

        int endResultHome = 1;
        int endResultAway = 1;

        for (int i = 0; i < leagueManager.clubs.Length; i++)
        {
            if (leagueManager.clubs[i].TeamID == teamA)
            {
                //Fill variables
                teamA_def = leagueManager.clubs[i].DefRating;
                teamA_mid = leagueManager.clubs[i].MidRating;
                teamA_att = leagueManager.clubs[i].AttRating;
            }

            if (leagueManager.clubs[i].TeamID == teamB)
            {
                //Fill variables
                teamB_def = leagueManager.clubs[i].DefRating;
                teamB_mid = leagueManager.clubs[i].MidRating;
                teamB_att = leagueManager.clubs[i].AttRating;
            }
        }

        leagueManager.addResult(teamA, teamB, endResultHome, endResultAway, playerManager.getYear());
    }
}
