using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderTaleHP : MonoBehaviour
{
    public int HP;
    public GameObject deadPanel;
    private void Update()
    {
        if (HP<=0)
        {
            deadPanel.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            HP--;
        }
    }
}
