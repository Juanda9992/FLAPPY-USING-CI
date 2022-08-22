using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Background_Changer_Obstacle : MonoBehaviour,IActivable
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Color_Changer.ChangeBackgroundColor();
        }
    }

    public void OnActivate()
    {
        SpriteRenderer sRender = GetComponent<SpriteRenderer>();
        Color_Changer.ChangeSpriteColor(sRender);
    }
}
