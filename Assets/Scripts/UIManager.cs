using System.Collections;
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
}
