using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Speed_Obstacle : MonoBehaviour, IActivable
{
    private Time_Speed_Controller time_Speed;
    [SerializeField]
    private Sprite slowSprite, fastSprite;
    private bool fast = false;
    private SpriteRenderer sRenderer;
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        time_Speed = GameObject.FindObjectOfType<Time_Speed_Controller>();
        setSpeed();
        updateSprite();
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

    private void updateSprite()
    {
        if(fast)
        {
            sRenderer.sprite = fastSprite;
        }
        else
        {
            sRenderer.sprite = slowSprite;
        }
    }
    public void OnActivate()
    {
        Color_Changer.ChangeSpriteColor(sRenderer);
    }
}
