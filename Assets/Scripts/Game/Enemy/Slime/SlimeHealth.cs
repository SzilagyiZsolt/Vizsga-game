using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeHealth : MonoBehaviour
{
    public PlayerAttack playerAttack;
    public Animator anim;
    public Slider hpBar;
    public float timer;
    public float slimeMaxHealth;
    public float slimeHealth;
    public bool slimealive = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        slimeHealth = slimeMaxHealth;
        GameObject player = GameObject.FindWithTag("Player");
        playerAttack = player.GetComponent<PlayerAttack>();
        hpBar.maxValue = slimeMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = slimeHealth;
        timer += Time.deltaTime;
        if (timer > 0.3)
        {
            anim.SetBool("Hurt", false);
        }
        
    }
    public void TakeDamage(float damage)
    {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                playerAttack.click++;
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                playerAttack.timer -= Time.deltaTime;
                if (playerAttack.timer <= 0.5 && playerAttack.click <= 1)
                {
                    slimeHealth -= damage;
                    anim.SetBool("Hurt", true);
                    timer = 0;
                    playerAttack.timer = 1;
                    playerAttack.spamdef = 0;
                }
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                playerAttack.timer = (float)0.5;
            }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hitbox"))
        {
            TakeDamage(playerAttack.damage);
        }
    }
}
