using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaWalls : MonoBehaviour
{
    public Transform wallRight;
    public Transform wallLeft;
    public CountDown countDown;
    public Vector2 targetRight;
    public Vector2 targetLeft;
    public float speedRight;
    public float speedLeft;

    private void Start()
    {
        GameObject count = GameObject.FindWithTag("CountDown");
        countDown=count.GetComponent<CountDown>();
        targetRight=new Vector2(-1, -1);
        targetLeft=new Vector2(26, 10.1f);
    }
    private void Update()
    {
        RightWallMove();
        LeftWallMove();
    }
    public void RightWallMove()
    {
        wallRight.transform.position=Vector2.MoveTowards(wallRight.transform.position, targetRight, speedRight*Time.deltaTime);
    }
    public void LeftWallMove()
    {
        wallLeft.transform.position=Vector2.MoveTowards(wallLeft.transform.position, targetLeft, speedLeft*Time.deltaTime);
    }
}
