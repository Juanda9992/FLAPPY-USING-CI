using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revert_Obstacle : MonoBehaviour, IActivable
{
    private Player_Jump player;
    private Gravity_Switcher switcher;
    private Time_Speed_Controller controller;

    void Start()
    {
        controller = GameObject.FindObjectOfType<Time_Speed_Controller>();
        switcher = GameObject.FindObjectOfType<Gravity_Switcher>();
        player = GameObject.FindObjectOfType<Player_Jump>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            switcher.ResetGravity();
            controller.ResetTime();
            player.transform.position = new Vector2(0, player.transform.position.y);
        }
    }

    public void OnActivate()
    {
        SpriteRenderer sRender = GetComponent<SpriteRenderer>();
        Color_Changer.ChangeSpriteColor(sRender);
    }
}
