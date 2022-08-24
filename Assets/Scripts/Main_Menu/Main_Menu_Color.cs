using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Main_Menu_Color : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private GameObject textObject;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        ChangeBackGroundColor();
    }

    void Update()
    {
        float sine = (Mathf.Sin(Time.time * 2f)) * 0.2f;
        textObject.transform.localScale = Vector2.one * (sine +1);
    }


    private void ChangeBackGroundColor()
    {
        mainCamera.DOColor(Random.ColorHSV(0,1f,0.9f,1,0.5f,0.7f,1,1),0.8f).SetDelay(0.1f).OnComplete(ChangeBackGroundColor);
    }

}
