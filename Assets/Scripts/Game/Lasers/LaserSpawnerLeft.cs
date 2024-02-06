using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawnerLeft : MonoBehaviour
{
    public GameObject laserLeft;
    public GameObject laserLeftWarning;
    public GameObject[] spawnPoint;
    public int warningLeftCount;
    public float timerLeft;

    void Update()
    {
        timerLeft+=Time.deltaTime;
        SpawnEnemyLeft();
    }
    public void SpawnEnemyLeft()
    {
        if (timerLeft >= 6)
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                if (warningLeftCount < spawnPoint.Length)
                {
                    Instantiate(laserLeftWarning, new Vector3(spawnPoint[i].transform.position.x, spawnPoint[i].transform.position.y, 0), transform.rotation);
                    warningLeftCount++;
                }
            }
        }
        if (timerLeft >= 7)
        {
            warningLeftCount=0;
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(laserLeft, new Vector3(spawnPoint[i].transform.position.x, spawnPoint[i].transform.position.y, 0), transform.rotation);
            }
            timerLeft=0;
        }
    }
}
