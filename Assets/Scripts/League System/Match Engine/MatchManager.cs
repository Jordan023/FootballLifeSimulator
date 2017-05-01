using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {
    public PlayerManager playerManager;
    public LeagueManager leagueManager;
    private const int BYE = -1;

    private void Start()
    {
        giveResult(1, 3);
    }


    public void giveResult(int teamA, int teamB)
    {
        int teamA_def = 0;
        int teamA_mid = 0;
        int teamA_att = 0;

        int teamB_def = 0;
        int teamB_mid = 0;
        int teamB_att = 0;

        for (int i = 0; i < leagueManager.clubs.Length; i++)
        {
            if (leagueManager.clubs[i].TeamID == teamA)
            {
                //Team A ratings
                teamA_def = leagueManager.clubs[i].DefRating;
                teamA_mid = leagueManager.clubs[i].MidRating;
                teamA_att = leagueManager.clubs[i].AttRating;
            }

            if (leagueManager.clubs[i].TeamID == teamB)
            {
                //Team B ratings
                teamB_def = leagueManager.clubs[i].DefRating;
                teamB_mid = leagueManager.clubs[i].MidRating;
                teamB_att = leagueManager.clubs[i].AttRating;
            }
        }

        int teamAOverall = (teamA_def + teamA_mid + teamA_att) / 3;
        int teamBOverall = (teamB_def + teamB_mid + teamB_att) / 3;

        int homeGoals = getGoals(teamAOverall, teamBOverall, true);
        int awayeGoals = getGoals(teamBOverall, teamAOverall, false);

        Debug.Log(homeGoals + " - " + awayeGoals + " | Team A Overall: " + teamAOverall + " - Team B Overall " + teamBOverall);
        leagueManager.addResult(teamA, teamB, homeGoals, awayeGoals, playerManager.getYear());
    }

    public int getGoals(int ratingA, int ratingB, bool homeAway)
    {
        int goals = 0;
        int randomInt = Random.Range(0, 101);
        
        int skillDifference = ratingA - ratingB;

        if (homeAway)
            skillDifference = skillDifference + 3;
        else
            skillDifference = skillDifference - 3;

        Debug.Log(ratingA + " = " + randomInt + " | " + skillDifference);

        //If there is a huge skill cap (rating A better than rating B)
        if (skillDifference >= 25)
          {
            Debug.Log("+25");
            if (randomInt < 90)
            {
                if (randomInt < 30)
                    goals = (Random.Range(4, 7));
                else if (randomInt < 70)
                    goals = (Random.Range(2, 4));
                else if (randomInt < 90)
                    goals = (Random.Range(1, 3));
            }
            else
                goals = 0;
        }

        //If there is a huge skill cap (rating A better than rating B)
        else if (skillDifference <= -25)
        {
            Debug.Log("-25");
            if (randomInt < 10)
            {
                if (randomInt < 10)
                    goals = (Random.Range(1, 3));
            }
            else
                goals = 0;
        }

        //Still a pretty huge cap but doable
        else if (skillDifference >= 10)
        {
            Debug.Log("+5");
            if (randomInt < 80)
            {
                if (randomInt < 10)
                    goals = (Random.Range(4, 7));
                else if (randomInt < 50)
                    goals = (Random.Range(2, 4));
                else if (randomInt < 80)
                    goals = (Random.Range(1, 3));
            }
            else
                goals = 0;
        }

        //Still a pretty huge cap but doable
        else if (skillDifference <= -10)
        {

            Debug.Log("-10");
            if (randomInt < 40)
            {
                if (randomInt < 10)
                    goals = (Random.Range(2, 4));
                else if (randomInt < 40)
                    goals = (Random.Range(1, 3));
            }
            else
                goals = 0;
        }

        //Mid cap
        else if (skillDifference >= 5)
        {

            Debug.Log("+5");
            if (randomInt < 75)
            {
                if (randomInt < 10)
                    goals = (Random.Range(4, 7));
                else if (randomInt < 35)
                    goals = (Random.Range(2, 4));
                else if (randomInt < 75)
                    goals = (Random.Range(1, 3));
            }
            else
                goals = 0;
        }

        //Still a pretty huge cap but doable
        else if (skillDifference <= -5)
        {
            Debug.Log("-5");
            if (randomInt < 60)
            {
                if (randomInt < 20)
                    goals = (Random.Range(2, 4));
                else if (randomInt < 60)
                    goals = (Random.Range(1, 3));
            }
            else
                goals = 0;
        }

        //comparable
        else
        {
            Debug.Log("comparable");
            if (randomInt < 70)
            {
                if (randomInt < 5)
                    return (Random.Range(4, 7));
                else if (randomInt < 35)
                    return (Random.Range(2, 4));
                else if (randomInt < 70)
                    return (Random.Range(1, 3));
            }
            else
                return 0;
        }
        return goals;
    }
}
