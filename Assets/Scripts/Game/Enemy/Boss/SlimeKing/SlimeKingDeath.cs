using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SlimeKingDeath : MonoBehaviour
{
    public Animator anim;
    public float timer;
    public bool slimeKingAlive=true;
    void Start()
    {
        anim=GetComponent<Animator>();
    }
    void Update()
    {
        timer+=Time.deltaTime;
        if (timer > 175)
        {
            anim.SetBool("Death", true);
            slimeKingAlive = false;
        }
    }
}
