using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : MonoBehaviour
{
    public float damage;
    public float timer=1;
    public float attackSpeed;
    public float critRate;
    public float critDMG;
    public float animwait;
    public ArcherHealth archerHealth;
    public ArcherMovement archerMovement;
    public HealthExecutioner healthExecutioner;
    public ArrowSpawner arrowSpawner;

    private void Start()
    {
        archerHealth = GetComponent<ArcherHealth>();
        archerMovement = GetComponent<ArcherMovement>();
    }
    void Update()
    {
        
        attackSpeed+=Time.deltaTime;
        if (attackSpeed>=0.5)
        {
            Attack();
        }
    }
    public void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !archerMovement.anim.GetBool("Run"))
        {
            animwait += Time.deltaTime;
            archerMovement.anim.SetBool("Attack", true);
            if (animwait >= 0.75)
            {
                arrowSpawner.SpawnArrow();
                animwait = 0;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            archerMovement.anim.SetBool("Attack", false);
            attackSpeed = 0;
            animwait = 0;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Executioner") && archerMovement.alive && timer>=0.5)
        {
            timer=0;
            healthExecutioner.kbCounter = healthExecutioner.kbTotalTime;
        }
    }
}
