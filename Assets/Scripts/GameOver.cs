using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score :  " + GameData.score;
        highScoreText.text = "High Score :  " + GameData.highscore;
    }

    void Update()
    {
        if (Input.anyKeyDown || Input.GetButtonDown("Jump"))
        {
            GameData.score = 0;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
