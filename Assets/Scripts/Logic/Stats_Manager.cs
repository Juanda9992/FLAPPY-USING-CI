using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats_Manager : MonoBehaviour
{

    public TextMeshProUGUI playTime,jumps,score,highScore,deaths,bombs,hearts;

    void Awake()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        Stats_Handler.stats_Handler_inst.ReadStats();
        playTime.text = "Total Play Time: " + Stats_Handler.stats_Handler_inst.totalPlayTime.ToString("F0");
        jumps.text = "Total Jumps: " + Stats_Handler.stats_Handler_inst.totalJumps;
        score.text = "Total Score: " + Stats_Handler.stats_Handler_inst.totalScore;
        highScore.text = "Highest Score: " + Stats_Handler.stats_Handler_inst.highestScore;
        deaths.text = "Total Deaths: " + Stats_Handler.stats_Handler_inst.totalDeaths;
        bombs.text = "Total Bombs Collected: " + Stats_Handler.stats_Handler_inst.totalBombs;
        hearts.text = "Total Hearts Collected: " + Stats_Handler.stats_Handler_inst.totalHearts;
    }

}
