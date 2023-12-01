using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelButtons : MonoBehaviour
{
    public Image image;
    public bool pressed = false;
    void Update()
    {
        if (pressed)
        {
            image.fillAmount -= Time.deltaTime;
        }
        if (image.fillAmount==0)
        {
            SceneManager.LoadScene("Arena1");
        }
    }

    public void LevelLoading()
    {
        pressed = true;
    }
}
