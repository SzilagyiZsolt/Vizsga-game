using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class SaveManager : MonoBehaviour
{
    public PlayerXP playerXP;
    public GameObject player;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            Load();
        }
    }
    public void Save()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}.dat");
            SaveData data = new SaveData();
            Debug.Log("Quick save");
            SavePlayer(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void SavePlayer(SaveData data)
    {
        data.MyPlayerData=new PlayerData(playerXP.coinAmount, playerXP.playerHealth.maxHealth, (int)playerXP.playerAttack.damage);
    }
    public void Load()
    {
        Debug.Log($"{DBManager.username}.dat");
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            Debug.Log("Quick load");
            file.Close();
            LoadPlayer(data);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void LoadPlayer(SaveData data) 
    {
        playerXP.coinAmount=data.MyPlayerData.MyCoin;
        playerXP.playerHealth.maxHealth=data.MyPlayerData.MyMaxHP;
        playerXP.playerAttack.damage=data.MyPlayerData.MyDamage;
        playerXP.UpdateLevel();
    }
}
