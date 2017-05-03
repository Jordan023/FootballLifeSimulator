using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeekManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public ScoreManager scoreManager;
    public MatchManager matchManager;

    public EventManager button_1;
    public EventManager button_2;
    public EventManager button_3;
    public EventManager button_4;
    public EventManager button_5;

    public GameObject nextWeekButton_1;
    public GameObject nextWeekButton_2;
    public GameObject weekPanel;


    public void goToTheNextWeek()
    {
        scoreManager.nextWeek = true;

        if (playerManager.getWeek() + 1 > 52)
        {
            playerManager.setYear(playerManager.getYear() + 1);
            playerManager.setWeek(1);
            playerManager.setEnergy(10);
        }
        else
        {
            playerManager.setWeek(playerManager.getWeek() + 1);
            playerManager.setEnergy(10);
            matchManager.roundRobinSchedule(playerManager.getWeek() - 1);
        }


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

        ///cheat fix to fix first example entry
        Destroy(GameObject.Find("Entry 2(Clone)"));
    }

    public void resetWeek()
    {
        matchManager.destroyClones();

        button_1.setActive(true);
        button_2.setActive(true);
        button_3.setActive(true);
        button_4.setActive(true);
        button_5.setActive(true);
        nextWeekButton_1.SetActive(true);

        weekPanel.SetActive(false);
    }
}