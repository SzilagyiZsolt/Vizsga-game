using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SaveManager : MonoBehaviour
{
    public PlayerXP playerXP;
    public PlayerHealth playerHealth;
    public PlayerAttack playerAttack;
    public ShopHPText hpText;
    public ShopDMGText dmgText;
    public XPSkeletonKing xpSkeletonKing;
    public Text DMGText;
    public Text HPText;
    public Text coinText;
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
    public void saveSkeletonKing()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}SecretBoss.dat");
            SaveData data = new SaveData();
            Debug.Log("Quick save");
            SaveSkeletonKing(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void Save3()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}.dat");
            SaveData data = new SaveData();
            Debug.Log("Quick save");
            SavePlayer2(data);
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
    public void SaveSkeletonKing(SaveData data)
    {
        data.SkeletonKingData=new SkeletonKingData(xpSkeletonKing.skeletonKingLevel);
    }
    public void SavePlayer2(SaveData data)
    {
        data.MyPlayerData=new PlayerData(int.Parse(hpText.coinText.text), int.Parse(hpText.MaxHPText.text), int.Parse(dmgText.DMGText.text));
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
        playerHealth.maxHealth=data.MyPlayerData.MyMaxHP;
        playerAttack.damage=data.MyPlayerData.MyDamage;
    }
    public void SaveShop(SaveData Shopdata)
    {
        Shopdata.MyShopData=new ShopData(hpText.price, dmgText.price, int.Parse(DMGText.text), int.Parse(HPText.text));
    }
    public void Save2()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}Shop.dat");
            SaveData Shopdata = new SaveData();
            Debug.Log("Quick Shop save");
            SaveShop(Shopdata);
            bf.Serialize(file, Shopdata);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void LoadShopdata(SaveData Shopdata)
    {
        hpText.HP=Shopdata.MyPlayerData.MyMaxHP;
        dmgText.DMG=Shopdata.MyPlayerData.MyDamage;
        hpText.MaxHPText.text=Shopdata.MyPlayerData.MyMaxHP.ToString();
        dmgText.DMGText.text=Shopdata.MyPlayerData.MyDamage.ToString();
        hpText.coinText.text=Shopdata.MyPlayerData.MyCoin.ToString();
    }
    public void LoadShopdata2(SaveData Shopdata2)
    {
        dmgText.price=Shopdata2.MyShopData.DMGPrice;
        hpText.price=Shopdata2.MyShopData.HPPrice;
    }
    public void LoadShop()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}.dat", FileMode.Open);
            SaveData Shopdata = (SaveData)bf.Deserialize(file);
            Debug.Log("First Quick load");
            file.Close();
            LoadShopdata(Shopdata);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void LoadShop2()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}Shop.dat", FileMode.Open);
            SaveData Shopdata2 = (SaveData)bf.Deserialize(file);
            Debug.Log("Shop Quick load");
            file.Close();
            LoadShopdata2(Shopdata2);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void FileCheck()
    {
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}Shop.dat"))
        {
            LoadShop2();
        }
    }
    public void LoadSkeletonKing(SaveData data)
    {
        xpSkeletonKing.skeletonKingLevel=data.SkeletonKingData.SkeletonKingXP;
    }
    public void loadSkeletonKing()
    {
        Debug.Log($"{DBManager.username}.dat");
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}SecretBoss.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            Debug.Log("Quick load");
            file.Close();
            LoadSkeletonKing(data);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    
}
