using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour {
    public GameObject playerScoreEntryPrefab;

    ScoreManager scoreManager;

    int lastChangeCounter;

    private void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        lastChangeCounter = scoreManager.getChangeCounter();
    }

    private void Update()
    {
        if (scoreManager == null)
        {
            Debug.LogError("You forgot to add the score manager component to a game object!");
            return;
        }

        if(scoreManager.getChangeCounter() == lastChangeCounter)
        {
            //No change since last update!
            return;
        }

        lastChangeCounter = scoreManager.getChangeCounter();

        while(this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null); 
            Destroy(c.gameObject);
        }

        string[] names = scoreManager.getPlayerNames("kills");

        foreach (string name in names)
        {
            GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform, true);
            go.transform.Find("Username").GetComponent<Text>().text = name;
            go.transform.Find("Kills").GetComponent<Text>().text = scoreManager.getScore(name, "kills").ToString();
            go.transform.Find("Deaths").GetComponent<Text>().text = scoreManager.getScore(name, "deaths").ToString();
            go.transform.Find("Assists").GetComponent<Text>().text = scoreManager.getScore(name, "assists").ToString();

        }
    }
}
