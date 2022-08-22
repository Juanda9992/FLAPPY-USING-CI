using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Settings : MonoBehaviour
{
    private bool vSync = false;

    private void Start() 
    {
        ToggleVSync();  
    }
    public void ToggleVSync()
    {
        if(!vSync)
        {
            if(Platform_Manager.isOnWindows())
            {
                QualitySettings.vSyncCount = 1;
            }
            else
            {
                Application.targetFrameRate = 60;
            }
            
            vSync = true;
        }
        else
        {
            if(Platform_Manager.isOnWindows())
            {
                QualitySettings.vSyncCount = 0;
            }
            else
            {
                Application.targetFrameRate = 120;
            }
            vSync = false;
        }
    }
}
