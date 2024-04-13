using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour
{
    public GameObject[] laser;
    public BossMovement2 bossMovement;
    public BossHealth2 bossHealth;
    public Transform[] laserSpawn;

    private void Start()
    {
        Laser();
    }

    public void Laser()
    {
        GameObject LaserLeft = Instantiate(laser[0], laserSpawn[0].position, transform.rotation);
        GameObject LaserRight = Instantiate(laser[1], laserSpawn[1].position, transform.rotation);
    }
}
