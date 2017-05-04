using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public LeagueManager leagueManager;
    public GameObject EntryPrefab;

    public Text team1;
    public Text team2;
    public Text score;

    private const int BYE = -1;

    public void roundRobinSchedule(int day, int leagueID)
    {
            if (leagueID == 1 && day <= 49 || leagueID == 2 && day <= 49 || leagueID == 3 && day <= 49 || leagueID == 4 && day <= 49 || leagueID == 5 && day <= 41)
            {
                List<Club> teamsLeague = new List<Club>();
                for (int i = 0; i < leagueManager.clubs.Length; i++)
                {
                    if (leagueManager.clubs[i].LeagueID == leagueID)
                    {
                        teamsLeague.Add(leagueManager.clubs[i]);
                    }
                }

                int halfsize = teamsLeague.Count / 2;

                List<Club> temp = new List<Club>();
                List<Club> teams = new List<Club>();

                teams.AddRange(teamsLeague);
                temp.AddRange(teamsLeague);
                teams.RemoveAt(0);

                int teamSize = teams.Count;

            if (day > 3)
            {
                if (day % 2 == 0)
                {
                    int teamIdx = day % teamSize;

                    giveResult(teams[teamIdx].TeamID, temp[0].TeamID, leagueID);

                    for (int idx = 0; idx < halfsize; idx++)
                    {
                        int firstTeam = (day + idx) % teamSize;
                        int secondTeam = ((day + teamSize) - idx) % teamSize;

                        if (firstTeam != secondTeam)
                        {
                            giveResult(teams[firstTeam].TeamID, teams[secondTeam].TeamID, leagueID);
                        }
                    }
                }

                if (day % 2 != 0)
                {
                    int teamIdx = day % teamSize;

                    giveResult(temp[0].TeamID, teams[teamIdx].TeamID, leagueID);

                    for (int idx = 0; idx < halfsize; idx++)
                    {
                        int firstTeam = (day + idx) % teamSize;
                        int secondTeam = ((day + teamSize) - idx) % teamSize;

                        if (firstTeam != secondTeam)
                        {
                            giveResult(teams[firstTeam].TeamID, teams[secondTeam].TeamID, leagueID);
                        }
                    }
                }
            }
        }
    }

    public void destroyClones()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
            Destroy(transform.GetChild(i).gameObject);
    }

    public void giveResult(int teamA, int teamB, int leagueID)
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
        int awayGoals = getGoals(teamBOverall, teamAOverall, false);

//     Debug.Log(leagueManager.getTeamName(teamA) + " " + homeGoals + " - " + awayGoals + " " + leagueManager.getTeamName(teamB));

        if (leagueID == playerManager.getLeagueID())
        {
            GameObject go = (GameObject)Instantiate(EntryPrefab);
            go.transform.SetParent(this.transform, false);

     
            if (leagueManager.getTeamName(teamA) == playerManager.getTeamName() || leagueManager.getTeamName(teamB) == playerManager.getTeamName())
            {
                Destroy(go);
                team1.text = leagueManager.getTeamName(teamA);
                team2.text = leagueManager.getTeamName(teamB);
                score.text = homeGoals.ToString() + " - " + awayGoals.ToString();
            }
            else
            {
                go.transform.Find("Team 1").GetComponent<Text>().text = leagueManager.getTeamName(teamA) + "  ";
                go.transform.Find("Team 1 score").GetComponent<Text>().text = homeGoals.ToString();
                go.transform.Find("Team 2").GetComponent<Text>().text = leagueManager.getTeamName(teamB);
                go.transform.Find("Team 2 score").GetComponent<Text>().text = awayGoals.ToString();
            }
        }
        leagueManager.addResult(teamA, teamB, homeGoals, awayGoals, playerManager.getYear());
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

        //If there is a huge skill cap (rating A better than rating B)
        if (skillDifference >= 25)
        {
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