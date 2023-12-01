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
    public int MyCoin { get; set; }
    public int MyMaxHP { get; set; }
    public int MyDamage { get; set; }
    public PlayerData( int Coin, int MaxHP, int Damage) 
    {
        this.MyCoin=Coin;
        this.MyMaxHP=MaxHP;
        this.MyDamage=Damage;
    }

}
