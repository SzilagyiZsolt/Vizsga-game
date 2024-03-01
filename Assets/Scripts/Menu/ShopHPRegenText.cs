using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
public class ShopHPRegenText : MonoBehaviour
{
    public int price;
    public float hpRegen;
    public int coin;
    public Text priceText;
    public Text HPRegenText;
    public Text coinText;
    private void Start()
    {
        priceText.text=price.ToString();
        HPRegenText.text=hpRegen.ToString();
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
            hpRegen+=5;
            HPRegenText.text=hpRegen.ToString();
        }
    }
}
