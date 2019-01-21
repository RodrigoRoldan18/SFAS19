using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

    [SerializeField]
    private Button[] levelButtons;

    [SerializeField]
    private Text[] Highscores;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        //Debug.Log(levelReached);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
            if (i == 0)
            {
                Highscores[i].text = "Highscore: " + PlayerPrefs.GetInt("HighscoreLevel1", 0);
            } else if (i == 1)
            {
                Highscores[i].text = "Highscore: " + PlayerPrefs.GetInt("HighscoreLevel2", 0);
            }           
        }
    }

	public void Select (string levelName)
    {
        SceneManager.LoadScene(levelName);        
    }

    public void DisplayMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
