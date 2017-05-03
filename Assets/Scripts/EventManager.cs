using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public Text eventInfo;
    public Text experienceInfo;
    public int eventID;
    public string eventName;
    public string eventAction;
    public bool isNameFound = false;
    public bool experienceBar = false;

    public GameObject panel;
    public GameObject button;
    public PlayerManager playerManager;

    private void Update()
    {
        if (!isNameFound)
        {
            getEvent(eventID);
            eventInfo.text = eventAction + eventName;
            isNameFound = true;
        }

        if (experienceBar)
            panel.SetActive(true);
        else
            panel.SetActive(false);

        experienceInfo.text = eventName + " experience: " + playerManager.getExp(eventName) + "/100";

    }

    public void setActive(bool trueFalse)
    {
        button.SetActive(trueFalse);
    }

    public void Wait(float seconds, System.Action action)
    {
        StartCoroutine(_wait(seconds, action));
    }

    IEnumerator _wait(float time, System.Action callback)
    {
        yield
        return new WaitForSeconds(time);
        callback();
    }

    public void addExperience()
    {
        if (playerManager.getEnergy() != 0)
        {
            //Give  experience bar
            experienceBar = true;
            Wait(5, () => {
                experienceBar = false;
            });

            //Give experience
            playerManager.giveExperience(eventName);

            // -1 energy
            playerManager.setEnergy(playerManager.getEnergy() - 1);
        }
    }

    public string getEvent(int eventManager)
    {
        //First Event
        if (eventManager == 1)
        {
            int eventManagerRandom = Random.Range(0, 5);
            eventAction = "Train ";

            switch (eventManagerRandom)
            {
                case 0:
                    eventName = "Pace";
                    break;
                case 1:
                    eventName = "Agility";
                    break;
                case 2:
                    eventName = "Strength";
                    break;
                case 3:
                    eventName = "Heading";
                    break;
                case 4:
                    eventName = "Stamina";
                    break;
            }
        }

        //Second Event
        if (eventManager == 2)
        {
            int eventManagerRandom = Random.Range(0, 5);
            eventAction = "Train ";

            switch (eventManagerRandom)
            {
                case 0:
                    eventName = "Ball Control";
                    experienceInfo.fontSize = 8;
                    break;
                case 1:
                    eventName = "Dribbling";
                    break;
                case 2:
                    eventName = "Crossing";
                    break;
                case 3:
                    eventName = "Passing";
                    break;
                case 4:
                    eventName = "Shooting";
                    break;
            }
        }

        //Third Event
        if (eventManager == 3)
        {
            int eventManagerRandom = Random.Range(0, 4);
            eventAction = "Train ";

            switch (eventManagerRandom)
            {
                case 0:
                    eventName = "Aggression";
                    break;
                case 1:
                    eventName = "Interceptions";
                    experienceInfo.fontSize = 8;
                    break;
                case 2:
                    eventName = "Stand Tackle";
                    experienceInfo.fontSize = 8;
                    break;
                case 3:
                    eventName = "Sliding";
                    break;
            }
        }

        //Fourth Event
        if (eventManager == 4)
        {
            int eventManagerRandom = Random.Range(0, 4);
            eventAction = "Play ";

            switch (eventManagerRandom)
            {
                case 0:
                    eventName = "Fifo Football";
                    break;
                case 1:
                    eventName = "Football Manager";
                    break;
                case 2:
                    eventName = "Foot Car";
                    break;
                case 3:
                    eventName = "Pro Evolution Football";
                    break;
            }
        }

        //Fifth Event
        if (eventManager == 5)
        {
            int eventManagerRandom = Random.Range(0, 4);
            switch (eventManagerRandom)
            {
                case 0:
                    eventName = "Give interviews";
                    break;
                case 1:
                    eventName = "Hang out with friends";
                    break;
                case 2:
                    eventName = "Give autographs";
                    break;
                case 3:
                    eventName = "Go to school";
                    break;
            }
        }

        return eventName;
    }
}