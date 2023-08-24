using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataHolder : MonoBehaviour
{
    public static SaveDataHolder instance;
    public SaveModel data;
    private void Awake() 
    {
        instance = this;
    }

    public void Save()
    {
        
    }
}
