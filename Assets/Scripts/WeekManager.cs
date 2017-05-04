using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeekManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public ScoreManager scoreManager;
    public MatchManager matchManager;
    public LeagueManager leagueManager;

    public EventManager button_1;
    public EventManager button_2;
    public EventManager button_3;
    public EventManager button_4;
    public EventManager button_5;

    public GameObject nextWeekButton_1;
    public GameObject nextWeekButton_2;
    public GameObject weekPanel;

    public void endOfTheSeason()
    {
        //Premier League
        string[] names5 = scoreManager.getTeamNames("points", "goalsDifference", 5);
        Debug.Log(names5[0] + " and " + names5[1] + " promotes!");
        Debug.Log(names5[18] + " and " + names5[19] + " degrade!");
        leagueManager.setLeagueID(names5[18], 4);
        leagueManager.setLeagueID(names5[19], 4);

        if (names5[18].Equals(playerManager.getTeamName()) || names5[19].Equals(playerManager.getTeamName())) { playerManager.setLeagueID(4); }

        //Championship
        string[] names4 = scoreManager.getTeamNames("points", "goalsDifference", 4);
        Debug.Log(names4[0] + " and " + names4[1] + " promotes!");
        Debug.Log(names4[22] + " and " + names4[23] + " degrade!");
        leagueManager.setLeagueID(names4[0], 5);
        leagueManager.setLeagueID(names4[1], 5);
        leagueManager.setLeagueID(names4[22], 3);
        leagueManager.setLeagueID(names4[23], 3);

        if (names4[0].Equals(playerManager.getTeamName()) || names4[1].Equals(playerManager.getTeamName())) { playerManager.setLeagueID(4); }
        if (names4[22].Equals(playerManager.getTeamName()) || names4[23].Equals(playerManager.getTeamName())) { playerManager.setLeagueID(2); }

        //Leauge One
        string[] names3 = scoreManager.getTeamNames("points", "goalsDifference", 3);
        Debug.Log(names3[0] + " and " + names3[1] + " promotes!");
        Debug.Log(names3[22] + " and " + names3[23] + " degrade!");
        leagueManager.setLeagueID(names3[0], 4);
        leagueManager.setLeagueID(names3[1], 4);
        leagueManager.setLeagueID(names3[22], 2);
        leagueManager.setLeagueID(names3[23], 2);

        if (names3[0].Equals(playerManager.getTeamName()) || names3[1].Equals(playerManager.getTeamName())) { playerManager.setLeagueID(4); }
        if (names3[22].Equals(playerManager.getTeamName()) || names3[23].Equals(playerManager.getTeamName())) { playerManager.setLeagueID(2); }

        //League Two
        string[] names2 = scoreManager.getTeamNames("points", "goalsDifference", 2);
        Debug.Log(names2[0] + " and " + names2[1] + " promotes!");
        Debug.Log(names2[22] + " and " + names2[23] + " degrade!");
        leagueManager.setLeagueID(names2[0], 3);
        leagueManager.setLeagueID(names2[1], 3);
        leagueManager.setLeagueID(names2[22], 1);
        leagueManager.setLeagueID(names2[23], 1);

        if (names2[0].Equals(playerManager.getTeamName()) || names2[1].Equals(playerManager.getTeamName())) { playerManager.setLeagueID(3); }
        if (names2[22].Equals(playerManager.getTeamName()) || names2[23].Equals(playerManager.getTeamName())) { playerManager.setLeagueID(1); }

        //National League
        string[] names = scoreManager.getTeamNames("points", "goalsDifference", 1);
        Debug.Log(names[0] + " and " + names[1] + " promotes!");
        leagueManager.setLeagueID(names[0], 2);
        leagueManager.setLeagueID(names[1], 2);

        if (names[0].Equals(playerManager.getTeamName()) || names[1].Equals(playerManager.getTeamName())) { playerManager.setLeagueID(2); }

        scoreManager.resetLists();
    }

    public void goToTheNextWeek()
    {
        scoreManager.nextWeek = true;

        if (playerManager.getWeek() + 1 > 52)
        {
            playerManager.setYear(playerManager.getYear() + 1);
            playerManager.setWeek(1);
            playerManager.setEnergy(10);
            endOfTheSeason();
        }
        else
        {
            playerManager.setWeek(playerManager.getWeek() + 1);
            playerManager.setEnergy(10);
        }

        matchManager.roundRobinSchedule(playerManager.getWeek() - 1, 1);
        matchManager.roundRobinSchedule(playerManager.getWeek() - 1, 2);
        matchManager.roundRobinSchedule(playerManager.getWeek() - 1, 3);
        matchManager.roundRobinSchedule(playerManager.getWeek() - 1, 4);
        matchManager.roundRobinSchedule(playerManager.getWeek() - 1, 5);

        button_1.isNameFound = false;
        button_2.isNameFound = false;
        button_3.isNameFound = false;
        button_4.isNameFound = false;
        button_5.isNameFound = false;

        button_1.setActive(false);
        button_2.setActive(false);
        button_3.setActive(false);
        button_4.setActive(false);
        button_5.setActive(false);

        nextWeekButton_1.SetActive(false);
        weekPanel.SetActive(true);
    }

    public void resetWeek()
    {
        button_1.setActive(true);
        button_2.setActive(true);
        button_3.setActive(true);
        button_4.setActive(true);
        button_5.setActive(true);
        nextWeekButton_1.SetActive(true);

        weekPanel.SetActive(false);
        matchManager.destroyClones();
    }
}