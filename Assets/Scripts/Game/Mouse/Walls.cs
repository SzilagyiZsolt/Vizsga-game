using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public MouseHP mouseHP;
    private void Start()
    {
        GameObject m = GameObject.FindGameObjectWithTag("LogicManager");
        mouseHP = m.GetComponent<MouseHP>();
    }
    private void OnMouseEnter()
    {
        mouseHP.HP = 0;
    }
}
