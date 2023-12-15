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
    public Transform attackPoint;
    public float attackRange = 0.5f;

    private void Start()
    {
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
}
