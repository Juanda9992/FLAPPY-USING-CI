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
        transform.DOMove(new Vector3(0,0,-1),0.8f);
        Camera.main.DOOrthoSize(8,0.8f);
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

    public void zoomOnDeath(Vector3 position)
    {
        DOTween.To(()=> Time.timeScale, x=> Time.timeScale = x, 0.3f,0.4f);
        transform.DOMove(position - Vector3.forward,0.7f);
        Camera.main.DOOrthoSize(6,0.4f);
    }
    public void Shake()
    {
        Transform previousPosition = transform;
        transform.DOShakePosition(1).OnComplete(()=> transform.position = previousPosition.position);
    }

}
