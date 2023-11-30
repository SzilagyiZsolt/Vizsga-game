using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DeathSkeleton : MonoBehaviour
{
    public float timer;
    [HideInInspector] public HealthSkeleton skeletonHealth;
    private void Start()
    {
        skeletonHealth = GetComponent<HealthSkeleton>();
    }
    private void Update()
    {
        if (skeletonHealth.skeletonHealth <= 0)
        {
            timer += Time.deltaTime;
            if (timer > 1.4)
            {
                Destroy(gameObject);
            }
            skeletonHealth.anim.SetBool("Death", true);
            skeletonHealth.skeletonalive = false;
        }
    }
}
