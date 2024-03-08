using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMovement : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public Transform Player;
    public KnightHealth knightHealth;
    public Vector3 direction;
    public int damage;
    public float timer;
    public float timer2;
    public float speed;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Player = player.GetComponent<Transform>();
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
        knightHealth=player.GetComponent<KnightHealth>();
    }
    private void Update()
    {
        timer+=Time.deltaTime;
        if (timer > 1)
        {
            if (transform.position.y<1.5 && timer<2)
            {
                rb.velocity=new Vector2(0, 1);
            }
            else
            {
                timer2+=Time.deltaTime;
                rb.velocity=new Vector2(0, 0);
                if (timer2>1.7 && timer2<2.5)
                {
                    direction = (Player.position-transform.position).normalized;
                }
                else if (timer2>2.1)
                {
                    transform.position+=direction*speed*Time.deltaTime;
                }
            }
        }
        if (Vector2.Distance(transform.position,Player.position)==0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            knightHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Trigger"))
        {
            Destroy(gameObject);
        }
    }
}
