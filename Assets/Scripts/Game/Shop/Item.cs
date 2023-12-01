using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public ItemType type;
    //public ActionType actionType;
    public Vector2Int range=new Vector2Int(1,1);
    public int id;


    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;
}
public enum ItemType
{
    Sword,
    Armor,
    Potion
}
//public enum ActionType
//{
//    Drink
//}