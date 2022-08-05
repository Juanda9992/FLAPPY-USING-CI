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
        canvas.DOFade(1,0.2f).OnComplete(()=>Scene_Loader.scene_Loader_inst.LoadScene(scene));
        canvas.DOFade(0,0.2f).SetDelay(0.2f).OnComplete(()=>Stats_Handler.stats_Handler_inst.SetStats());
    }

}