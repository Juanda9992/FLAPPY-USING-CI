using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revert_Obstacle : MonoBehaviour
{
    private Player_Jump player;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player_Jump>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player.resetPos();
        }
    }
}
