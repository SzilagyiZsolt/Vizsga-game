using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    public GameObject[] enemy;
    public float timer;
    public int randomLeft;
    public int randomRight;
    public int randomUp;
    public int randomDown;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            Left();
            Right();
            Up();
            Down();
        }
    }

    public void Left()
    {
        randomLeft = Random.Range(12, -12);
        Instantiate(enemy[0], new Vector3(-23, randomLeft, 0), transform.rotation);
        timer = 0;
    }
    public void Right()
    {
        randomRight= Random.Range(12, -12);
        Instantiate(enemy[1], new Vector3(23, randomRight, 0), transform.rotation);
    }
    public void Up()
    {
        randomLeft = Random.Range(21, -21);
        Instantiate(enemy[2], new Vector3(randomUp, 14, 0), transform.rotation);
    }
    public void Down()
    {
        randomLeft = Random.Range(21, -21);
        Instantiate(enemy[3], new Vector3(randomDown, -14, 0), transform.rotation);
    }
}
