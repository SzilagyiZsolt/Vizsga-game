using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeXP : MonoBehaviour
{
    public CountDown countDown;
    public PlayerXP playerXP;
    public SlimeHealth slimeHealth;
    public SlimeDamage slimeDamage;
    public int slimeXP = 1;
    public int slimeCoin = 1;
    public int slimeLevel=1;
    public float timer;
    public int minutes=10;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerXP=player.GetComponent<PlayerXP>();
        slimeHealth = GetComponent<SlimeHealth>();
        slimeDamage = GetComponent<SlimeDamage>();
        GameObject count = GameObject.FindWithTag("CountDown");
        countDown = count.GetComponent<CountDown>();
        SlimeLevelUp();
    }

    public void SlimeGiveXP()
    {
        if (!slimeHealth.slimealive)
        {
            {
                playerXP.playerXP+=slimeXP;
            }
        }
    }
    public void SlimeGiveGold()
    {
        if (!slimeHealth.slimealive)
        {
            {
                playerXP.coinAmount+=slimeCoin;
                playerXP.coinText.text= playerXP.coinAmount.ToString();
            }
        }
    }
    public void SlimeLevelUp()
    {
        while (countDown.min<minutes)
        {
            slimeLevel++;
            slimeCoin*=slimeLevel;
            slimeHealth.slimeMaxHealth*=slimeLevel;
            slimeDamage.damage*=slimeLevel;
            minutes--;
        }
    }
}
