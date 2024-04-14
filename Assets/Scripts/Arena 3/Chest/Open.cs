using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{   
    public GameObject pistol;
    public GameObject rifle;
    public Animator anim;
    public float timer;
    public bool open = false;

    private void Update()
    {
        if (open)
        {
            timer += Time.deltaTime;
        }
        if (timer > 1)
        {
            GiveRifle();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sprite"))
        {
            anim.SetBool("Open", true);
            open = true;
        }
    }

    public void GiveRifle()
    {
        pistol.SetActive(false);
        rifle.SetActive(true);
        Destroy(gameObject);
    }
}
