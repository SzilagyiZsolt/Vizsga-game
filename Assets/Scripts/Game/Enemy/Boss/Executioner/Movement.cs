using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator anim;
    public HealthExecutioner healthExecutioner;
    public Transform playerTransform;
    public KnightHealth knightHealth;
    public DamageExecutioner damageExecutioner;
    public KnightMovement knightMovement;
    public GameObject player;
    public float moveSpeed;
    public bool chasing;
    public bool inrange=false;
    public float attackRange;
    public int chasingDistance;
    public float timer;
    private void Start()
    {
        anim = GetComponent<Animator>();
        GameObject Player = GameObject.FindWithTag("Player");
        knightHealth=Player.GetComponent<KnightHealth>();
        healthExecutioner = GetComponent<HealthExecutioner>();
        damageExecutioner = GetComponent<DamageExecutioner>();
        knightMovement = Player.GetComponent<KnightMovement>();
        playerTransform = Player.GetComponent<Transform>();
    }
    private void Update()
    {
        if (healthExecutioner.executioneralive)
        {
                if (inrange)
                {
                    anim.SetBool("Attack", true);
                    timer+=Time.deltaTime;
                    if (timer > 0.35)
                    {
                        knightHealth.TakeDamage(damageExecutioner.damage);
                        knightMovement.kbCounter = knightMovement.kbTotalTime;
                        if (player.transform.position.x <= transform.position.x)
                        {
                            knightMovement.knockFromRight = true;
                        }
                        if (player.transform.position.x >= transform.position.x)
                        {
                            knightMovement.knockFromRight = false;
                        }
                        timer=0;
                    }
                    if (Vector2.Distance(transform.position, playerTransform.position) > attackRange)
                    {
                        inrange = false;
                    }
                }
                else
                {
                    if (Vector2.Distance(transform.position, playerTransform.position) < attackRange)
                    {
                        inrange = true;
                    }
                    anim.SetBool("Attack", false);
                }
                if (chasing && !inrange)
                {
                    if (Vector2.Distance(transform.position, playerTransform.position) > chasingDistance)
                    {
                        chasing = false;
                    }

                    if (transform.position.x > playerTransform.position.x)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                    }

                    if (transform.position.x < playerTransform.position.x)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                    }
                }
                else
                {
                    if (Vector2.Distance(transform.position, playerTransform.position) < chasingDistance)
                    {
                        chasing = true;
                    }
                }
            }
        }
    }