using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour {
    public GameObject playerScoreEntryPrefab;
    public Font boldFont;

    public PlayerManager playerManager;
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

        if (scoreManager.getChangeCounter() == lastChangeCounter)
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

        string[] names = scoreManager.getTeamNames("points", "goalsDifference", playerManager.getLeagueID());

        int i = 0;
        foreach (string name in names)
        {
            i++;
            GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform, false);
            if (name == playerManager.getTeamName())
            {
                go.transform.Find("Position").GetComponent<Text>().text = i.ToString();
                go.transform.Find("Position").GetComponent<Text>().font = boldFont;
                go.transform.Find("Team").GetComponent<Text>().text = name;
                go.transform.Find("Team").GetComponent<Text>().font = boldFont;
                go.transform.Find("Points").GetComponent<Text>().text = scoreManager.getScore(name, "points", playerManager.getLeagueID()).ToString();
                go.transform.Find("Points").GetComponent<Text>().font = boldFont;
            }
            else
            {
                go.transform.Find("Position").GetComponent<Text>().text = i.ToString();
                go.transform.Find("Team").GetComponent<Text>().text = name;
                go.transform.Find("Points").GetComponent<Text>().text = scoreManager.getScore(name, "points", playerManager.getLeagueID()).ToString();
            }
        }
    }
}
