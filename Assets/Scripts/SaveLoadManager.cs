using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Create);

        PlayerData data = new PlayerData(player);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        if(File.Exists(Application.persistentDataPath + "/player.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("File does not exist.");
            return null;
        }
    }

    public static void SaveAttributes(Attribute[] attributes)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/attributes.sav", FileMode.Create);

        AttributeData data = new AttributeData(attributes);

        bf.Serialize(stream, data);
        stream.Close();
    }


    public static AttributeData LoadAttributes()
    {
        if (File.Exists(Application.persistentDataPath + "/attributes.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/attributes.sav", FileMode.Open);

            AttributeData data = bf.Deserialize(stream) as AttributeData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File does not exist.");
            return null;
        }
    }

    public static void SaveClubs(Club[] clubs)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/clubs.sav", FileMode.Create);

        ClubData data = new ClubData(clubs);

        bf.Serialize(stream, data);
        stream.Close();
    }


    public static ClubData LoadClubs()
    {
        if (File.Exists(Application.persistentDataPath + "/clubs.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/clubs.sav", FileMode.Open);

            ClubData data = bf.Deserialize(stream) as ClubData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File does not exist.");
            return null;
        }
    }

    public static void SaveLeagues(League[] leagues)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/league.sav", FileMode.Create);

        LeagueData data = new LeagueData(leagues);

        bf.Serialize(stream, data);
        stream.Close();
    }


    public static LeagueData LoadLeagues()
    {
        if (File.Exists(Application.persistentDataPath + "/league.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/league.sav", FileMode.Open);

            LeagueData data = bf.Deserialize(stream) as LeagueData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File does not exist.");
            return null;
        }
    }

    public static void SaveResults(List<GameResults> results)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/results.sav", FileMode.Create);

        ResultsData data = new ResultsData(results);

        bf.Serialize(stream, data);
        stream.Close();
    }


    public static ResultsData LoadResults()
    {
        if (File.Exists(Application.persistentDataPath + "/results.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/results.sav", FileMode.Open);

            ResultsData data = bf.Deserialize(stream) as ResultsData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File does not exist.");
            return null;
        }
    }
}

[Serializable]
public class AttributeData
{
    public string[] names;
    public int[] levels;
    public int[] exp;

    public AttributeData(Attribute[] attributes)
    {
        names = new string[attributes.Length];
        levels = new int[attributes.Length];
        exp = new int[attributes.Length];

        for (int i = 0; i < attributes.Length; i++)
        {
            names[i] = attributes[i].AttributeName;
            levels[i] = attributes[i].AttributeLevel;
            exp[i] = attributes[i].AttributeExp;
        }
    }
}

[Serializable]
public class ResultsData
{
    public int[] teamA;
    public int[] teamB;
    public int[] homeGoals;
    public int[] awayGoals;
    public int[] season;

    public ResultsData(List<GameResults> results)
    {
        teamA = new int[results.Count];
        teamB = new int[results.Count];
        homeGoals = new int[results.Count];
        awayGoals = new int[results.Count];
        season = new int[results.Count];

        for (int i = 0; i < results.Count; i++)
        {
            teamA[i] = results[i].TeamA;
            teamB[i] = results[i].TeamB;
            homeGoals[i] = results[i].HomeGoals;
            awayGoals[i] = results[i].AwayGoals;
            season[i] = results[i].Season;
        }
    }
}

[Serializable]
public class ClubData
{
    public string[] teamNames;
    public int[] teamID;
    public int[] leagueID;
    public int[] defRatings;
    public int[] midRatings;
    public int[] attRatings;

    public ClubData(Club[] clubs)
    {
        teamNames = new string[clubs.Length];
        teamID = new int[clubs.Length];
        leagueID = new int[clubs.Length];
        defRatings = new int[clubs.Length];
        midRatings = new int[clubs.Length];
        attRatings = new int[clubs.Length];

        for (int i = 0; i < clubs.Length; i++)
        {
            teamNames[i] = clubs[i].TeamName;
            teamID[i] = clubs[i].TeamID;
            leagueID[i] = clubs[i].LeagueID;
            defRatings[i] = clubs[i].DefRating;
            midRatings[i] = clubs[i].MidRating;
            attRatings[i] = clubs[i].AttRating;
        }
    }
}

[Serializable]
public class LeagueData
{
    public int[] leagueID;
    public string[] leagueName;
    public int[] countryID;

    public LeagueData(League[] league)
    {
        leagueName = new string[league.Length];
        countryID = new int[league.Length];
        leagueID = new int[league.Length];

        for (int i = 0; i < league.Length; i++)
        {
            leagueName[i] = league[i].LeagueName;
            countryID[i] = league[i].CountryID;
            leagueID[i] = league[i].LeagueID;

        }
    }
}


[Serializable]
public class PlayerData
{
    public int[] stats;
    public float money;
    public string name;

    public PlayerData(Player player)
    {
        stats = new int[6];
        stats[0] = player.TeamID;
        stats[1] = player.LeagueID;
        stats[2] = player.Age;
        stats[3] = player.Energy;
        stats[4] = player.Year;
        stats[5] = player.Week;

        money = player.Money;
        name = player.CharacterName;
    }
}
