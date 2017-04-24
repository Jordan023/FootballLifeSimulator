using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldPerSec : MonoBehaviour {
    public Text gpsDisplay;
    public Click click;
    public ItemManager[] items;

    private void Start()
    {
        StartCoroutine(autoTick());
    }

    private void Update()
    {
        gpsDisplay.text = getGoldPerSec() + " gold/sec";
    }
    public float getGoldPerSec()
    {
        float tick = 0;
        foreach (ItemManager item in items){
            tick += item.count * item.tickValue;
        }
        return tick;
    }

    public void autoGoldPerSec()
    {
        click.gold += getGoldPerSec() / 10;
    }

    IEnumerator autoTick()
    {
        while (true)
        {
            autoGoldPerSec();
            yield return new WaitForSeconds(0.10f);
        }
    }
}
