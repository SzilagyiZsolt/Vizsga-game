using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStats : MonoBehaviour
{
    public SaveManager saveManager;
    void Start()
    {
        saveManager.Load();
    }
}
