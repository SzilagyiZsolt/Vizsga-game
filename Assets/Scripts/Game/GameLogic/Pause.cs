using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public bool disable =false;
    public bool inventoryOpen=false;
    public Animator anim;
    public SaveManager saveManager;
    public GameObject settings;
    public GameObject pause;
    public GameObject deadpanel;
    public GameObject inventory;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !disable && !inventoryOpen && playerMovement.alive)
        {
            disable = true;
            PauseGame();
        }
        Inventory();
    }
    
    public void Exit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void Continue()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        anim.SetBool("Pause", false);
        disable= false;
    }
    public void PauseGame()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        anim.SetBool("Pause", true);
    }
    public void Back()
    {
        disable = false;
        settings.gameObject.SetActive(false);
        pause.SetActive(true);
    }
    public void Settings()
    {
        settings.gameObject.SetActive(true);
        pause.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        deadpanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Inventory()
    {
        if(Input.GetKeyDown(KeyCode.I)&&!inventoryOpen && !disable) 
        {
            inventoryOpen = true;
            inventory.gameObject.SetActive(true);
            Time.timeScale = 0f;
            anim.SetBool("Pause", true);
        }
        else if(Input.GetKeyDown(KeyCode.I) && inventoryOpen && !disable)
        {
            inventoryOpen = false;
            inventory.gameObject.SetActive(false);
            Time.timeScale = 1f;
            anim.SetBool("Pause", false);
        }
    }
    public void LevelSelector()
    {
        SceneManager.LoadScene("Level Selector");
    }
}
