using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXP : MonoBehaviour
{
     public SaveManager saveManager;
     public Text LevelText;
    public Text coinText;
     public Slider sliderXP;
     public PlayerHealth playerHealth;
     public PlayerAttack playerAttack;
    public int playerXP=0;
    public int playermaxXP=1;
    public int playerLevel = 1;
    public int coinAmount;
    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerHealth = GetComponent<PlayerHealth>();
        
    }
    void Update()
    {
        sliderXP.maxValue=playermaxXP;
        sliderXP.value=playerXP;
        while (playerXP >= playermaxXP && playerLevel<999)
        {   
            playerHealth.maxHealth+=10;
            playerAttack.damage+=3;
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
