using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeKeeper : MonoBehaviour
{
    public static float time = 60f;
    public TMP_Text timeText;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            TimeUp();
        }
        timeText.text = "Time: " + time.ToString("0.0");
    }

    private void TimeUp()
    {
        SceneManager.LoadScene("GameOver");
    }
}
