using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public float timer;
    public CreateUserFiles createUserFiles;
    [HideInInspector] public GameObject error;
    [HideInInspector] public InputField nameField;
    [HideInInspector] public InputField passwordField;
    [HideInInspector] public Button LoginButton;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            error.SetActive(false);
        }
    }
    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }
    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/Vizsga%20game/Login.php", form);
        yield return www;
        if (www.text[0]=='0') 
        {
            DBManager.username=nameField.text;
            SceneManager.LoadScene("Menu");
            if (!File.Exists(Application.dataPath+"/"+$"{nameField.text}.dat"))
            {
                createUserFiles.Save();
            }
        }
        else
        {
            Debug.Log("User login failed. Error #"+www.text);
            error.SetActive(true);
            timer = 0;
        }
    }
    public void VerfyInputs()
    {
        LoginButton.interactable=(nameField.text.Length>=4 && passwordField.text.Length>=5);
    }
}
