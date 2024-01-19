using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class XPBrownSlime : MonoBehaviour
{
    public PlayerXP playerXP;
    public HealthBrownSlime brownSlimeHealth;
    public DamageBrownSlime brownSlimeDamage;
    public SaveManager saveManager;
    public int brownSlimeCoin;
    public int brownSlimeLevel;
    public int counter;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerXP=player.GetComponent<PlayerXP>();
        brownSlimeHealth = GetComponent<HealthBrownSlime>();
        brownSlimeDamage = GetComponent<DamageBrownSlime>();
        GameObject save = GameObject.FindWithTag("SaveManager");
        saveManager=save.GetComponent<SaveManager>();
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}SecretBoss.dat"))
        {
            //saveManager.LoadSecretBoss();
        }
        brownSlimeCoin*=brownSlimeLevel;
        brownSlimeHealth.brownSlimeMaxHealth*=brownSlimeLevel;
        brownSlimeDamage.damage*=brownSlimeLevel;
    }
    public void BrownSlimeGiveGold()
    {
        if (!brownSlimeHealth.brownSlimealive)
        {
            {
                playerXP.coinAmount+=brownSlimeCoin;
                playerXP.coinText.text= playerXP.coinAmount.ToString();
                brownSlimeLevel++;
                //saveManager.SaveBoss();
            }
        }
    }
}
