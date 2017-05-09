using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Manager Scripts")]
    public PlayerManager playerManager;
    public LeagueManager leagueManager;
    public ScoreManager scoreManager;
    public WeekManager weekManager;
    public MatchManager matchManager;

    [Space(10)]

    [Header("Player Panels")]
    public GameObject playerPanel_1;
    public GameObject playerPanel_2;
    public GameObject playerPanel_3;

    [Space(10)]

    [Header("Team Panels")]
    public GameObject teamPanel_1;
    public GameObject teamPanel_2;
    public GameObject teamPanel_3;
    public GameObject teamPanel_4;

    [Space(10)]

    [Header("Menu Panels")]
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject game;
    public GameObject player;
    public GameObject team;
    public GameObject shop;
    public GameObject standing;

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

        PlayerScreen(1);
        playerManager.displayPlayerMenu(1);
    }

    public void PlayerScreen(int menuID)
    {
        switch (menuID)
        {
            case 1:
                playerPanel_1.SetActive(true);
                playerPanel_2.SetActive(false);
                playerPanel_3.SetActive(false);
                break;
            case 2:
                playerPanel_1.SetActive(false);
                playerPanel_2.SetActive(true);
                playerPanel_3.SetActive(false);
                break;
            case 3:
                playerPanel_1.SetActive(false);
                playerPanel_2.SetActive(false);
                playerPanel_3.SetActive(true);
                break;
        }
    }

    public void TeamScreen()
    {
        player.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        game.gameObject.SetActive(false);
        team.gameObject.SetActive(true);
        shop.gameObject.SetActive(false);
        standing.gameObject.SetActive(false);

        TeamScreen(1);
        leagueManager.displayTeamMenu(1);
    }

    public void TeamScreen(int menuID)
    {
        switch (menuID)
        {
            case 1:
                teamPanel_1.SetActive(true);
                teamPanel_2.SetActive(false);
                teamPanel_3.SetActive(false);
                teamPanel_4.SetActive(false);
                break;
            case 2:
                teamPanel_1.SetActive(false);
                teamPanel_2.SetActive(true);
                teamPanel_3.SetActive(false);
                teamPanel_4.SetActive(false);
                matchManager.destroyClones();
                matchManager.getResults(playerManager.getTeamID());
                break;
            case 3:
                teamPanel_1.SetActive(false);
                teamPanel_2.SetActive(false);
                teamPanel_3.SetActive(true);
                teamPanel_4.SetActive(false);
                break;
            case 4:
                teamPanel_1.SetActive(false);
                teamPanel_2.SetActive(false);
                teamPanel_3.SetActive(false);
                teamPanel_4.SetActive(true);
                break;
        }
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
        weekManager.leagueStandings(playerManager.getLeagueID());
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
