using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player_Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float jumpVelocity;
    private bool jumping = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            jumping = true;
        }
            

        
    }

    void FixedUpdate()
    {
        if(jumping)
        {
            jumping = false;
            rb.velocity = Vector2.up * jumpVelocity;
        }
    }
}
