using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeXP : MonoBehaviour
{
    [HideInInspector] public PlayerXP playerXP;
    [HideInInspector] public SlimeHealth slimeHealth;
    public int slimeXP = 1;
    public int slimeCoin = 1;
    public int slimeLevel = 1;
    public float timer;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerXP=player.GetComponent<PlayerXP>();
        slimeHealth = GetComponent<SlimeHealth>();
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
