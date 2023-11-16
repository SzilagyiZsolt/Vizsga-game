using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject sword;
    public Animator anim;
    public Animator swordanim;
    public GameObject text;
    public float timer=2;
    public bool open = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
