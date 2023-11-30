using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [HideInInspector] public GameObject sword;
    [HideInInspector] public Animator anim;
    [HideInInspector] public Animator swordanim;
    [HideInInspector] public GameObject text;
    public float timer=2;
    public bool open = false;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.4 && open) 
        {
            Destroy(swordanim);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {   
                open = true;
                timer=0;
                anim.SetBool("Player", true);
                sword.SetActive(true);
                swordanim.SetBool("Open", true);
            }
            text.SetActive(true);
        }
    }
}
