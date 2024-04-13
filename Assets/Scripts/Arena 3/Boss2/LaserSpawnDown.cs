using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawnDown : MonoBehaviour
{
    public GameObject laserDown;
    public Transform laserTransformDown;

    void Start()
    {
        Instantiate(laserDown, laserTransformDown.position, transform.rotation);
    }
}
