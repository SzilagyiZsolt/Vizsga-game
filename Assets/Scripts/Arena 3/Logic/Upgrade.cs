using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject lvlUP;
    public int damage;
    public float firerate;
    public int health;
    public int movespeed;

    public void DamageUpgrade()
    {
        playerStats.damage += damage;
        Time.timeScale = 1f;
        lvlUP.SetActive(false);
        Cursor.visible = false;
    }
    public void FirerateUpgrade()
    {
        playerStats.firerate += firerate;
        Time.timeScale = 1f;
        lvlUP.SetActive(false);
        Cursor.visible = false;
    }
    public void HealthUpgrade()
    {
        playerStats.HP += health;
        Time.timeScale = 1f;
        lvlUP.SetActive(false);
        Cursor.visible = false;
    }
    public void MovespeedUpgrade()
    {
        playerStats.Speed += movespeed;
        Time.timeScale = 1f;
        lvlUP.SetActive(false);
        Cursor.visible = false;
    }
}
