using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats_Manager : MonoBehaviour
{

    public TextMeshProUGUI playTime,jumps,score,highScore,deaths,bombs,hearts;

    void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        playTime.text = "Total Play Time: " + (Stats_Handler.stats_Handler_inst.totalPlayTime / 60).ToString("F2") + "minutes";
        jumps.text = "Total Jumps: " + Stats_Handler.stats_Handler_inst.totalJumps;
        score.text = "Total Score: " + Stats_Handler.stats_Handler_inst.totalScore;
        highScore.text = "Highest Score: " + Stats_Handler.stats_Handler_inst.highestScore;
        deaths.text = "Total Deaths: " + Stats_Handler.stats_Handler_inst.totalDeaths;
        bombs.text = "Total Bombs Collected: " + Stats_Handler.stats_Handler_inst.totalBombs;
        hearts.text = "Total Hearts Collected: " + Stats_Handler.stats_Handler_inst.totalHearts;
    }

}
