using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SlimeDeath : MonoBehaviour
{
    private GameObject[] wall;
    public GameObject coin;
    public float timer;
    public SlimeHealth slimeHealth;
    public SlimeXP slimeXP;
    public int counter;
    private void Start()
    {
        slimeHealth = GetComponent<SlimeHealth>();
        slimeXP = GetComponent<SlimeXP>();
    }
    private void Update()
    {
        if (slimeHealth.slimeHealth <= 0)
        {
            counter++;
            if (counter == 10)
            {
                slimeXP.SlimeGiveXP();
            }
            timer+=Time.deltaTime;
            if (timer>0.2)
            {
                coin.SetActive(true);
                if (timer>15)
                {
                    Destroy(gameObject);
                }
            }
            slimeHealth.anim.SetBool("Death", true);
            slimeHealth.slimealive = false;
            wall[0].SetActive(false);
            wall[1].SetActive(false);
            wall[2].SetActive(false);
        }
    }
}
