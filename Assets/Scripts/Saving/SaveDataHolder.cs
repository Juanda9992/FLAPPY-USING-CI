using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class SaveDataHolder : MonoBehaviour
{
    public static SaveDataHolder instance;
    public SaveModel data;
    private void Awake() 
    {
        instance = this;
    }
}
