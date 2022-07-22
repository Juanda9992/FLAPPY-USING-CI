using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Speed_Controller : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed,minSpeed;

    private const float DefaultSpeed = 1;

    [SerializeField]
    private int obstaclesToRevertTime;
    public int currentObstaclesRemain;

    private void Start() 
    {
        Time.timeScale = 1;
        currentObstaclesRemain = obstaclesToRevertTime;    
    }
    public void changeSpeed(bool timeFaster)
    {
        if(timeFaster)
        {
            Time.timeScale = maxSpeed;
        }
        else
        {
            Time.timeScale = minSpeed;
        }
    }

    public void ResetTime()
    {
        currentObstaclesRemain = obstaclesToRevertTime;
        Time.timeScale = 1;
    }

    public void DecreaseTime()
    {
        if(Time.timeScale != 1)
        {
            if(currentObstaclesRemain > 0)
            {
                currentObstaclesRemain--;
            }
            else
            {
                ResetTime();
            }
        }

    }

    void OnEnable()
    {
        Player_Jump.onPlayerScored += DecreaseTime;
        GameOver_UI.onRestart += ResetTime;
    }

    void OnDisable()
    {
        Player_Jump.onPlayerScored -= DecreaseTime;
        GameOver_UI.onRestart -= ResetTime;
    }
}
