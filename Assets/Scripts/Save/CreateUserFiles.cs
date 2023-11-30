using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class CreateUserFiles : MonoBehaviour
{
    public void Save()
    {
        try
        {
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}.dat", FileMode.OpenOrCreate);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
