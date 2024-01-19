using System;
using System.Numerics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class SaveData
{
    public PlayerData MyPlayerData {  get; set; }
    public ShopData MyShopData { get; set; }
    public SkeletonKingData SkeletonKingData { get; set; }
    public BrownSlimeData BrownSlimeData { get; set; }

public SaveData() 
    {
        
    }

}
[Serializable]
public class PlayerData
{
    public int MyMaxHP { get; set; }
    public int MyDamage { get; set; }
    public int MyCoin { get; set; }
    public PlayerData(int coin,int MaxHP, int Damage) 
    {
        this.MyCoin = coin;
        this.MyMaxHP=MaxHP;
        this.MyDamage=Damage;
    }

}
[Serializable]
public class SkeletonKingData
{
    public int SkeletonKingXP { get; set; }
    public SkeletonKingData(int skeletonKingXP)
    {
        this.SkeletonKingXP = skeletonKingXP;
    }
}
[Serializable]
public class BrownSlimeData
{
    public int BrownSlimeXP { get; set; }
    public BrownSlimeData(int brownSlimeXP)
    {
        this.BrownSlimeXP = brownSlimeXP;
    }
}

[Serializable]
public class ShopData
{
    public int HPPrice { get; set; }
    public int DMGPrice { get; set; }
    public int DMGText { get; set; }
    public int HPText { get; set; }
    public ShopData(int hpprice, int dmgprice, int dmgtext, int hptext)
    {
        this.HPPrice=hpprice;
        this.DMGPrice=dmgprice;
        this.DMGText=dmgtext;
        this.HPText=hptext;
    }
}
