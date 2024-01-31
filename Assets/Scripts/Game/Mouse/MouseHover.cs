using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    public MouseHP mouseHP;
    public float timer;
    private void Update()
    {
        timer+=Time.deltaTime;
    }
    private void OnMouseEnter()
    {
        mouseHP.HP--;
    }
}
