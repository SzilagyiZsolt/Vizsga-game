using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkeletonKing : MonoBehaviour
{
    public HealthSkeletonKing skeletonKingHealth;
    public int damage;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        skeletonKingHealth = GetComponent<HealthSkeletonKing>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && skeletonKingHealth.skeletonKingalive)
        {
            playerMovement.kbCounter = playerMovement.kbTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerMovement.knockFromRight = true;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                playerMovement.knockFromRight = false;
            }
            playerHealth.TakeDamage(damage);
        }
    }
}