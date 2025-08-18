using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public Button optionsButton;

    void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(StartGame);
        }
        if (quitButton != null) 
        {
            quitButton.onClick.AddListener(QuitGame);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
