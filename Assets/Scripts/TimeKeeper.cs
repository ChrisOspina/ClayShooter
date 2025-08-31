using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeKeeper : MonoBehaviour
{
    public TMP_Text timeText;

    // Update is called once per frame
    void Update()
    {
        GameData.time -= Time.deltaTime;

        if(GameData.time <= 0)
        {
            TimeUp();
        }
        timeText.text = "Time: " + GameData.time.ToString("0.0");
    }

    private void TimeUp()
    {
        SceneManager.LoadScene("GameOver");
    }
}
