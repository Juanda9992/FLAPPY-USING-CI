using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Camera_Controller : MonoBehaviour
{
    public bool rotated = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            FlipCamera();
        }
    }
    public void FlipCamera()
    {
        if(!rotated)
        {
            rotated = true;
            transform.DOMoveZ(1,0.5f);
            transform.DORotate(new Vector2(0,180),0.7f);
        }
        else
        {
            rotated =false;
            transform.DOMoveZ(-1,0.5f);
            transform.DORotate(new Vector2(0,-360),0.7f);
        } 
    }

    private void resetCamera()
    {
        rotated = false;
        transform.position = new Vector3(transform.position.x, transform.position.y,-1);
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    private void OnEnable() 
    {
        GameOver_UI.onRestart += resetCamera;    
    }

    private void OnDisable() 
    {
        GameOver_UI.onRestart -= resetCamera;    
    }
}
