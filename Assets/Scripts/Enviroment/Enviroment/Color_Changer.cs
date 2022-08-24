using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Color_Changer : MonoBehaviour
{
    private static Color nextBGColor;
    public static Color nextGColor;
    static Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }
    public static void ChangeBackgroundColor()
    {
        nextBGColor = Random.ColorHSV(0,0.9f,0.8f,1,0.5f,0.6f,1,1);
        GetGroundColor();
        mainCamera.DOColor(nextBGColor,1);
    }
    public static void GetGroundColor()
    {
        nextGColor = Color.red;
    }
    public static void ChangeSpriteColor(SpriteRenderer renderer)
    {
        Audio_Manager.instance.PlaySound("Portal");
        renderer.color = Color.black;
        renderer.DOColor(Color.white,1);
    }
}
