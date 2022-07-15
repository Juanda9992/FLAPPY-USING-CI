using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Speed_Obstacle : MonoBehaviour
{
    private Time_Speed_Controller time_Speed;
    private bool fast = false;
    private SpriteRenderer sRenderer;
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        time_Speed = GameObject.FindObjectOfType<Time_Speed_Controller>();
        setSpeed();
        updateColor();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            time_Speed.changeSpeed(fast);
        }
    }

    private void setSpeed()
    {
        if(Random.Range(0,2) == 1)
        {
            fast = true;
        }
        else
        {
            fast = false;
        }
    }

    private void updateColor()
    {
        if(fast)
        {
            sRenderer.color = Color.red;
        }
        else
        {
            sRenderer.color = Color.cyan;
        }
    }
}
