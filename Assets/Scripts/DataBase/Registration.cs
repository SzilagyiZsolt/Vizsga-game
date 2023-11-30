using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public float timer;
    [HideInInspector] public GameObject error;
    [HideInInspector] public GameObject success;
    [HideInInspector] public InputField nameField;
    [HideInInspector] public InputField passwordField;
    [HideInInspector] public Button RegisterButton;

    private void Start()
    {
        VerfyInputs();   
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3) 
        {
            success.SetActive(false);
            error.SetActive(false);
        }
    }
    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/Vizsga%20game/RegisterUser.php", form);
        yield return www;
        if (www.text=="0")
        {
            timer = 0;
            Debug.Log("User created succesfully.");
            success.SetActive(true);
            error.SetActive(false);
        }
        else
        {
            timer = 0;
            Debug.Log("User creation failed. Error #"+www.text);
            error.SetActive(true);
            success.SetActive(false);
        }

    }
    public void VerfyInputs()
    {
        RegisterButton.interactable=(nameField.text.Length>=4 && passwordField.text.Length>=5);
    }
}
