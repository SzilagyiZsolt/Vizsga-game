using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSkeletonKing : MonoBehaviour
{
    public Animator anim;
    public float timer;
    public float skeletonKingMaxHealth = 50;
    public float skeletonKingHealth;
    public bool skeletonKingalive = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        skeletonKingHealth = skeletonKingMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.3)
        {
            anim.SetBool("Hurt", false);
        }
    }
    public void TakeDamage(float damage)
    {
        skeletonKingHealth -= damage;
        anim.SetBool("Hurt", true);
        timer = 0;
    }
}
