using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public float x;
    public float y;
    public Vector3 mousePosition;
    private void Start()
    {
        mousePosition.x=525;
        mousePosition.y=235;
    }
    void Update()
    {
        mousePosition = Input.mousePosition;
        x=mousePosition.x;
        y=mousePosition.y;
    }
}
