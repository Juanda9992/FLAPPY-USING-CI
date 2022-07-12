using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Switcher : MonoBehaviour
{
    public int gravityAxis = 1;
    private bool switched = false;
    private SpriteRenderer sRenderer;
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        if(gravityAxis < 0)
        {
            switched = true;
        }
        else
        {
            switched = false;
        }
        UpdateInfo();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("Player"))
        {
            FlipGravity();
        }    
    }

    private void FlipGravity()
    {
        gravityAxis *= -1;
    }

    private void UpdateInfo()
    {
        if(switched)
        {
            sRenderer.color = Color.blue;
        }
        else
        {
            sRenderer.color = Color.yellow;
        }
    }

}
