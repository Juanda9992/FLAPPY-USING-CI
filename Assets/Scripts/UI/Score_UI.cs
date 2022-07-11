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
        Player_Jump.onPlayerScored += IncreaseScore;    
    }

    private void OnDisable() 
    {
        Player_Jump.onPlayerScored -= IncreaseScore;    
    }
}
