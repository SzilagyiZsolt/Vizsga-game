using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeHealth : MonoBehaviour
{
    public PlayerAttack playerAttack;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public Animator anim;
    public Slider hpBar;
    public Rigidbody2D rb;
    public float timer;
    public float timer2;
    public float slimeMaxHealth;
    public float slimeHealth;
    public bool slimealive = true;
    public float kbForce;
    public float kbCounter;
    public float kbTotalTime;
    public bool knockFromRight;
    void Start()
    {
        anim = GetComponent<Animator>();
        slimeHealth = slimeMaxHealth;
        GameObject player = GameObject.FindWithTag("Player");
        playerAttack = player.GetComponent<PlayerAttack>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
        hpBar.maxValue = slimeMaxHealth;
        rb=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        hpBar.value = slimeHealth;
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer > 0.3)
        {
            anim.SetBool("Hurt", false);
        }
    }
    public void TakeDamage(float damage)
    {
        if (playerHealth.health>0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                playerAttack.click++;
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                playerAttack.timer -= Time.deltaTime;
                if (timer2>=1&&playerAttack.timer <= 0.5 && playerAttack.click <= 1)
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
                    slimeHealth -= damage;
                    anim.SetBool("Hurt", true);
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
