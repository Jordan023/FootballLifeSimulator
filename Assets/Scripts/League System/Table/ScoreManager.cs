using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ScoreManager : MonoBehaviour {
    
    // The map we're building is going to look like :
    //
    // LIST OF USERS > A User > LIST OF SCORES for that user
    //

    Dictionary<string, Dictionary<string, int>> playerScores;

    int changeCounter = 0;

    void Start()
    {
        setScore("quill18", "kills", 90);
        setScore("quill18", "deaths", 12);
        setScore("quill18", "assists", 345);

        setScore("bob", "kills", 918);
        setScore("bob", "deaths", 12);

        setScore("bob2", "kills", 435);
        setScore("bob3", "kills", 1009);
        setScore("bob23", "kills", 0);
    }

    void Init()
    {
        if (playerScores != null)
            return;

        playerScores = new Dictionary<string, Dictionary<string, int>>();
    }

    public int getScore(string username, string scoreType)
    {
        Init();

        if(playerScores.ContainsKey(username) == false)
        {
            //We have no score record at all for this username
            return 0;
        }

        if (playerScores[username].ContainsKey(scoreType) == false)
        {
            return 0;
        }

        return playerScores[username][scoreType];
    }

    public void setScore(string username, string scoreType, int value)
    {
        Init();

        changeCounter++;

        if (playerScores.ContainsKey(username) == false)
        {
            playerScores[username] = new Dictionary<string, int>();
        }

        playerScores[username][scoreType] = value;
    }

    public void changeScore(string username, string scoreType, int amount)
    {
        Init();
        int currScore = getScore(username, scoreType);
        setScore(username, scoreType, currScore + amount);
    }

    public string[] getPlayerNames(string sortingScoreType)
    {
        Init();

       return playerScores.Keys.OrderByDescending(n => getScore(n, sortingScoreType)).ToArray();
    }

    public int getChangeCounter()
    {
        return changeCounter;
    }

}
