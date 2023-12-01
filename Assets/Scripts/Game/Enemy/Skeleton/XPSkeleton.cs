using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPSkeleton : MonoBehaviour
{
    public PlayerXP playerXP;
    public HealthSkeleton healthSkeleton;
    public int skeletonXP = 1;
    public int skeletonCoin = 1;
    public int skeletonLevel = 1;
    public float timer;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerXP=player.GetComponent<PlayerXP>();
        healthSkeleton = GetComponent<HealthSkeleton>();
    }

    public void SkeletonGiveXP()
    {
        if (!healthSkeleton.skeletonalive)
        {
            {
                playerXP.playerXP+=skeletonXP;
            }
        }
    }
    public void SkeletonGiveGold()
    {
        if (!healthSkeleton.skeletonalive)
        {
            {
                playerXP.coinAmount+=skeletonCoin;
                playerXP.coinText.text= playerXP.coinAmount.ToString();
            }
        }
    }
}
