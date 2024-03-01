using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
public class ShopManaRegenText : MonoBehaviour
{
    public int price;
    public float manaRegen;
    public int coin;
    public Text priceText;
    public Text ManaRegenText;
    public Text coinText;
    private void Start()
    {
        priceText.text=price.ToString();
        ManaRegenText.text=manaRegen.ToString();
    }
    private void Update()
    {
        price=int.Parse(priceText.text);
        coin=int.Parse(coinText.text);
    }
    public void HPRegenBuy()
    {
        if (coin>=int.Parse(priceText.text))
        {
            coin -= int.Parse(priceText.text);
            coinText.text=coin.ToString();
            price+=10;
            priceText.text=price.ToString();
            manaRegen+=5;
            ManaRegenText.text=manaRegen.ToString();
        }
    }
}
