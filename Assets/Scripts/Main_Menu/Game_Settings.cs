using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game_Settings : MonoBehaviour
{
    [SerializeField] private Slider sxfSlider,musicSlider;
    private bool vSync = true;


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

    public void ChangeVolumeSlider(float volume)
    {
        Audio_Manager.instance.ChangeVolume(volume * volume);
        PlayerPrefs.SetFloat("sfxVol",volume * volume);
    }

    public void ChangeMusicSlider(float volume)
    {
        Audio_Manager.instance.ChangeVolume(volume,false);
        PlayerPrefs.SetFloat("musicVol",volume);
    }

    public void ReadVolumeValues()
    {
        sxfSlider.value = PlayerPrefs.GetFloat("sfxVol");
        musicSlider.value = PlayerPrefs.GetFloat("musicVol");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
