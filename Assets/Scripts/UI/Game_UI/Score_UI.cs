using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_UI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText, maxScoreText;
    public int score;
    private int maxScore;
    private int maxScoreSession = 0;
    private void IncreaseScore()
    {
        score++;
        if(score > maxScoreSession)
        {
            maxScoreSession = score;
        }
        Save();
        scoreText.text = score.ToString();
    }

    private void OnEnable() 
    {
        GameOver_UI.onRestart += resetScore;
        Player_Jump.onPlayerScored += IncreaseScore;    
    }

    private void OnDisable() 
    {
        GameOver_UI.onRestart -= resetScore;
        Player_Jump.onPlayerScored -= IncreaseScore;    
    }

    private void resetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    private void Save()
    {
        maxScore= PlayerPrefs.GetInt("MaxScore");
        if(maxScoreSession > maxScore)
        {
            PlayerPrefs.SetInt("MaxScore",maxScoreSession);
        }

        Debug.Log(maxScore + " " + maxScoreSession);
    }
}
