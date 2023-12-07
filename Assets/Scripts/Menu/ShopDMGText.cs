using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopDMGText : MonoBehaviour
{
    public int price;
    public int DMG;
    public Text priceText;
    public Text DMGText;
    public void DMGBuy()
    {
        price+=2;
        priceText.text=price.ToString();
        DMG+=5;
        DMGText.text=DMG.ToString();
    }
}
