using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(PlayerPrefs.GetInt("Icon"));
        if(!PlayerPrefs.HasKey("Icon"))
        {
            PlayerPrefs.SetInt("Icon",0);
        } 
        if(!PlayerPrefs.HasKey("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore",0);
        }       
    }

}
