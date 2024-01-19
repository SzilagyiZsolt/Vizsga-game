using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBrownSlime : MonoBehaviour
{
    public HealthBrownSlime brownSlimeHealth;
    public int damage;
    public float timer;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        brownSlimeHealth = GetComponent<HealthBrownSlime>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        timer+=Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && brownSlimeHealth.brownSlimealive && timer>=0.5)
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
