using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public KnightHealth knightHealth;
    public MovementBrownSlime brownSlimeMovement;
    public int damage;
    public float speed;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject brownSlime = GameObject.FindWithTag("BrownSlime");
        rb=GetComponent<Rigidbody2D>();
        knightHealth=player.GetComponent<KnightHealth>();
        brownSlimeMovement=brownSlime.GetComponent<MovementBrownSlime>();
        if (!brownSlimeMovement.rightLook)
        {
            rb.velocity=Vector2.left*speed;
        }
        else
        {
            rb.velocity= Vector2.right*speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            knightHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
