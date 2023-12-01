using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject slime;
    public GameObject spawnPoint;
    public CountDown countDown;
    public float timer;
    private void Update()
    {
        timer+=Time.deltaTime;
        SpawnSlime();
    }
    public void SpawnSlime()
    {
        if (timer >= 5 && countDown.countDown>=1)
        {
            Instantiate(slime, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, 0), transform.rotation);
            timer=0;
        }
    }
}
