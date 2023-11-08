using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSkeletonKing : MonoBehaviour
{
    public float timer;
    public HealthSkeletonKing skeletonKingHealth;
    private void Start()
    {
        GameObject walls = GameObject.FindWithTag("Wall");
        skeletonKingHealth = GetComponent<HealthSkeletonKing>();
        //wall = walls.GetComponent<GameObject[]>();
    }
    private void Update()
    {
        if (skeletonKingHealth.skeletonKingHealth <= 0)
        {
            timer += Time.deltaTime;
            if (timer > 1.4)
            {
                Destroy(gameObject);
            }
            skeletonKingHealth.anim.SetBool("Death", true);
            skeletonKingHealth.skeletonKingalive = false;
        }
    }
}
