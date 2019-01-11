using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public Transform coinEffect;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Add functionality for coin counter
            var effect = Instantiate(coinEffect, transform.position, transform.rotation);
            Destroy(effect.gameObject, 3);
            Destroy(gameObject); 
        }
    }
}
