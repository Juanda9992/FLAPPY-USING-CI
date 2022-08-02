using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_UI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    private int score;

    private void IncreaseScore()
    {
        score++;
        text.text = score.ToString();
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
        text.text = score.ToString();
    }
}
