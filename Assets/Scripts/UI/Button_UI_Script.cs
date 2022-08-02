using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_UI_Script : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        Fade_Canvas.fade_canvas_inst.showPanel(scene);
    }

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}
