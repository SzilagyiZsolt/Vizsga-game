using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public SlimeHealth[] slimeHealth;
    public HealthSkeletonKing skeletonKingHealth;
    public float damage;
    public float timer=1;
    public float spamdef=1;
    public int click=0;
    public PlayerMovement playerMovement;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Start()
    {
        GameObject slime = GameObject.FindWithTag("Slime");
        slimeHealth = slime.GetComponent<SlimeHealth[]>();
    }
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
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            click++;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {   
            playerMovement.anim.SetInteger("Attack", 3);
            timer -= Time.deltaTime;
            if(timer<=0.5 && click <= 1)
            {   
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
                foreach (Collider2D enemy in hitEnemies)
                {
                    Debug.Log("We hit");
                    if (enemy.gameObject.CompareTag("Slime"))
                    {
                        Debug.Log("Kapja");
                        slimeHealth[0].TakeDamage(damage);
                        slimeHealth[1].TakeDamage(damage);
                        
                    }
                    
                    //skeletonKingHealth.TakeDamage(damage);
                }
                timer =1;
                spamdef = 0;
            }
        }
        else
        {
            playerMovement.anim.SetInteger("Attack", 0);
            
        }
        if(Input.GetKeyUp(KeyCode.Mouse0)) 
        {
            timer = (float)0.5; 
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint==null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Slime"))
    //    {
    //        slimeHealth.TakeDamage(damage);
    //    }
    //    else if (collision.gameObject.CompareTag("SkeletonKing"))
    //    {
    //        skeletonKingHealth.TakeDamage(damage);
    //    }
    //}
}
