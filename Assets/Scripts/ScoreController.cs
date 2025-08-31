using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text scoreValue;
    
    public void ChangeScore(int sentScore)
    {
        GameData.score += sentScore;
        scoreValue.text = "Score: " + GameData.score.ToString();

        if (GameData.score > GameData.highscore)
        {
            GameData.highscore = GameData.score;
        }
    }
}
