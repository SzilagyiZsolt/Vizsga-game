using System;
using System.Numerics;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveData
{
    public PlayerData MyPlayerData {  get; set; }
    public SaveData() 
    {
        
    }

}
[Serializable]
public class PlayerData
{
    public int MyLevel { get; set; }
    public int MyMaxXP { get; set; }
    public int MyCurrentXP { get; set; }
    public int MyCoin { get; set; }
    public int MyMaxHP { get; set; }
    public int MyCurrentHP { get; set; }
    public int MyDamage { get; set; }
    public PlayerData(int level, int MaxXP, int CurrentXP, int Coin, int MaxHP, int CurrentHP, int Damage) 
    {
        this.MyLevel=level;
        this.MyMaxXP=MaxXP;
        this.MyCurrentXP=CurrentXP;
        this.MyCoin=Coin;
        this.MyMaxHP=MaxHP;
        this.MyCurrentHP=CurrentHP;
        this.MyDamage=Damage;
    }

}
