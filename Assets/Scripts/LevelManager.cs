using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject mainMenu, optionsMenu, game;
    public PlayerManager playerManager;
    public LeagueManager leagueManager;
    public ScoreManager scoreManager;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameWindow(bool clicked)
    {
        if (clicked)
        {
            game.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(false);
            LoadGame();
        }
        else
        {
            game.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(true);
        }
    }

    public void OptionsMenu(bool clicked)
    {
        if (clicked)
        {
            optionsMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(false);
        }
        else
        {
            optionsMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(true);
        }
    }

    public void LoadGame()
    {
        playerManager.loadPlayer();
        leagueManager.loadClubs();
        leagueManager.loadLeagues();
        leagueManager.loadResults();
        playerManager.loadAttributes();

        playerManager.mainMenu = true;
        scoreManager.nextWeek = true;
    }
}
