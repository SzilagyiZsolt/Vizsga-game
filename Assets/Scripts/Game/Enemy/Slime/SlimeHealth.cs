using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : MonoBehaviour
{
    public Animator anim;
    public float timer;
    public float slimeMaxHealth = 50;
    public float slimeHealth;
    public bool slimealive = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        slimeHealth = slimeMaxHealth;
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
        slimeHealth -= damage;
        anim.SetBool("Hurt", true);
        timer = 0;
    }
}
