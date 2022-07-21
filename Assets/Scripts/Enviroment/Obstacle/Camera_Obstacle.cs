using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Obstacle : MonoBehaviour
{
    private SpriteRenderer sRenderer;

    [SerializeField] private Sprite normalSprite,toggleSprite;
    
    private Camera_Controller controller;
    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        controller = GameObject.FindObjectOfType<Camera_Controller>(); 
        UpdateStats();
    }
    private void OnTriggerEnter2D(Collider2D other)
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
            sRenderer.sprite = toggleSprite;
        }
        else
        {
            sRenderer.sprite = normalSprite;
        }
    }
}
