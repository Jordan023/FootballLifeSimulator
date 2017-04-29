using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    Player character = new Player(1, 0, 6, 10, "Jordan Munk", 1, 1);

    Attribute[] attributes = {
      new Attribute("Pace", 1, 0),
      new Attribute("Agility", 1, 0),
      new Attribute("Strength", 1, 0),
      new Attribute("Heading", 1, 0),
      new Attribute("Stamina", 1, 0),

      new Attribute("Ball Control", 1, 0),
      new Attribute("Dribbling", 1, 0),
      new Attribute("Crossing", 1, 0),
      new Attribute("Passing", 1, 0),
      new Attribute("Shooting", 1, 0),

      new Attribute("Aggression", 1, 0),
      new Attribute("Interceptions", 1, 0),
      new Attribute("Stand Tackle", 1, 0),
      new Attribute("Sliding", 1, 0),

      new Attribute("GK Diving", 1, 0),
      new Attribute("GK Reflexes", 1, 0),
      new Attribute("GK Positioning", 1, 0),
      new Attribute("GK Kicking", 1, 0)
     };

    public EventManager button_1;
    public EventManager button_2;
    public EventManager button_3;
    public EventManager button_4;
    public EventManager button_5;

    public LeagueManager league;

    public Text levels1Display;
    public Text levels2Display;
    public Text levels3Display;
    public Text levels4Display;
    public Text generalDisplay;

    public Text moneyDisplay;
    public Text energyDisplay;
    public Text weekDisplay;

    public string levelUpMessage;
    public GameObject panel;
    public Text panelText;
    public bool levelUpBool = false;


    // Use this for initialization
    void Start () {
		
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

    private void Update()
    {
        generalDisplay.text = "Name: " + character.CharacterName + "\nAge: " + character.Age + " years old" + "\nCurrent Team: " + league.getTeamName(character.TeamID);

        moneyDisplay.text = "Money: $" + character.Money.ToString("F0");
        energyDisplay.text = "Energy: " + character.Energy + "/10";
        weekDisplay.text = "Year " + character.Year + " | Week " + character.Week;

        levels1Display.text =
         "\n Pace: " + attributes[0].AttributeLevel +
         "\n Agility: " + attributes[1].AttributeLevel +
         "\n Strength: " + attributes[2].AttributeLevel +
         "\n Heading " + attributes[3].AttributeLevel +
         "\n Stamina: " + attributes[4].AttributeLevel;

        levels2Display.text =
         "\n Ball Control: " + attributes[5].AttributeLevel +
         "\n Dribbling: " + attributes[6].AttributeLevel +
         "\n Crossing: " + attributes[7].AttributeLevel +
         "\n Passing " + attributes[8].AttributeLevel +
         "\n Shooting: " + attributes[9].AttributeLevel;

        levels3Display.text =
         "\n Aggression: " + attributes[10].AttributeLevel +
         "\n Interceptions: " + attributes[11].AttributeLevel +
         "\n Stand Tackle: " + attributes[12].AttributeLevel +
         "\n Sliding " + attributes[13].AttributeLevel;

        levels4Display.text =
         "\n GK Diving: " + attributes[14].AttributeLevel +
         "\n GK Reflexes: " + attributes[15].AttributeLevel +
         "\n GK Positioning: " + attributes[16].AttributeLevel +
         "\n GK Kicking " + attributes[17].AttributeLevel;

        if (levelUpBool)
            panel.SetActive(true);
        else
            panel.SetActive(false);

        for (int i = 0; i < attributes.Length; i++)
        {
            if (attributes[i].levelUp())
                levelUpScreen(attributes[i].AttributeLevel, attributes[i].AttributeName);
        }

        panelText.text = levelUpMessage;
    }

    public void giveExperience(string eventName)
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            if (attributes[i].AttributeName == eventName)
                attributes[i].addExperience();
        }
    }

    public int getExp(string eventName)
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            if (attributes[i].AttributeName == eventName)
                return attributes[i].AttributeExp;
        }
        return 0;
    }

    public int getEnergy()
    {
        return character.Energy;
    }
    public void setEnergy(int energy)
    {
        character.Energy = energy;
    }

    public void levelUpScreen(int level, string skill)
    {
        //Give  experience bar
        levelUpBool = true;
        levelUpMessage = "You have achieved level " + level + " in " + skill;
        Wait(5, () => {
            levelUpBool = false;
        });
    }

    public void goToTheNextWeek()
    {
        if (character.Week + 1 > 52)
        {
            character.Year++;
            character.Week = 1;
            character.Energy = 10;
            button_1.isNameFound = false;
            button_2.isNameFound = false;
            button_3.isNameFound = false;
            button_4.isNameFound = false;
            button_5.isNameFound = false;
        }
        else
        {
            character.Week++;
            character.Energy = 10;
            button_1.isNameFound = false;
            button_2.isNameFound = false;
            button_3.isNameFound = false;
            button_4.isNameFound = false;
            button_5.isNameFound = false;
        }
    }
}
