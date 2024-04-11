using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform crosshairTransform;
    public Rigidbody2D rb;
    public Vector3 direction;
    public int speed;
    public float timer;
    void Start()
    {
        GameObject crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        crosshairTransform = crosshair.GetComponent<Transform>();
        direction = crosshairTransform.position - transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 8)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1") || collision.gameObject.CompareTag("Enemy2") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy3"))
        {
            Destroy(gameObject);
        }
    }
}
