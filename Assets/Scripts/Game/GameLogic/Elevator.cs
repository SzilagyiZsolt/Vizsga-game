using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Animator anim;
    public UnderTaleEvent underTaleEvent;
    public PlayerMovement playerMovement;
    public Rigidbody2D rbElevator;
    public bool isOn=false;

    private void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        playerMovement = p.GetComponent<PlayerMovement>();
        anim=p.GetComponent<Animator>();
    }
    private void Update()
    {
        if (isOn)
        {
            rbElevator.velocity = Vector2.up;
        }
        else
        {
            rbElevator.velocity = Vector2.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && underTaleEvent.isOn==false)
        {
            anim.SetBool("Empty", true);
            playerMovement.moveSpeed = 0;
            playerMovement.jumpForce = 0;
            isOn=true;
        }
    }
}
