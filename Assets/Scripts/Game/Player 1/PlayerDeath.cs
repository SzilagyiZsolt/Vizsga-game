using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerDeath : MonoBehaviour
{
    public float timer;
    public PlayerMovement playerMovement;
    public GameObject deadpanel;
    public GameObject HUD;
    public PlayerHealth playerhealth;

    private void Update()
    {
        if (playerhealth.health <= 0)
        {
            timer += Time.deltaTime;
            Time.timeScale= 0.2f;
            if (timer > 1)
            {
                deadpanel.SetActive(true);
                HUD.SetActive(false);
                Time.timeScale = 1f;
            }
            playerMovement.anim.SetBool("Death", true);
            playerMovement.alive = false;
        }
    }
}
