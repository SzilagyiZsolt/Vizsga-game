using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AttackBrownSlime : MonoBehaviour
{
    public MovementBrownSlime brownSlimeMovement;
    public GameObject enemy;
    public Transform spawnPoint;
    public float timer;

    private void Start()
    {
        brownSlimeMovement=GetComponent<MovementBrownSlime>();
    }
    private void Update()
    {
        
        if (brownSlimeMovement.chasing==false)
        {
            timer+=Time.deltaTime;
            if (timer > 0.8)
            {
                Spawn();
            }
        }
    }
    public void Spawn()
    {
        Instantiate(enemy, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y-0.05f, 0), transform.rotation);
        timer=0;
    }
}
