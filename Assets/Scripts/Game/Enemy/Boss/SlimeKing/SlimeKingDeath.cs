using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeKingDeath : MonoBehaviour
{
    public Animator anim;
    public float timer;
    public bool slimeKingAlive=true;
    public SaveManager saveManager;
    public GameObject text;
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
            if (timer>177)
            {
                saveManager.saveWorldBoss1();
                text.SetActive(true);
            }
            if (timer>180)
            {
                SceneManager.LoadScene("Level Selector");
            }
        }
    }
}
