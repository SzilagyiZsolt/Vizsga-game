using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDamage : MonoBehaviour
{
    public SlimeHealth slimeHealth;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public int damage;
    public float timer;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        slimeHealth = GetComponent<SlimeHealth>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        timer+=Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && slimeHealth.slimealive && timer>=0.5)
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