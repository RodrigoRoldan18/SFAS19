using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public Transform coinEffect;
    public int coinValue = 1;

    [SerializeField]
    int m_Score = 0;

    UIManager m_UIManager;

    void Start()
    {
        m_UIManager = FindObjectOfType<UIManager>();
        // Update UI
        if (m_UIManager)
        {
            m_UIManager.SetScoreText(m_Score);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            m_Score += coinValue;
            var effect = Instantiate(coinEffect, transform.position, transform.rotation);
            Destroy(effect.gameObject, 3);
            Destroy(gameObject);

            // Update UI
            if (m_UIManager)
            {
                m_UIManager.SetScoreText(m_Score);
            }
        }
    }
}
