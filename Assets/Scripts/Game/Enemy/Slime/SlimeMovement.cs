using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class SlimeMovement : MonoBehaviour
{
    public SlimeHealth slimeHealth;
    public Transform[] patrolPoints;
    public Transform playerTransform;
    public float moveSpeed;
    public int patrolDestination;
    public bool chasing;
    public int chasingDistance;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        //GameObject points = GameObject.FindWithTag("PatrolPoints");
        slimeHealth = GetComponent<SlimeHealth>();
        playerTransform = player.GetComponent<Transform>();
        //playerTransform = points.GetComponent<Transform[]>();
    }
    private void Update()
    {
        if (slimeHealth.slimealive)
        {
            if (chasing)
            {
                if (Vector2.Distance(transform.position, playerTransform.position) > chasingDistance)
                {
                    chasing = false;
                }

                if (transform.position.x >playerTransform.position.x)
                {
                    transform.localScale = new Vector3((float)0.25, (float)0.25, 1);
                    transform.position += Vector3.left*moveSpeed*Time.deltaTime;
                }

                if (transform.position.x < playerTransform.position.x)
                {
                    transform.localScale = new Vector3((float)-0.25, (float)0.25, 1);
                    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                }
            }
            else
            {
                if (Vector2.Distance(transform.position, playerTransform.position) < chasingDistance)
                {
                    chasing = true;
                }

                //if (patrolDestination == 0)
                //{
                //    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed*Time.deltaTime);
                //    if (Vector2.Distance(transform.position, patrolPoints[0].position) < 0.1)
                //    {
                //        transform.localScale = new Vector3((float)-0.25, (float)0.25, 1);
                //        patrolDestination = 1;
                //    }
                //}
                //
                //if (patrolDestination == 1)
                //{
                //    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                //    if (Vector2.Distance(transform.position, patrolPoints[1].position) < 0.1)
                //    {
                //        transform.localScale = new Vector3((float)0.25, (float)0.25, 1);
                //        patrolDestination = 0;
                //    }
                //}
            }
        }
    }
}
