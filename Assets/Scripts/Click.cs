using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public Text GPC;
    public Text moneyDisplay;
    public Text energyDisplay;
    public Text weekDisplay;
    public PlayerStats playerStats;

    private void Update()
    {

    }

    public void clickButton()
    {
        playerStats.goToTheNextWeek();
    }
}