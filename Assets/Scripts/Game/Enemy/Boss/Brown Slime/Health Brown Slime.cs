using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBrownSlime : MonoBehaviour
{
    public PlayerAttack playerAttack;
    public PlayerMovement playerMovement;
    public Animator anim;
    public SpriteRenderer brownSlime;
    public Rigidbody2D rb;
    public Slider hpBar;
    public float timer;
    public float timer2;
    public float brownSlimeMaxHealth=500;
    public float brownSlimeHealth=500;
    public bool brownSlimealive = true;
    public float kbForce;
    public float kbCounter;
    public float kbTotalTime;
    public bool knockFromRight;
    void Start()
    {
        anim = GetComponent<Animator>();
        brownSlimeHealth = brownSlimeMaxHealth;
        GameObject player = GameObject.FindWithTag("Player");
        playerAttack = player.GetComponent<PlayerAttack>();
        playerMovement = player.GetComponent<PlayerMovement>();
        hpBar.maxValue = brownSlimeMaxHealth;
        rb=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        hpBar.value = brownSlimeHealth;
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer > 0.3)
        {
            brownSlime.color = Color.white;
            anim.SetBool("Hurt", false);
        }

    }
    public void TakeDamage(float damage)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAttack.click++;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            playerAttack.timer -= Time.deltaTime;
            if (timer2>=1 && playerAttack.timer <= 0.5 && playerAttack.click <= 1)
            {
                if (knockFromRight)
                {
                    rb.velocity = new Vector2(-kbForce, 1);
                }

                if (!knockFromRight)
                {
                    rb.velocity = new Vector2(kbForce, 1);
                }
                kbCounter -= Time.deltaTime;
                brownSlimeHealth -= damage;
                brownSlime.color = Color.red;
                timer = 0;
                playerAttack.timer = 1;
                playerAttack.spamdef = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            playerAttack.timer = (float)0.5;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hitbox") && playerMovement.alive && timer>=0.5)
        {
            kbCounter = kbTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                knockFromRight = false;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                knockFromRight = true;
            }
            TakeDamage(playerAttack.damage);
        }
    }
}
