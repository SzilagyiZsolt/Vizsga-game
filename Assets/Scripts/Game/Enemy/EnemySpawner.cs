using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public CountDown countDown;
    public float timer;
    private void Update()
    {
        timer+=Time.deltaTime;
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        if (timer >= 5 && countDown.countDown>=1)
        {
            timer=0;
        }
    }
}
