using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game_Settings : MonoBehaviour
{
    [SerializeField] private Slider sxfSlider,musicSlider;
    [SerializeField] private Toggle vSyncToggle;
    private void Start() 
    {
        vSyncToggle.isOn = SaveDataHolder.instance.data.vSyncActive;
        ToggleVSync();
    }
    public void ToggleVSync()
    {
        if(vSyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        SaveDataHolder.instance.data.vSyncActive = vSyncToggle.isOn;
        Debug.Log(QualitySettings.vSyncCount);
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
