using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text coinText;
    public Text priceText;
    private int gold;
    private void Update()
    {
        gold=int.Parse(coinText.text);
    }
    public void CoinWatcher()
    {   
        
    }
}
