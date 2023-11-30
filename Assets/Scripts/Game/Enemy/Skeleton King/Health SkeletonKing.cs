using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSkeletonKing : MonoBehaviour
{
    [HideInInspector] public PlayerAttack playerAttack;
    [HideInInspector] public Animator anim;
    public float timer;
    public float skeletonKingMaxHealth = 50;
    public float skeletonKingHealth;
    public bool skeletonKingalive = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        skeletonKingHealth = skeletonKingMaxHealth;
        GameObject player = GameObject.FindWithTag("Player");
        playerAttack = player.GetComponent<PlayerAttack>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.3)
        {
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
            if (playerAttack.timer <= 0.5 && playerAttack.click <= 1)
            {
                skeletonKingHealth -= damage;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hitbox"))
        {
            TakeDamage(playerAttack.damage);
        }
    }
}
