using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArcherDeath : MonoBehaviour
{
    public float timer;
    public ArcherMovement archerMovement;
    public GameObject deadpanel;
    public GameObject HUD;
    public ArcherHealth archerHealth;

    private void Update()
    {
        if (archerHealth.health <= 0)
        {
            timer += Time.deltaTime;
            Time.timeScale= 0.2f;
            if (timer > 1)
            {
                deadpanel.SetActive(true);
                HUD.SetActive(false);
                Time.timeScale = 1f;
            }
            archerMovement.anim.SetBool("Death", true);
            archerMovement.alive = false;
        }
    }
}
