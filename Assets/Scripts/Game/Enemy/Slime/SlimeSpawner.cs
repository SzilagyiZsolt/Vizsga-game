using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [HideInInspector] public GameObject slime;
    [HideInInspector] public GameObject spawnPoint;
    void Start()
    {
        SpawnSlime();
    }
    public void SpawnSlime()
    {
        Instantiate(slime, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, 0), transform.rotation);
    }
}
