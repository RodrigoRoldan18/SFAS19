using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public static bool GameIsEnded = false;

    [SerializeField]
    GameObject MenuUI;
    
    public void DisplayGameOver()
    {
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsEnded = true;
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
    }

    public void LoadLevelSelector()
    {
        GameIsEnded = false;
        Time.timeScale = 1f;        
        SceneManager.LoadScene("LevelSelector");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
