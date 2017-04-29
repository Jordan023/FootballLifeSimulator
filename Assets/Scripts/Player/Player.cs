using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    private int teamID;
    private float money;
    private int age;
    private int energy;
    private string characterName;
    private int year = 1;
    private int week = 1;

    public int TeamID
    {
        get { return teamID; }
        set { teamID = value; }
    }
    public float Money
    {
        get { return money; }
        set { money = value; }
    }
    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    public int Energy
    {
        get { return energy; }
        set { energy = value; }
    }
    public string CharacterName
    {
        get { return characterName; }
        set { characterName = value; }
    }
    public int Year
    {
        get { return year; }
        set { year = value; }
    }
    public int Week
    {
        get { return week; }
        set { week = value; }
    }

    public Player(int teamID, float money, int age, int energy, string characterName, int year, int week)
    {
        this.TeamID = teamID;
        this.Money = money;
        this.Age = age;
        this.Energy = energy;
        this.CharacterName = characterName;
        this.Year = year;
        this.Week = week;
    }
}
