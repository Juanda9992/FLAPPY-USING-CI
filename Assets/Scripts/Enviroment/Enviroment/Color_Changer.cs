using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Color_Changer : MonoBehaviour
{

    public static void ChangeSpriteColor(SpriteRenderer renderer)
    {
        Debug.Log(renderer);
        renderer.color = Color.black;
        renderer.DOColor(Color.white,1);
    }
}
