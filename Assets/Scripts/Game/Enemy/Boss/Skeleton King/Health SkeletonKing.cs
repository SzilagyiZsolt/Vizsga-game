using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSkeletonKing : MonoBehaviour
{
    public KnightAttack knightAttack;
    public Animator anim;
    public float timer;
    public float skeletonKingMaxHealth = 50;
    public float skeletonKingHealth;
    public bool skeletonKingalive = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        skeletonKingHealth = skeletonKingMaxHealth;
        GameObject player = GameObject.FindWithTag("Player");
        knightAttack = player.GetComponent<KnightAttack>();
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
            knightAttack.click++;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            knightAttack.timer -= Time.deltaTime;
            if (knightAttack.timer <= 0.5 && knightAttack.click <= 1)
            {
                skeletonKingHealth -= damage;
                anim.SetBool("Hurt", true);
                timer = 0;
                knightAttack.timer = 1;
                knightAttack.spamdef = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            knightAttack.timer = (float)0.5;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hitbox"))
        {
            TakeDamage(knightAttack.damage);
        }
    }
}
