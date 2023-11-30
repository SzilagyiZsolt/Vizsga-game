using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MovementSkeleton : MonoBehaviour
{
    [HideInInspector] public Animator anim;
    [HideInInspector] public HealthSkeleton skeletonHealth;
    [HideInInspector] public Transform playerTransform;
    public float moveSpeed;
    public bool chasing;
    public int chasingDistanceX;
    public int chasingDistanceY;
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
                if (Vector2.Distance(transform.position, playerTransform.position) > chasingDistanceX || Vector2.Distance(playerTransform.position, transform.position) > chasingDistanceY)
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
                if (Vector2.Distance(transform.position, playerTransform.position) < chasingDistanceX && Vector2.Distance(playerTransform.position, transform.position) < chasingDistanceY)
                {
                    skeletonHealth.anim.SetBool("Walk", true);
                    chasing = true;
                }
            }
        }
    }
}