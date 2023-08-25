using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Stats_Manager : MonoBehaviour
{

    public TextMeshProUGUI[] statTexts;

    public SaveModel saveModel;

    void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        statTexts[0].text = "Total Play Time: " + TimeSpan.FromSeconds(saveModel.totalTime);
        statTexts[1].text = "Total Jumps: " + saveModel.totalJumps;
        statTexts[2].text = "Total Score: " + saveModel.totalScore;
        statTexts[3].text = "Highest Score: " + saveModel.highestScore;
        statTexts[4].text = "Total Deaths: " + saveModel.totalDeaths;
        statTexts[5].text = "Total Bombs Collected: " + saveModel.bombsTaken;
        statTexts[6].text = "Total Bombs Fired: " + saveModel.bombsShoot;
        statTexts[7].text = "Total Hearts Collected: " + saveModel.heartsTaken;
    }

}
