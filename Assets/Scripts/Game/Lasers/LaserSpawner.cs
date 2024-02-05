using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public GameObject laserRight;
    public GameObject laserLeft;
    public GameObject[] spawnPoint;
    public float Righttimer;
    public float Lefttimer;
    private void Update()
    {
        Righttimer+=Time.deltaTime;
        Lefttimer+=Time.deltaTime;
        SpawnEnemyRight();
        SpawnEnemyLeft();
    }
    public void SpawnEnemyRight()
    {
        if (Righttimer >= 10)
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(laserRight, new Vector3(spawnPoint[i].transform.position.x, spawnPoint[i].transform.position.y, 0), transform.rotation);
            }
            Righttimer=0;
        }
    }
    public void SpawnEnemyLeft()
    {
        if (Lefttimer >= 7)
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(laserLeft, new Vector3(spawnPoint[i].transform.position.x, spawnPoint[i].transform.position.y, 0), transform.rotation);
            }
            Lefttimer=0;
        }
    }
}
