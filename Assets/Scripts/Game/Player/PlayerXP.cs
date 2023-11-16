using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXP : MonoBehaviour
{
    public Text LevelText;
    public Slider sliderXP;
    public PlayerHealth playerHealth;
    public PlayerAttack playerAttack;
    public int playerXP=0;
    public int playermaxXP=1;
    public int playerLevel = 1;
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
            playerLevel++;
            playerXP -= playermaxXP;
            playermaxXP++;
            playerHealth.maxHealth+=2;
            playerAttack.damage+=1;
            LevelText.text=playerLevel.ToString();
            playerHealth.health=playerHealth.maxHealth;
        }
    }
}
