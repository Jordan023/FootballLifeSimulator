using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour {
    public GameObject playerScoreEntryPrefab;
    public Font boldFont;
    public bool review;

    public PlayerManager playerManager;
    public ScoreManager scoreManager;

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

        if (scoreManager.getChangeCounter() == lastChangeCounter && !playerManager.isNotFromMenu())
        {
            //No change since last update!
            return;
        }

        lastChangeCounter = scoreManager.getChangeCounter();
        playerManager.mainMenu = false;

        removeChilds();

        if (review)
        {
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

    public void removeChilds()
    {
        while (this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);
        }
    }

    public void SetActiveRecursivelyExt(GameObject obj, bool state)
    {
        obj.SetActive(state);
        foreach (Transform child in obj.transform)
        {
            SetActiveRecursivelyExt(child.gameObject, state);
        }
    }

    public void seasonReview(int leagueID)
    {
        removeChilds();

        string[] namesReview = scoreManager.getTeamNames("points", "goalsDifference", leagueID);

        int i = 0;
        foreach (string name in namesReview)
        {
            i++;
            GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform, false);

            if (i == 1)
            {
                SetActiveRecursivelyExt(go, true);
            }

            if (name == playerManager.getTeamName())
            {
                go.transform.Find("Position").GetComponent<Text>().text = i.ToString();
                go.transform.Find("Position").GetComponent<Text>().font = boldFont;
                go.transform.Find("Team").GetComponent<Text>().text = name;
                go.transform.Find("Team").GetComponent<Text>().font = boldFont;
                go.transform.Find("Played").GetComponent<Text>().text = scoreManager.getScore(name, "played", leagueID).ToString();
                go.transform.Find("Played").GetComponent<Text>().font = boldFont;
                go.transform.Find("Won").GetComponent<Text>().text = scoreManager.getScore(name, "won", leagueID).ToString();
                go.transform.Find("Won").GetComponent<Text>().font = boldFont;
                go.transform.Find("Draw").GetComponent<Text>().text = scoreManager.getScore(name, "draw", leagueID).ToString();
                go.transform.Find("Draw").GetComponent<Text>().font = boldFont;
                go.transform.Find("Lost").GetComponent<Text>().text = scoreManager.getScore(name, "lost", leagueID).ToString();
                go.transform.Find("Lost").GetComponent<Text>().font = boldFont;
                go.transform.Find("For").GetComponent<Text>().text = scoreManager.getScore(name, "goalsHome", leagueID).ToString();
                go.transform.Find("For").GetComponent<Text>().font = boldFont;
                go.transform.Find("Against").GetComponent<Text>().text = scoreManager.getScore(name, "goalsAway", leagueID).ToString();
                go.transform.Find("Against").GetComponent<Text>().font = boldFont;
                go.transform.Find("Goal Diff").GetComponent<Text>().text = scoreManager.getScore(name, "goalsDifference", leagueID).ToString();
                go.transform.Find("Goal Diff").GetComponent<Text>().font = boldFont;
                go.transform.Find("Points").GetComponent<Text>().text = scoreManager.getScore(name, "points", leagueID).ToString();
                go.transform.Find("Points").GetComponent<Text>().font = boldFont;
            }
            else
            {
                go.transform.Find("Position").GetComponent<Text>().text = i.ToString();
                go.transform.Find("Team").GetComponent<Text>().text = name;
                go.transform.Find("Played").GetComponent<Text>().text = scoreManager.getScore(name, "played", leagueID).ToString();
                go.transform.Find("Won").GetComponent<Text>().text = scoreManager.getScore(name, "won", leagueID).ToString();
                go.transform.Find("Draw").GetComponent<Text>().text = scoreManager.getScore(name, "draw", leagueID).ToString();
                go.transform.Find("Lost").GetComponent<Text>().text = scoreManager.getScore(name, "lost", leagueID).ToString();
                go.transform.Find("For").GetComponent<Text>().text = scoreManager.getScore(name, "goalsHome", leagueID).ToString();
                go.transform.Find("Against").GetComponent<Text>().text = scoreManager.getScore(name, "goalsAway", leagueID).ToString();
                go.transform.Find("Goal Diff").GetComponent<Text>().text = scoreManager.getScore(name, "goalsDifference", leagueID).ToString();
                go.transform.Find("Points").GetComponent<Text>().text = scoreManager.getScore(name, "points", leagueID).ToString();
            }
       }
    }
}