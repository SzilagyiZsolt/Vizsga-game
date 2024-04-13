using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossMovement2 : MonoBehaviour
{
    public BossHealth2 bossHealth;
    public GameObject player;
    public SpriteRenderer sprite;
    public Transform playerTransform;
    public GameObject laserSpawn;
    public bool attacking;
    public float moveSpeed;
    public float timer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        bossHealth = GetComponent<BossHealth2>();
        playerTransform = player.GetComponent<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (bossHealth.alive)
        {
            if (timer > 5)
            {
                bossHealth.anim.SetBool("Attack", true);
                attacking = true;
                laserSpawn.SetActive(true);
                if(timer > 10)
                {
                    timer = 0;
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                bossHealth.anim.SetBool("Attack", false);
                attacking = false;
                laserSpawn.SetActive(false);
            }

            if (transform.position.x < player.transform.position.x)
            {
                transform.localScale = new Vector3(10, 10, 0);
            }
            else
            {
                transform.localScale = new Vector3(-10, 10, 0);
            }
        }
    }
}
