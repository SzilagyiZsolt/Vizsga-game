using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPSkeleton : MonoBehaviour
{
    public CountDown countDown;
    public PlayerXP playerXP;
    public HealthSkeleton healthSkeleton;
    public DamageSkeleton damageSkeleton;
    public int skeletonXP = 1;
    public int skeletonCoin = 1;
    public int skeletonLevel = 1;
    public float timer;
    public int minutes = 5;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerXP=player.GetComponent<PlayerXP>();
        healthSkeleton = GetComponent<HealthSkeleton>();
        damageSkeleton = GetComponent<DamageSkeleton>();
        GameObject count = GameObject.FindWithTag("CountDown");
        countDown = count.GetComponent<CountDown>();
        SkeletonLevelUp();
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
    public void SkeletonLevelUp()
    {
        while (countDown.min < minutes)
        {
            skeletonLevel++;
            skeletonCoin*=skeletonLevel;
            healthSkeleton.skeletonMaxHealth *= skeletonLevel;
            damageSkeleton.damage *= skeletonLevel;
            minutes--;
        }
    }
}
