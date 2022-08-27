using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Manager : MonoBehaviour
{
    public delegate void onProgressDeleted();
    public static event onProgressDeleted OnProgressDeleted;
    // Start is called before the first frame update
    void Awake()
    {
        if(!PlayerPrefs.HasKey("Icon"))
        {
            PlayerPrefs.SetInt("Icon",0);
        } 
        if(!PlayerPrefs.HasKey("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore",0);
        }       
        if(!PlayerPrefs.HasKey("TotalPlayTime"))
        {
            PlayerPrefs.SetFloat("TotalPlayTime",0);
        }
        if(!PlayerPrefs.HasKey("TotalJumps"))
        {
            PlayerPrefs.SetInt("TotalJumps",0);
        }
        if(!PlayerPrefs.HasKey("TotalScore"))
        {
            PlayerPrefs.SetInt("TotalScore",0);
        }
        if(!PlayerPrefs.HasKey("TotalDeaths"))
        {
            PlayerPrefs.SetInt("TotalDeaths",0);
        }
        if(!PlayerPrefs.HasKey("TotalBombs"))
        {
            PlayerPrefs.SetInt("TotalBombs",0);
        }
        if(!PlayerPrefs.HasKey("TotalHearts"))
        {
            PlayerPrefs.SetInt("TotalHearts",0);
        }
        if(!PlayerPrefs.HasKey("sfxVol"))
        {
            PlayerPrefs.SetFloat("sfxVol",0);
        }
        if(!PlayerPrefs.HasKey("musicVol"))
        {
            PlayerPrefs.SetFloat("musicVol",0);
        }

    }

    [ContextMenu("DeleteProgress")]
    public void DeleteProgress()
    {
        PlayerPrefs.DeleteAll();
        OnProgressDeleted?.Invoke();
    }


}
