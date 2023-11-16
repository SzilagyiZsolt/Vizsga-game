using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeXP : MonoBehaviour
{
    public PlayerXP playerXP;
    public SlimeHealth slimeHealth;
    public int slimeXP = 1;
    public int slimeLevel = 1;
    public float timer;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerXP=player.GetComponent<PlayerXP>();
        slimeHealth = GetComponent<SlimeHealth>();
    }
    void Update()
    {

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
}
