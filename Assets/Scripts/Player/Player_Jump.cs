using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player_Jump : MonoBehaviour
{
    public delegate void onDeath();
    public static event onDeath onPlayerDeath;
    private Rigidbody2D rb;
    [SerializeField]
    private float jumpVelocity;
    private bool jumping = false;
    private Vector2 firstPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        firstPos = transform.position;
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
        if(rb.velocity.y <= 0)
        {
            rb.gravityScale = 6;
        }
        else
        {
            rb.gravityScale = 4;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Lethal"))
        {
            onPlayerDeath?.Invoke();
            resetPos();
            
        }
    }

    private void resetPos()
    {
        transform.position = firstPos;
        rb.velocity = Vector2.zero;
    }
}
