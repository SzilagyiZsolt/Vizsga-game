using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LogicManager : MonoBehaviour
{
    public GameObject settings;
    public GameObject menu;

    public void Exit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Back()
    {
        settings.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Settings()
    {
        menu.gameObject.SetActive(false);
        settings.gameObject.SetActive(true);
    }
    public void NewGame()
    {
        File.Delete(Application.dataPath+"/"+"SaveTest.dat");
        SceneManager.LoadScene("Tutorial");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Levelselector()
    {
        SceneManager.LoadScene("Level selector");
    }
}
