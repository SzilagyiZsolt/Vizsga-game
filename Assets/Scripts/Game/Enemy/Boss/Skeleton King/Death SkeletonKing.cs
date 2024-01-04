using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSkeletonKing : MonoBehaviour
{
    [HideInInspector] public GameObject Platform;
    public float timer;
    [HideInInspector] public HealthSkeletonKing skeletonKingHealth;
    private void Start()
    {
        skeletonKingHealth = GetComponent<HealthSkeletonKing>();
    }
    private void Update()
    {
        if (skeletonKingHealth.skeletonKingHealth <= 0)
        {
            timer += Time.deltaTime;
            if (timer > 1.4)
            {
                Destroy(gameObject);
                Platform.SetActive(true);
            }
            skeletonKingHealth.anim.SetBool("Death", true);
            skeletonKingHealth.skeletonKingalive = false;
        }
    }
}
