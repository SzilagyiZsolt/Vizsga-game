using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MovementSkeleton : MonoBehaviour
{
    public Animator anim;
    public HealthSkeleton skeletonHealth;
    public Transform playerTransform;
    public float moveSpeed;
    public bool chasing;
    public int chasingDistance;
    private void Start()
    {
        anim = GetComponent<Animator>();
        GameObject player = GameObject.FindWithTag("Player");
        skeletonHealth = GetComponent<HealthSkeleton>();
        playerTransform = player.GetComponent<Transform>();
    }
    private void Update()
    {
        if (skeletonHealth.skeletonalive)
        {
            if (chasing)
            {
                if (Vector2.Distance(transform.position, playerTransform.position) > chasingDistance)
                {
                    skeletonHealth.anim.SetBool("Walk", false);
                    chasing = false;
                }

                if (transform.position.x > playerTransform.position.x)
                {
                    transform.localScale = new Vector3((float)-0.7, (float)0.7, 1);
                    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                }

                if (transform.position.x < playerTransform.position.x)
                {
                    transform.localScale = new Vector3((float)0.7, (float)0.7, 1);
                    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                }
            }
            else
            {
                if (Vector2.Distance(transform.position, playerTransform.position) < chasingDistance)
                {
                    skeletonHealth.anim.SetBool("Walk", true);
                    chasing = true;
                }
            }
        }
    }
}