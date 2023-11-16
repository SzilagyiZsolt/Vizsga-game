using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Coin : MonoBehaviour
{
    public Text coinText;
    public int coinAmount=0;
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("player"))
        {
            coinAmount++;
            coinText.text = coinAmount.ToString();
            Destroy(gameObject);
        }
    }
}
