using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkeletonBossDoor : MonoBehaviour
{
    [HideInInspector] public SaveManager saveManager;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                saveManager.Save();
                SceneManager.LoadScene("SkeletonBossLevel");
            }
        }
    }
}
