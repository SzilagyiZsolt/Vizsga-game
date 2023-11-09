using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SlimeDeath : MonoBehaviour
{
    private GameObject[] wall;
    public float timer;
    public SlimeHealth slimeHealth;
    private void Start()
    {
        GameObject walls = GameObject.FindWithTag("Wall");
        slimeHealth = GetComponent<SlimeHealth>();
    }
    private void Update()
    {
        if (slimeHealth.slimeHealth <= 0)
        {
            timer+=Time.deltaTime;
            if (timer>1.4)
            {
                Destroy(gameObject);
            }
            slimeHealth.anim.SetBool("Death", true);
            slimeHealth.slimealive = false;
            wall[0].SetActive(false);
            wall[1].SetActive(false);
            wall[2].SetActive(false);
        }
    }
}
