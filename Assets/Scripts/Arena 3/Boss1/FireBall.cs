using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody2D rb;
    public Animator anim;
    public CircleCollider2D circleCollider;
    public Vector3 direction;
    public float timer;
    public int speed;
    public bool hit = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        direction = playerTransform.position - transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direction.x, direction.y-1).normalized * speed;
    }
    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(playerTransform.position) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + playerTransform.position.y, Vector3.forward);
        transform.rotation = rotation;
        timer += Time.deltaTime;
        if(hit && timer > 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            timer = 0;
            anim.SetBool("Boom", true);
            hit = true;
            Destroy(circleCollider);
            Destroy(rb);
        }
    }
}
