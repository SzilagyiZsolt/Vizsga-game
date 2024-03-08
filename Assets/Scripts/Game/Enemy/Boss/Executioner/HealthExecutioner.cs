using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthExecutioner : MonoBehaviour
{
    public KnightAttack knightAttack;
    public KnightMovement knightMovement;
    public Animator anim;
    public Rigidbody2D rb;
    public Slider hpBar;
    public float timer;
    public float timer2;
    public float executionerMaxHealth = 50;
    public float executionerHealth;
    public bool executioneralive = true;
    public float kbForce;
    public float kbCounter;
    public float kbTotalTime;
    public bool knockFromRight;
    void Start()
    {
        anim = GetComponent<Animator>();
        executionerHealth = executionerMaxHealth;
        GameObject player = GameObject.FindWithTag("Player");
        knightMovement=player.GetComponent<KnightMovement>();
        knightAttack = player.GetComponent<KnightAttack>();
        rb = GetComponent<Rigidbody2D>();
        hpBar.maxValue = executionerMaxHealth;
    }
    private void Update()
    {
        hpBar.value = executionerHealth;
        timer+=Time.deltaTime;
        timer2+=Time.deltaTime;
    }
    public void TakeDamage(float damage)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            knightAttack.click++;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (timer2 >= 1 && knightAttack.click <= 1)
            {
                if (knockFromRight)
                {
                    rb.velocity = new Vector2(-kbForce, 1);
                }

                if (!knockFromRight)
                {
                    rb.velocity = new Vector2(kbForce, 1);
                }
                kbCounter -= Time.deltaTime;
                executionerHealth -= damage;
                timer2 = 0.5f;
                knightAttack.spamdef = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            timer2 = (float)0.5;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        timer=0;
        if (collision.gameObject.CompareTag("Hitbox") && executioneralive && timer<=1)
        {
            TakeDamage(knightAttack.damage);
        }
    }
}
