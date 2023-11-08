using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject slime;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        SpawnSlime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnSlime()
    {
        Instantiate(slime, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, 0), transform.rotation);
    }
}
