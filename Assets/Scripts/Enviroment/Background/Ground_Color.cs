using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Ground_Color : MonoBehaviour
{
    private SpriteRenderer sRenderer;
    Camera mainCamera;
    private void Start() 
    {
        sRenderer = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        sRenderer.color = Color.Lerp(sRenderer.color,new Color(mainCamera.backgroundColor.r * 1.8f ,mainCamera.backgroundColor.g * 1.5f,mainCamera.backgroundColor.b * 1.8f,mainCamera.backgroundColor.a),5* Time.deltaTime);
    }
}
