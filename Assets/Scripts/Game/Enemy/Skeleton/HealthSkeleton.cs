using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSkeleton : MonoBehaviour
{
    [HideInInspector] public PlayerAttack playerAttack;
    public PlayerHealth playerHealth;
    [HideInInspector] public Animator anim;
    public Slider hpBar;
    public float timer;
    public float skeletonMaxHealth;
    public float skeletonHealth;
    public bool skeletonalive = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        skeletonHealth = skeletonMaxHealth;
        GameObject player = GameObject.FindWithTag("Player");
        playerAttack = player.GetComponent<PlayerAttack>();
        playerHealth = player.GetComponent<PlayerHealth>();
        hpBar.maxValue = skeletonMaxHealth;
    }
    void Update()
    {
        hpBar.value = skeletonHealth;
        timer += Time.deltaTime;
        if (timer > 0.3)
        {
            anim.SetBool("Hurt", false);
        }
    }
    public void TakeDamage(float damage)
    {
        if (playerHealth.health > 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                playerAttack.click++;
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                playerAttack.timer -= Time.deltaTime;
                if (playerAttack.timer <= 0.5 && playerAttack.click <= 1)
                {
                    skeletonHealth -= damage;
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
        if (collision.gameObject.CompareTag("Hitbox"))
        {
            TakeDamage(playerAttack.damage);
        }
    }
}