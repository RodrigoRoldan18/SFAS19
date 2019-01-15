using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
    [SerializeField]    
    public string nextLevel = "Level1";
    public int levelToUnlock = 2;
    int Score;


    UIManager m_UIManager;

    void Start()
    {
        if(!FindObjectOfType<PlayerController>())
        {
            ResetValues();
        }
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
            FindObjectOfType<PlayerController>())
        {
            WinLevel();
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
        PlayerPrefs.SetInt("Score", Score + timeLeftPoints);
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(nextLevel);
    } 
    
    public void AddCoin()
    {
        //Debug.Log(Score);
        PlayerPrefs.SetInt("Score", Score + 1);
        Score += 1;
    }

    void ResetValues()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("levelReached", 1);
    }

}
