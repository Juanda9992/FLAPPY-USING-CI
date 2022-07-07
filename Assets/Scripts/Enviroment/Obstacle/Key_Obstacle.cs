using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Obstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject door;

    void Start()
    {
        transform.position = new Vector2(transform.position.x,Random.Range(-5,5));
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            door.SetActive(false);
        }
    }
}
