using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector] public Slider HP;
    [HideInInspector] public Slider Mana;
    public float timer;
    [HideInInspector] public PlayerMovement playermovement;
    public int health;
    public int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        playermovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
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
