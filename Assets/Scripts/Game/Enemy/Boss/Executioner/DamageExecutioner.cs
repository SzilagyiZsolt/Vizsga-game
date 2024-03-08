using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageExecutioner : MonoBehaviour
{
    public HealthExecutioner executionerHealth;
    public int damage;
    public float timer;
    public KnightHealth knightHealth;
    public KnightAttack knightAttack;
    public KnightMovement knightMovement;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public Collider2D hitbox;
    public Animator anim;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        executionerHealth = GetComponent<HealthExecutioner>();
        knightHealth = player.GetComponent<KnightHealth>();
        knightAttack = player.GetComponent<KnightAttack>();
        knightMovement = player.GetComponent<KnightMovement>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        timer+=Time.deltaTime;
        if (timer > 0.7)
        {
            anim.SetBool("Skill", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && executionerHealth.executioneralive && timer>=1)
        {
            timer=0;
            anim.SetBool("Skill", true);
            knightMovement.kbCounter = knightMovement.kbTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                knightMovement.knockFromRight = true;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                knightMovement.knockFromRight = false;
            }
            knightHealth.TakeDamage(damage);
        }
    }
}