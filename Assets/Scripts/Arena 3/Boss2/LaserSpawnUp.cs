using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawnUp : MonoBehaviour
{
    public GameObject laserUp;
    public Transform laserTransformUp;

    void Start()
    {
        Instantiate(laserUp, laserTransformUp.position, transform.rotation);
    }
}
