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
    public PlayerScoreList list;

    public EventManager button_1, button_2, button_3, button_4, button_5;

    public GameObject panelRight, panelRight2;
    public GameObject panelLeft;
    public GameObject panelBottom;

    public GameObject nextWeekButton_1, nextWeekButton_2;
    public GameObject weekPanel;
    public GameObject reviewPanel;

    public void promotionAndRelegation()
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

    public void seasonReview(int leagueID)
    {
        changePanels(false);
        changeButtons(false);

        reviewPanel.SetActive(true);
        list.seasonReview(leagueID);
    }

    public void goToTheNextWeek()
    {
        scoreManager.nextWeek = true;

        playerManager.setEnergy(10);

        if (playerManager.getWeek() + 1 > 52)
            seasonReview(playerManager.getLeagueID());
        else
        {
            playerManager.setWeek(playerManager.getWeek() + 1);

            for (int i = 1; i <= 5; i++)
            {
                matchManager.roundRobinSchedule(playerManager.getWeek() - 1, i);
            }

            resetButtons(false);
            changeButtons(false);
            weekPanel.SetActive(true);
        }

        saveGame();
    }

    public void saveGame()
    {
        playerManager.savePlayer();
        playerManager.saveAttributes();
        leagueManager.saveClubs();
        leagueManager.saveLeagues();
        leagueManager.saveResults();
    }

    public void resetSeason()
    {
        promotionAndRelegation();
        changePanels(true);
        changeButtons(true);

        reviewPanel.SetActive(false);

        playerManager.setYear(playerManager.getYear() + 1);
        scoreManager.nextWeek = true;
        playerManager.setWeek(1);

        saveGame();
    }

    public void changePanels(bool trueFalse)
    {
        panelLeft.SetActive(trueFalse);
        panelRight.SetActive(trueFalse);
        panelRight2.SetActive(trueFalse);
        panelBottom.SetActive(trueFalse);
    }

    public void changeButtons(bool trueFalse)
    {
        button_1.setActive(trueFalse);
        button_2.setActive(trueFalse);
        button_3.setActive(trueFalse);
        button_4.setActive(trueFalse);
        button_5.setActive(trueFalse);
        nextWeekButton_1.SetActive(trueFalse);
    }

    public void resetButtons(bool trueFalse)
    {
        button_1.isNameFound = trueFalse;
        button_2.isNameFound = trueFalse;
        button_3.isNameFound = trueFalse;
        button_4.isNameFound = trueFalse;
        button_5.isNameFound = trueFalse;
    }

    public void resetWeek()
    {
        changeButtons(true);

        weekPanel.SetActive(false);
        matchManager.destroyClones();
    }
}