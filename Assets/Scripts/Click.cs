using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public PlayerManager playerManager;

    private void Update()
    {

    }

    public void clickButton()
    {
        playerManager.goToTheNextWeek();
    }
}