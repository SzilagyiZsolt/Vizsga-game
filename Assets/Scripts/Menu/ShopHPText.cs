using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
public class ShopHPText : MonoBehaviour
{
    public int price;
    public int HP;
    public Text priceText;
    public Text MaxHPText;
    public Text coinText;
    public void HPBuy()
    {
        price+=2;
        priceText.text=price.ToString();
        HP+=10;
        MaxHPText.text=HP.ToString();
    }
}
