using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HP;
    public Slider Mana;
    public float timer;
    public float timer2;
    public PlayerMovement playerMovement;
    public int health;
    public int maxHealth;
    public DamageExecutioner damageExecutioner;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        timer2 += Time.deltaTime;
        if (timer2 < 1)
        {
            health=maxHealth;
        }
        HP.maxValue=maxHealth;
        HP.value=health;
        timer += Time.deltaTime;
        if (timer > 0.3)
        {
            playerMovement.anim.SetBool("Hurt", false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        playerMovement.anim.SetBool("Hurt", true);
        timer = 0;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        timer+=Time.deltaTime;
        if (collision.gameObject.CompareTag("EnemyHitbox") && timer>2)
        {
            playerMovement.kbCounter = playerMovement.kbTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerMovement.knockFromRight = false;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                playerMovement.knockFromRight = true;
            }
            TakeDamage(damageExecutioner.damage);
        }
    }
}
