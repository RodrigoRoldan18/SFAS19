using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public Transform coinEffect;
    public int coinValue = 1;    

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameControl>().AddCoin();          
            var effect = Instantiate(coinEffect, transform.position, transform.rotation);
            Destroy(effect.gameObject, 3);
            Destroy(gameObject);
            FindObjectOfType<GameControl>().UpdateScoreUI();
        }
    }
}
