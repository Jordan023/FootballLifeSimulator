using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject mainMenu, optionsMenu, game, player, team, shop, standing;
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

    public void PlayerScreen()
    {
            player.gameObject.SetActive(true);
            mainMenu.gameObject.SetActive(false);
            game.gameObject.SetActive(false);
            team.gameObject.SetActive(false);
            shop.gameObject.SetActive(false);
            standing.gameObject.SetActive(false);
    }

    public void TeamScreen()
    {
        player.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        game.gameObject.SetActive(false);
        team.gameObject.SetActive(true);
        shop.gameObject.SetActive(false);
        standing.gameObject.SetActive(false);
    }

    public void ShopScreen()
    {
        player.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        game.gameObject.SetActive(false);
        team.gameObject.SetActive(false);
        shop.gameObject.SetActive(true);
        standing.gameObject.SetActive(false);
    }

    public void StandingScreen()
    {
        player.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        game.gameObject.SetActive(false);
        team.gameObject.SetActive(false);
        shop.gameObject.SetActive(false);
        standing.gameObject.SetActive(true);
    }

    public void GameScreen()
    {
        player.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        game.gameObject.SetActive(true);
        team.gameObject.SetActive(false);
        shop.gameObject.SetActive(false);
        standing.gameObject.SetActive(false);
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
