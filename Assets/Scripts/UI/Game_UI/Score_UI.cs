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

    private void Start() 
    {
        Save();    
    }
    private void IncreaseScore()
    {
        score++;
        SaveDataHolder.instance.data.totalScore++;
        if(score > maxScore)
        {
            maxScore = score;
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
        maxScore= SaveDataHolder.instance.data.highestScore;
        if(score > maxScore)
        {
            SaveDataHolder.instance.data.highestScore = score;
        }
    }
}
