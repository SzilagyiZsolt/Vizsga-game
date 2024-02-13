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
    public XPBrownSlime brownSlimeXP;
    public Text DMGText;
    public Text HPText;
    public Text coinText;


    public void TutorialSave()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}.dat");
            SaveData data = new SaveData();
            Debug.Log("Quick save");
            TutorialSavePlayerData(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void TutorialSavePlayerData(SaveData data)
    {
        data.MyPlayerData=new PlayerData(playerXP.coinAmount, playerXP.playerHealth.maxHealth, playerXP.playerAttack.damage);
    }
    public void SavePlayerStats()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}.dat");
            SaveData data = new SaveData();
            Debug.Log("Quick save");
            SavePlayerStatsData(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void SavePlayerStatsData(SaveData data)
    {
        data.MyPlayerCoin=new PlayerCoin(playerXP.coinAmount);
    }

    public void LoadPlayerStats()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            Debug.Log("Quick load");
            LoadPlayerData(data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void LoadPlayerData(SaveData data)
    {
        playerXP.coinAmount=data.MyPlayerData.MyCoin;
        playerHealth.maxHealth=data.MyPlayerData.MyMaxHP;
        playerAttack.damage=data.MyPlayerData.MyDamage;
    }


    public void SavePlayer()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}.dat");
            SaveData data = new SaveData();
            Debug.Log("Quick save");
            SavePlayerData(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void SavePlayerData(SaveData data)
    {
        data.MyPlayerData=new PlayerData(int.Parse(hpText.coinText.text), float.Parse(hpText.MaxHPText.text), float.Parse(dmgText.DMGText.text));
    }


    public void SaveShop()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}Shop.dat");
            SaveData Shopdata = new SaveData();
            Debug.Log("Quick Shop save");
            SaveShopData(Shopdata);
            bf.Serialize(file, Shopdata);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void SaveShopData(SaveData Shopdata)
    {
        Shopdata.MyShopData=new ShopData(hpText.price, dmgText.price, float.Parse(DMGText.text), float.Parse(HPText.text));
    }


    public void LoadDefaultShop()
    {
        if (!File.Exists(Application.dataPath+"/"+$"{DBManager.username}Shop.dat"))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}.dat", FileMode.Open);
                SaveData Shopdata = (SaveData)bf.Deserialize(file);
                Debug.Log("First Quick load");
                LoadDefaultShopdata(Shopdata);
                file.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
    public void LoadDefaultShopdata(SaveData Shopdata)
    {
        hpText.HP=Shopdata.MyPlayerData.MyMaxHP;
        dmgText.DMG=Shopdata.MyPlayerData.MyDamage;
        hpText.MaxHPText.text=Shopdata.MyPlayerData.MyMaxHP.ToString();
        dmgText.DMGText.text=Shopdata.MyPlayerData.MyDamage.ToString();
        hpText.coinText.text=Shopdata.MyPlayerData.MyCoin.ToString();
    }


    public void SaveCoin()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}Coin.dat");
            SaveData data = new SaveData();
            Debug.Log("Quick save");
            SavePlayerCoin(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void SavePlayerCoin(SaveData data)
    {
        data.MyPlayerCoin=new PlayerCoin(playerXP.coinAmount);
    }
    public void SaveCoinShop()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}Coin.dat");
            SaveData data = new SaveData();
            Debug.Log("Quick save");
            SavePlayerCoinShop(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void SavePlayerCoinShop(SaveData data)
    {
        data.MyPlayerCoin=new PlayerCoin(int.Parse(hpText.coinText.text));
    }

    public void LoadCoinShop()
    {
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}Coin.dat"))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}Coin.dat", FileMode.Open);
                SaveData Shopdata = (SaveData)bf.Deserialize(file);
                Debug.Log("First Shop load");
                LoadCoinDataShop(Shopdata);
                file.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
    public void LoadCoinDataShop(SaveData Shopdata)
    {
        hpText.coinText.text=Shopdata.MyPlayerCoin.MyCoin.ToString();
    }
    public void LoadCoin()
    {
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}Coin.dat"))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}Coin.dat", FileMode.Open);
                SaveData Shopdata = (SaveData)bf.Deserialize(file);
                Debug.Log("First Shop load");
                LoadCoinData(Shopdata);
                file.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
    public void LoadCoinData(SaveData Shopdata)
    {
        playerXP.coinAmount=Shopdata.MyPlayerCoin.MyCoin;
    }

    public void FileCheck()
    {
        if (File.Exists(Application.dataPath+"/"+$"{DBManager.username}Shop.dat"))
        {
            LoadShop();
        }
    }
    public void LoadShop()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}Shop.dat", FileMode.Open);
            SaveData Shopdata2 = (SaveData)bf.Deserialize(file);
            Debug.Log("Shop Quick load");
            LoadShopData(Shopdata2);
            file.Close();
            
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void LoadShopData(SaveData Shopdata2)
    {
        dmgText.price=Shopdata2.MyShopData.DMGPrice;
        hpText.price=Shopdata2.MyShopData.HPPrice;
        hpText.HP=Shopdata2.MyShopData.HPText;
        dmgText.DMG=Shopdata2.MyShopData.DMGText;
    }


    public void loadSkeletonKing()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}SecretBossSkeletonKing.dat", FileMode.Open);
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
    public void LoadSkeletonKing(SaveData data)
    {
        xpSkeletonKing.skeletonKingLevel=data.SkeletonKingData.SkeletonKingXP;
    }


    public void saveSkeletonKing()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}SecretBossSkeletonKing.dat");
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
    public void SaveSkeletonKing(SaveData data)
    {
        data.SkeletonKingData=new SkeletonKingData(xpSkeletonKing.skeletonKingLevel);
    }


    public void loadBrownSlime()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath+"/"+$"{DBManager.username}SecretBossBrownSlime.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            Debug.Log("Quick load");
            file.Close();
            LoadBrownSlime(data);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void LoadBrownSlime(SaveData data)
    {
        brownSlimeXP.brownSlimeLevel=data.BrownSlimeData.BrownSlimeXP;
    }


    public void saveBrownSlime()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.dataPath+"/"+$"{DBManager.username}SecretBossBrownSlime.dat");
            SaveData data = new SaveData();
            Debug.Log("Quick save");
            SaveBrownSlime(data);
            bf.Serialize(file, data);
            file.Close();
        }
        catch (System.Exception)
        {
            throw;
        }
    } 
    public void SaveBrownSlime(SaveData data)
    {
        data.BrownSlimeData=new BrownSlimeData(brownSlimeXP.brownSlimeLevel);
    }
}