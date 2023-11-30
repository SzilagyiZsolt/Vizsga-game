using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXP : MonoBehaviour
{
    [HideInInspector] public SaveManager saveManager;
    [HideInInspector] public Text LevelText;
    [HideInInspector] public Text coinText;
    [HideInInspector] public Slider sliderXP;
    [HideInInspector] public PlayerHealth playerHealth;
    [HideInInspector] public PlayerAttack playerAttack;
    public int playerXP=0;
    public int playermaxXP=1;
    public int playerLevel = 1;
    public int coinAmount;
    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerHealth = GetComponent<PlayerHealth>();
        if (File.Exists(Application.dataPath+"/"+"SaveTest.dat"))
        {
            saveManager.Load();
        }
        
    }
    void Update()
    {
        sliderXP.maxValue=playermaxXP;
        sliderXP.value=playerXP;
        while (playerXP >= playermaxXP && playerLevel<999)
        {   
            playerHealth.maxHealth+=2;
            playerAttack.damage+=1;
            playerXP -= playermaxXP;
            playerLevel++;
            playermaxXP++;
            playerHealth.health=playerHealth.maxHealth;
            LevelText.text=playerLevel.ToString();
        }
    }
    public void UpdateLevel()
    {
        LevelText.text=playerLevel.ToString();
        coinText.text=coinAmount.ToString();
    }
}
