using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderTaleEvent : MonoBehaviour
{
    public float timer;
    public bool isOn=false;
    public GameObject[] gameObjects;
    public Elevator elevator;
    public GameObject UnderTale;
    public GameObject UnderTaleCamera;
    public GameObject VirtualCamera;
    void Update()
    {
        if (isOn)
        {
            elevator.isOn = false;
            timer+=Time.deltaTime;
            if (timer > 1)
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].SetActive(false);
                }
                VirtualCamera.SetActive(false);
                UnderTale.SetActive(true);
                UnderTaleCamera.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Elevator"))
        {
            isOn = true;
        }
    }
}
