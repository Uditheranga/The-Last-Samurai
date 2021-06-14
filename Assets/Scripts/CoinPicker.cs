using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinPicker : MonoBehaviour
{
    public float coin = 0;

    public Text textCoins;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Coin")
        {
            //SoundManager.PlaySound("Coin");

            coin++;

            textCoins.text = coin.ToString();

            Destroy(other.gameObject);
        }
    }
}
