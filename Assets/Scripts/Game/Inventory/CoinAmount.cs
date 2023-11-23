using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAmount : MonoBehaviour
{
    public float timer;
    public GameObject coin;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnCoin()
    {
        Instantiate(coin, new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0), transform.rotation);
    }
}
