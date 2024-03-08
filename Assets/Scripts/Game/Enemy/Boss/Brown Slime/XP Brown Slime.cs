using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class XPBrownSlime : MonoBehaviour
{
    public KnightXP knightXP;
    public HealthBrownSlime brownSlimeHealth;
    public DamageBrownSlime brownSlimeDamage;
    public SaveManager saveManager;
    public int brownSlimeCoin;
    public int brownSlimeLevel;
    public int counter;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        knightXP=player.GetComponent<KnightXP>();
        brownSlimeHealth = GetComponent<HealthBrownSlime>();
        brownSlimeDamage = GetComponent<DamageBrownSlime>();
        GameObject save = GameObject.FindWithTag("SaveManager");
        saveManager=save.GetComponent<SaveManager>();
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}SecretBossBrownSlime.dat"))
        {
            saveManager.loadBrownSlime();
        }
        brownSlimeCoin*=brownSlimeLevel;
        brownSlimeHealth.brownSlimeMaxHealth*=brownSlimeLevel;
        brownSlimeDamage.damage*=brownSlimeLevel;
    }
    public void BrownSlimeGiveGold()
    {
        if (!brownSlimeHealth.brownSlimealive)
        {
            knightXP.coinAmount+=brownSlimeCoin;
            knightXP.coinText.text= knightXP.coinAmount.ToString();
            brownSlimeLevel++;
            saveManager.saveBrownSlime();
        }
    }
}
