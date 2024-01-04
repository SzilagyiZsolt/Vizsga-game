using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage;
    public float timer=1;
    public float spamdef=1;
    public int click=0;
    public Collider2D hitbox;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public HealthExecutioner healthExecutioner;
    public Movement movementExecutioner;
    public Transform attackPoint;
    public float attackRange = 0.5f;

    private void Start()
    {
        GameObject executioner=GetComponent<GameObject>();
        healthExecutioner =executioner.GetComponent<HealthExecutioner>();
        playerHealth = GetComponent<PlayerHealth>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (playerHealth.health>0)
        {
            Attack();
        }
        spamdef += Time.deltaTime;
        if (spamdef>=0.6)
        {
            click = 0;
        }
    }
    public void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {   
            playerMovement.anim.SetInteger("Attack", 3);
        }
        else
        {
            playerMovement.anim.SetInteger("Attack", 0);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Executioner") && playerMovement.alive && timer>=0.5)
        {
            timer=0;
            healthExecutioner.kbCounter = healthExecutioner.kbTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                healthExecutioner.knockFromRight = true;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                healthExecutioner.knockFromRight = false;
            }
        }
    }
}
