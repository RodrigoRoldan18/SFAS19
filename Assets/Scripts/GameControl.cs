using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
    [SerializeField]
    private int levelToUnlock = 2;

    [SerializeField]
    private int coinValue = 1;

    [SerializeField]
    private int enemyValue = 5;

    [SerializeField]
    private float enemyTimeValue = 10f;

    private bool stopUpdating = false;       
    private int HighscoreLevel1, HighscoreLevel2, HighscoreLevel3, Score;
    private UIManager m_UIManager;

    void Start()
    {
        if(!FindObjectOfType<PlayerController>() && !FindObjectOfType<LevelSelect>())
        {
            ResetValues();
        }           
        GetHighscoreValues();
        int m_Score = PlayerPrefs.GetInt("Score", 0);
        Score = m_Score;
        m_UIManager = FindObjectOfType<UIManager>();
        // Update UI
        if (m_UIManager)
        {
            m_UIManager.SetScoreText(m_Score);
        }
    }

    // Update is called once per frame
    void Update () {
        if (!FindObjectOfType<CoinPickup>() &&
            FindObjectOfType<PlayerController>() &&
            stopUpdating == false)
        {
            WinLevel();
            stopUpdating = true;
        }		
	}

    public void UpdateScoreUI()
    {
        // Update UI
        if (m_UIManager)
        {
            m_UIManager.SetScoreText(Score);
        }
    } 
    
    public void WinLevel()
    {
        Debug.Log("LEVEL WON");
        int timeLeftPoints =(int) m_UIManager.timeLeft * 100;            
        if(SceneManager.GetActiveScene().name == "MainScene")
        {
            if(Score + timeLeftPoints > HighscoreLevel1)
             {
                PlayerPrefs.SetInt("HighscoreLevel1", Score + timeLeftPoints);
             }
        } else if (SceneManager.GetActiveScene().name == "Level1")
        {
            if(Score + timeLeftPoints > HighscoreLevel2)
            {
                PlayerPrefs.SetInt("HighscoreLevel2", Score + timeLeftPoints);
            }
        } else if(SceneManager.GetActiveScene().name == "Level2")
        {
            if(Score + timeLeftPoints > HighscoreLevel3)
            {
                PlayerPrefs.SetInt("HighscoreLevel3", Score + timeLeftPoints);
            }
        }
        
        PlayerPrefs.SetInt("levelReached", levelToUnlock);                       
        PlayerPrefs.SetInt("Score", Score + timeLeftPoints);
        UpdateScoreUI();
        FindObjectOfType<LevelWon>().DisplayLevelWon();
    } 
    
    public void AddCoin()
    {        
        Score += coinValue;
        PlayerPrefs.SetInt("Score", Score);        
    }

    public void PointsForEnemy()
    {
        Score += enemyValue;
        m_UIManager.timeLeft += enemyTimeValue;
        PlayerPrefs.SetInt("Score", Score);

    }

    void ResetValues()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("levelReached", 1);
        PlayerPrefs.SetInt("HighscoreLevel1", 0);
        PlayerPrefs.SetInt("HighscoreLevel2", 0);
        PlayerPrefs.SetInt("HighscoreLevel3", 0);
    }

    void GetHighscoreValues()
    {
        HighscoreLevel1 = PlayerPrefs.GetInt("HighscoreLevel1", 0);
        HighscoreLevel2 = PlayerPrefs.GetInt("HighscoreLevel2", 0);
        HighscoreLevel3 = PlayerPrefs.GetInt("HighscoreLevel3", 0);        
    }

}
