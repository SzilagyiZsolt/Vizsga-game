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
            switch (slimeLevel)
            {
                case 1:
                    slimeHealth.slimeMaxHealth*=4;
                    break;
                case 2:
                    slimeHealth.slimeMaxHealth*=4;
                    break;
                case 3:
                    slimeHealth.slimeMaxHealth*=3;
                    break;
                case 4:
                    slimeHealth.slimeMaxHealth*=2;
                    break;
                case 5:
                    slimeHealth.slimeMaxHealth*=2;
                    break;
            }
            slimeDamage.damage*=slimeLevel;
            minutes--;
        }
    }
}
