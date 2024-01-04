using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageExecutioner : MonoBehaviour
{
    public HealthExecutioner executionerHealth;
    public int damage;
    public float timer;
    public PlayerHealth playerHealth;
    public PlayerAttack playerAttack;
    public PlayerMovement playerMovement;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public Collider2D hitbox;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        executionerHealth = GetComponent<HealthExecutioner>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAttack = player.GetComponent<PlayerAttack>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        timer+=Time.deltaTime;
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && executionerHealth.executioneralive && timer>=0.5)
        {
            timer=0;
            playerMovement.kbCounter = playerMovement.kbTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerMovement.knockFromRight = true;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                playerMovement.knockFromRight = false;
            }
            playerHealth.TakeDamage(damage);
        }
    }
}