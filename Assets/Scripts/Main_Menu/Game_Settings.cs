using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game_Settings : MonoBehaviour
{
    [SerializeField] private Slider sxfSlider,musicSlider;
    [SerializeField] private Toggle vSyncToggle;
    [SerializeField] private Button deleteProgresdsButton;
    private void Start() 
    {
        vSyncToggle.isOn = SaveDataHolder.instance.data.vSyncActive;
        sxfSlider.value = SaveDataHolder.instance.data.sfxVolume;
        musicSlider.value = SaveDataHolder.instance.data.musicVolume;
        deleteProgresdsButton.onClick.AddListener(delegate{PlayerPrefs.DeleteAll();});
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
    }

    public void ChangeVolumeSlider(float volume)
    {
        Audio_Manager.instance.ChangeVolume(volume);
        SaveDataHolder.instance.data.sfxVolume = volume;
    }

    public void ChangeMusicSlider(float volume)
    {
        Audio_Manager.instance.ChangeVolume(volume,false);
        SaveDataHolder.instance.data.musicVolume = volume;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
