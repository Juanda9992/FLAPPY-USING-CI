using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class Scene_Loader : MonoBehaviour
{
    public static Scene_Loader scene_Loader_inst;

    void Awake()
    {
        if(scene_Loader_inst == null)
        {
            scene_Loader_inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void LoadScene(string scene)
    {   Time.timeScale = 1;
        SceneManager.LoadScene(scene);
        
    }


}
