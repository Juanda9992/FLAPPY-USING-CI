using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Obstacle : MonoBehaviour
{
    private Gravity_Switcher switcher;
    private SpriteRenderer sRenderer;
    // Start is called before the first frame update
    void Start()
    {
        switcher = GameObject.FindObjectOfType<Gravity_Switcher>();
        sRenderer = GetComponent<SpriteRenderer>();
        UpdateInfo();
    }   

    private void UpdateInfo()
    {
        if(switcher.gravityAxis < 0)
        {
            switcher.switched = true;
        }
        else
        {
            switcher.switched = false;
        }
        if(switcher.switched)
        {
            sRenderer.color = Color.blue;
        }
        else
        {
            sRenderer.color = Color.yellow;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            switcher.FlipGravity();
        }
    }
}
