using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour {

    public Text GPC;
    public Text goldDisplay;
    public float gold = 0.00f;
    public int goldPerClick = 1;

    private void Update()
    {
        goldDisplay.text = "Money: $" + gold.ToString("F0");
        GPC.text = goldPerClick + " money/click";
    }

    public void clickButton()
    {
        gold += goldPerClick;
    }
}
