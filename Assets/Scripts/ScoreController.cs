using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public int score;
    public TMP_Text scoreValue;
    
    public void ChangeScore(int sentScore)
    {
        score += sentScore;
        scoreValue.text = "Score: " + score.ToString();
        GameData.score = score;

        if (score > GameData.highscore)
        {
            GameData.highscore = score;
        }

        //if(score < 0)
        //{
        //    ChangeScore(0);
        //}
    }
}
