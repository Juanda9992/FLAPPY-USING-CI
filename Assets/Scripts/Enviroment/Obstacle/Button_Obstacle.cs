using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Obstacle : MonoBehaviour
{
    [SerializeField] private Color pressedColor;
    private SpriteRenderer sRenderer;
    [SerializeField]
    private GameObject door;
    private bool inTrigger = false;
    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        transform.position = new Vector2(transform.position.x,Random.Range(-4.6f,4.6f));
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
            sRenderer.color = pressedColor;
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
