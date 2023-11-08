using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public float timer;
    public GameObject clouds;
    // Start is called before the first frame update
    void Start()
    {
        SpawnClouds();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 92)
        {
            SpawnClouds();
            timer = 0;
        }
    }
    public void SpawnClouds()
    {
        Instantiate(clouds, new Vector3(transform.position.x, transform.position.y ,0), transform.rotation);
    }
}
