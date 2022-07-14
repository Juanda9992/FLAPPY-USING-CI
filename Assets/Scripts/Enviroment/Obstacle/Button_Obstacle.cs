using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Obstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject door;
    private bool inTrigger = false;
    private void Start()
    {
        transform.position = new Vector2(transform.position.x,Random.Range(-4.7f,4.7f));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            inTrigger = true;
        }    
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }

    private void toggleDoor()
    {
        if(inTrigger)
        {
            door.SetActive(false);
        }    
    }

    void OnEnable()
    {
        Player_Jump.onPlayerJump += toggleDoor;
    }
    void OnDisable()
    {
        Player_Jump.onPlayerJump -= toggleDoor;
    }
}
