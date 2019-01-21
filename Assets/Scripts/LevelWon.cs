using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWon : MonoBehaviour {

    public static bool LevelIsWon = false;

    [SerializeField]
    private GameObject MenuUI;
    
    [SerializeField]
    private Text Score;

    [SerializeField]
    private Text Highscore;

    public void DisplayLevelWon()
    {
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
        LevelIsWon = true;
        Score.text = "SCORE: " + PlayerPrefs.GetInt("Score");
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            Highscore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighscoreLevel1");
        }
        else if (SceneManager.GetActiveScene().name == "Level1")
        {
            Highscore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighscoreLevel2");
        }              
    }

    public void LoadLevelSelector()
    {
        Time.timeScale = 1f;
        LevelIsWon = false;
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("LevelSelector");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }    	
}