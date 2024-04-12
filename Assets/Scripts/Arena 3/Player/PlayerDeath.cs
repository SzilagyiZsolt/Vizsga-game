using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public PlayerHealt playerHealth;
    public Animator anim;
    public GameObject deadpanel;
    public BoxCollider2D boxCollider;
    public float timer;
    private void Start()
    {
        playerHealth = GetComponent<PlayerHealt>();
        anim = GetComponentInChildren<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();
    }

    void Update()
    {
        if (!playerHealth.alive)
        {
            timer += Time.deltaTime;
            anim.SetBool("Death", true);
            Destroy(boxCollider);
            if (timer > 2)
            {
                Cursor.visible = true;
                deadpanel.SetActive(true);
            }
        }
    }
}
