using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSlimeXP : MonoBehaviour
{
    public PlayerXP playerXP;
    public SlimeHealth slimeHealth;
    public SlimeDamage slimeDamage;
    public int slimeXP = 1;
    public int slimeCoin = 1;
    public int slimeLevel = 1;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerXP=player.GetComponent<PlayerXP>();
        slimeHealth = GetComponent<SlimeHealth>();
        slimeDamage = GetComponent<SlimeDamage>();
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
}
