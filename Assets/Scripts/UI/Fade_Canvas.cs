using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.UI;

public class Fade_Canvas : MonoBehaviour
{
    public static Fade_Canvas fade_canvas_inst;
    public CanvasGroup canvas;
    void Start()
    {
        if(fade_canvas_inst == null)
        {
            fade_canvas_inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void showPanel(string scene)
    {
        float delay = 0;
        bool toMainMenu = false;
        if(scene == "SampleScene")
        {
            toMainMenu = false;
            delay = 1;
        }
        else if(scene == "Main_Menu")
        {
            delay = 0;
            toMainMenu =true;
        }
        canvas.DOFade(1,0.2f).SetDelay(delay).OnComplete(()=>Scene_Loader.scene_Loader_inst.LoadScene(scene));
        canvas.DOFade(0,0.2f).SetDelay(delay +0.3f).OnComplete(()=>Stats_Handler.stats_Handler_inst.SetStats());
        if(!scene.StartsWith("Icon"))
        {
            if(!toMainMenu)
            {
                Audio_Manager.instance.ChangeMusic();
            }
            else
            {
                Audio_Manager.instance.ChangeMusic(false);
            }
        }
        Audio_Manager.instance.SetVolume();
    }

}