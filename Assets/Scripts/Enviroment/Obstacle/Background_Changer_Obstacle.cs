using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Background_Changer_Obstacle : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Camera.main.DOColor(Random.ColorHSV(0,0.9f,0.8f,1,0.5f,0.6f,1,1),1);
        }
    }
}
