using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator anim;
    public HealthExecutioner healthExecutioner;
    public Transform playerTransform;
    public float moveSpeed;
    public bool chasing;
    public bool inrange=false;
    public float attackRange;
    public int chasingDistance;
    private void Start()
    {
        anim = GetComponent<Animator>();
        GameObject player = GameObject.FindWithTag("Player");
        healthExecutioner = GetComponent<HealthExecutioner>();
        playerTransform = player.GetComponent<Transform>();
    }
    private void Update()
    {
        if (healthExecutioner.executioneralive)
        {
                if (inrange)
                {
                    anim.SetBool("Attack", true);
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