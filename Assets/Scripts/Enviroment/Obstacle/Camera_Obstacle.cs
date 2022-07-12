using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Obstacle : MonoBehaviour
{
    SpriteRenderer sRenderer;
    Camera_Controller controller;
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        controller = GameObject.FindObjectOfType<Camera_Controller>(); 
        UpdateStats();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            controller.FlipCamera();
        }
    }

    private void UpdateStats()
    {
        if(!controller.rotated)
        {
            sRenderer.color = Color.magenta;
        }
        else
        {
            sRenderer.color = Color.cyan;
        }
    }
}
