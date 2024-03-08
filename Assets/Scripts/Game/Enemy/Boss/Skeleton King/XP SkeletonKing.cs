using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class XPSkeletonKing : MonoBehaviour
{
    public KnightXP knightXP;
    public HealthSkeletonKing healthSkeletonKing;
    public DamageSkeletonKing damageSkeletonKing;
    public SaveManager saveManager;
    public int skeletonKingCoin;
    public int skeletonKingLevel;
    public int counter;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        knightXP=player.GetComponent<KnightXP>();
        healthSkeletonKing = GetComponent<HealthSkeletonKing>();
        damageSkeletonKing = GetComponent<DamageSkeletonKing>();
        GameObject save = GameObject.FindWithTag("SaveManager");
        saveManager=save.GetComponent<SaveManager>();
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}SecretBossSkeletonKing.dat"))
        {
            saveManager.loadSkeletonKing();
        }
        skeletonKingCoin*=skeletonKingLevel;
        healthSkeletonKing.skeletonKingMaxHealth*=skeletonKingLevel;
        damageSkeletonKing.damage*=skeletonKingLevel;
    }
    public void SkeletonKingGiveGold()
    {
        if (!healthSkeletonKing.skeletonKingalive)
        {
            knightXP.coinAmount+=skeletonKingCoin;
            knightXP.coinText.text= knightXP.coinAmount.ToString();
            skeletonKingLevel++;
            saveManager.saveSkeletonKing();
        }
    }
}