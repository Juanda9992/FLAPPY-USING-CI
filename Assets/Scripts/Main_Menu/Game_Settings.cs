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
            Application.targetFrameRate = 60;
            vSync = true;
        }
        else
        {
            Application.targetFrameRate = 360;
            vSync = false;
        }
    }
}
