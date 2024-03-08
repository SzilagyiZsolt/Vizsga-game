using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkeletonKing : MonoBehaviour
{
    public HealthSkeletonKing skeletonKingHealth;
    public int damage;
    public float timer;
    public KnightHealth knightHealth;
    public KnightMovement knightMovement;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        skeletonKingHealth = GetComponent<HealthSkeletonKing>();
        knightHealth = player.GetComponent<KnightHealth>();
        knightMovement = player.GetComponent<KnightMovement>();
    }
    private void Update()
    {
        timer+=Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && skeletonKingHealth.skeletonKingalive && timer>=0.5)
        {
            timer=0;
            knightMovement.kbCounter = knightMovement.kbTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                knightMovement.knockFromRight = true;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                knightMovement.knockFromRight = false;
            }
            knightHealth.TakeDamage(damage);
        }
    }
}