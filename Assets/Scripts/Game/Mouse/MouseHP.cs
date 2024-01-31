using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHP : MonoBehaviour
{
    public int HP;
    public GameObject deadPanel;
    private void Start()
    {
        HP = 3;
    }
    private void Update()
    {
        if (HP<=0)
        {
            deadPanel.SetActive(true);
        }
    }
}

