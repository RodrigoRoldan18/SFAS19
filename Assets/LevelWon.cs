using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWon : MonoBehaviour {

    public static bool LevelIsWon = false;
    public GameObject MenuUI;

    [SerializeField]
    Text Score;

    [SerializeField]
    Text Highscore;

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

        Debug.Log("SCORE: " + PlayerPrefs.GetInt("Score"));
    }

    public void LoadLevelSelector()
    {
        Time.timeScale = 1f;
        LevelIsWon = false;
        SceneManager.LoadScene("LevelSelector");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }     	
}