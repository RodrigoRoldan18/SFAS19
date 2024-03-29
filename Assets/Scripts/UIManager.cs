﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    // --------------------------------------------------------------

    [SerializeField]
    Text m_BulletText;

    [SerializeField]
    Text m_GrenadeText;

    [SerializeField]
    Text m_ScoreText;

    //THESE NEXT THINGS WERE ADDED
    [SerializeField]
    Image m_Logo;
    
    public Image m_Ghost;

    [SerializeField]
    float maxTime = 60f;

    public float timeLeft;

    bool stopUpdating = false;    

    // --------------------------------------------------------------

    public void SetAmmoText(int bulletCount, int grenadeCount)
    {
        if(m_BulletText)
        {
            m_BulletText.text = "Bullets: " + bulletCount;
        }
        
        if(m_GrenadeText)
        {
            m_GrenadeText.text = "Grenades: " + grenadeCount;
        }
    }

    public void SetScoreText(int currentScore)
    {
        if(m_ScoreText)
        {
            m_ScoreText.text = "Score: " + currentScore;
        }
    }

    void Start()
    {
        timeLeft = maxTime;
        stopUpdating = false;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            m_Logo.fillAmount = timeLeft / maxTime;
        } else if (timeLeft <= 0 && stopUpdating == false)
        {
            stopUpdating = true;
            FindObjectOfType<GameOver>().DisplayGameOver();            
        }        
    }    
}
