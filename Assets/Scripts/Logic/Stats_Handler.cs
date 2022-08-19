using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_Handler : MonoBehaviour
{
    public static Stats_Handler stats_Handler_inst;
    public float totalPlayTime = 0;
    public int totalJumps = 0;
    public int totalScore = 0;
    public int highestScore = 0;
    public int totalDeaths = 0;
    public int totalBombs = 0;
    public int totalHearts = 0;


    void Awake()
    {
        if(stats_Handler_inst == null)
        {
            stats_Handler_inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        ReadStats();
    }

    public void ReadStats()
    {
        totalPlayTime = PlayerPrefs.GetFloat("TotalPlayTime");
        totalJumps = PlayerPrefs.GetInt("TotalJumps");
        totalScore = PlayerPrefs.GetInt("TotalScore");
        highestScore = PlayerPrefs.GetInt("MaxScore");
        totalDeaths = PlayerPrefs.GetInt("TotalDeaths");
        totalBombs = PlayerPrefs.GetInt("TotalBombs");
        totalHearts = PlayerPrefs.GetInt("TotalHearts");
    }

    public void SetStats()
    {
        PlayerPrefs.SetFloat("TotalPlayTime",totalPlayTime);
        PlayerPrefs.SetInt("TotalJumps",totalJumps);
        PlayerPrefs.SetInt("TotalScore",totalScore);
        PlayerPrefs.SetInt("MaxScore",highestScore);
        PlayerPrefs.SetInt("TotalDeaths",totalDeaths);
        PlayerPrefs.SetInt("TotalBombs",totalBombs);
        PlayerPrefs.SetInt("TotalHearts",totalHearts);
    }

    private void OnApplicationQuit() 
    {
        SetStats();    
    }
}
