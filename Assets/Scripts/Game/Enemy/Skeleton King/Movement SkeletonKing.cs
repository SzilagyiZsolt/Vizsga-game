using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSkeletonKing : MonoBehaviour
{
    public HealthSkeletonKing skeletonKingHealth;
    public Transform playerTransform;
    public float moveSpeed;
    public int patrolDestination;
    public bool chasing;
    public int chasingDistance;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        //GameObject points = GameObject.FindWithTag("PatrolPoints");
        skeletonKingHealth = GetComponent<HealthSkeletonKing>();
        playerTransform = player.GetComponent<Transform>();
        //playerTransform = points.GetComponent<Transform[]>();
    }
    private void Update()
    {
        if (skeletonKingHealth.skeletonKingalive)
        {
            if (chasing)
            {
                if (Vector2.Distance(transform.position, playerTransform.position) > chasingDistance)
                {
                    skeletonKingHealth.anim.SetBool("Walk", false);
                    chasing = false;
                }

                if (transform.position.x > playerTransform.position.x)
                {
                    skeletonKingHealth.anim.SetBool("Walk", true);
                    transform.localScale = new Vector3((float)0.3, (float)0.3, 1);
                    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                }

                if (transform.position.x < playerTransform.position.x)
                {
                    skeletonKingHealth.anim.SetBool("Walk", true);
                    transform.localScale = new Vector3((float)-0.3, (float)0.3, 1);
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
