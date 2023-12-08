using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
public class ShopHPText : MonoBehaviour
{
    public int price;
    public int HP;
    public int coin;
    public Text priceText;
    public Text MaxHPText;
    public Text coinText;
    private void Update()
    {
        coin=int.Parse(coinText.text);
    }
    public void HPBuy()
    {
        if (coin>=int.Parse(priceText.text))
        {
            coin -= int.Parse(priceText.text);
            price+=2;
            priceText.text=price.ToString();
            HP+=10;
            MaxHPText.text=HP.ToString();
        }
    }
}
