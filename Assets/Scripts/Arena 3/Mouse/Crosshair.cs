using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        Vector2 Crosshair = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Crosshair;
    }
}
