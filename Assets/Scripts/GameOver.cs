using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public static bool GameIsEnded = false;

    [SerializeField]
    private GameObject MenuUI;
    
    public void DisplayGameOver()
    {
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsEnded = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsEnded = false;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
