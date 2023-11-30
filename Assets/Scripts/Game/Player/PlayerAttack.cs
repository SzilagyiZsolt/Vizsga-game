using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage;
    public float timer=1;
    public float spamdef=1;
    public int click=0;
    [HideInInspector] public Collider2D hitbox;
    [HideInInspector] public PlayerMovement playerMovement;
    [HideInInspector] public Transform attackPoint;
    public float attackRange = 0.5f;

    void Update()
    {
        Attack();
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
