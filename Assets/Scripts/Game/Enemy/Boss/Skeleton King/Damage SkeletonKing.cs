using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkeletonKing : MonoBehaviour
{
    [HideInInspector] public HealthSkeletonKing skeletonKingHealth;
    public int damage;
    public float timer;
    [HideInInspector] public PlayerHealth playerHealth;
    [HideInInspector] public PlayerMovement playerMovement;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        skeletonKingHealth = GetComponent<HealthSkeletonKing>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
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