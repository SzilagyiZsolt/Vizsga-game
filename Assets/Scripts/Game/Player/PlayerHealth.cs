using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HP;
    public Slider Mana;
    public float timer;
    public PlayerMovement playermovement;
    public int health;
    public int maxHealth;
    void Start()
    {
          
        playermovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (timer<1)
        {
            health=maxHealth;
        }
        HP.maxValue=maxHealth;
        HP.value=health;
        timer += Time.deltaTime;
        if (timer > 0.3)
        {
            playermovement.anim.SetBool("Hurt", false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        playermovement.anim.SetBool("Hurt", true);
        timer = 0;
    }
}
