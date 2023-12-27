using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelButtons : MonoBehaviour
{
    public Image Arena1;
    public Image Arena2;
    public bool pressedArean1 = false;
    public bool pressedArean2 = false;
    void Update()
    {
        //Level1
        if (pressedArean1)
        {
            Arena1.fillAmount -= Time.deltaTime;
        }
        if (Arena1.fillAmount == 0)
        {
            SceneManager.LoadScene("Arena1");
        }

        //Level2
        if (pressedArean2)
        {
            Arena2.fillAmount -= Time.deltaTime;
        }
        if (Arena2.fillAmount == 0)
        {
            SceneManager.LoadScene("Arena2");
        }
    }
    public void LevelLoadingArena1()
    {
        pressedArean1 = true;
        
    }
    public void LevelLoadingArena2()
    {
        pressedArean2 = true;
    }
}
