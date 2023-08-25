using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class SaveManager : MonoBehaviour
{
    public SaveModel saveModel;
    public static SaveManager instance;
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        Load();
        StartCoroutine("Save");
    }
    

    public void Load()
    {
        string json =PlayerPrefs.GetString("json"); 
        JsonConvert.PopulateObject(json,saveModel);
    }
    public IEnumerator Save()
    {
        while(true)
        {
            string json = JsonConvert.SerializeObject(saveModel);
            PlayerPrefs.SetString("json",json);
            Debug.Log(json);
            yield return new WaitForSeconds(60);
        }
    }
}
