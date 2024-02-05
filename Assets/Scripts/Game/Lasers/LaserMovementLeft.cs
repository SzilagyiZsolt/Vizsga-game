using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovementLeft : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity= Vector2.left*speed;
    }
}
