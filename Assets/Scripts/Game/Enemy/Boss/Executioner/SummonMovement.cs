using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMovement : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public Transform summonTargetTransform;
    public Vector3 direction;
    public float timer;
    public float timer2;
    public float speed;
    private void Start()
    {
        GameObject target = GameObject.FindWithTag("SummonTarget");
        summonTargetTransform = target.GetComponent<Transform>();
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
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
                if (timer2>1.7 && timer2<2)
                {
                     direction= new Vector3(summonTargetTransform.position.x,summonTargetTransform.position.y,0);
                }
                else if (timer2>2.1)
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, direction, speed*Time.deltaTime);
                }
            }
        }
    }
}
