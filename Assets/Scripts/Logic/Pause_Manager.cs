using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel; //Panel Object to enable or disable
    private bool isPaused = false; //Is the game paused?
    private float lastTimeScale; //The current Time Scale before pause, if the Time scale is different from 1 (for touching speed), it will set this float to the TimeScale
    private Game_Settings settings;
    [SerializeField] private SaveModel saveData;
    [SerializeField] private Slider volume, music;
    [SerializeField] private MonoBehaviour playerJump;

    void Start()
    {
        playerJump = GameObject.FindObjectOfType<Player_Jump>(); //The player class

    }
    public void PauseGame()
    {


        if(isPaused)
        {
            Audio_Manager.instance.FadeMusicVolumeOut(0.5f);
            isPaused = false; //Switch bool
            Time.timeScale = lastTimeScale; //Last Time scale (if you touch a speed and pause - resume the game it will keep the same timeScale)
            pausePanel.SetActive(false); //Disables the panel
            playerJump.enabled = true; //enables the player class (it prevents the player jump after pressing the button)
        }
        else
        {
            Audio_Manager.instance.FadeMusicVolumeIn(0.5f);
            playerJump.enabled = false; //Disables the player input
            lastTimeScale = Time.timeScale;
            isPaused = true; 
            Time.timeScale = 0; //Freezes the game
            pausePanel.SetActive(true); //Enables the panel
        }

    } 

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) //When you press Esc it will pause - resume the game
        {
            PauseGame();
        }
    }

    private void OnApplicationFocus(bool focusStatus) 
    {
        if(!isPaused &&!focusStatus)
        {
            PauseGame();
        }    
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

}
