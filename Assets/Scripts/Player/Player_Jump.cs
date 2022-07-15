using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player_Jump : MonoBehaviour
{
    public delegate void onDeath();
    public delegate void onJumped();
    public delegate void onScore();
    public static event onJumped onPlayerJump;
    public static event onDeath onPlayerDeath;
    public static event onScore onPlayerScored;
    private Rigidbody2D rb;
    [SerializeField]
    private float jumpVelocity;
    private bool jumping = false;
    private Vector2 firstPos;
    private Gravity_Switcher gravity_Switcher;
    // Start is called before the first frame update
    void Start()
    {
        gravity_Switcher = FindObjectOfType<Gravity_Switcher>();
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
            onPlayerJump?.Invoke();
            jumping = false;
            rb.velocity = Vector2.up * jumpVelocity * gravity_Switcher.gravityAxis;
        }
        if(gravity_Switcher.gravityAxis >0)
        {
            if(rb.velocity.y < 0)
            {
                rb.gravityScale = 6 * gravity_Switcher.gravityAxis;
            }
            else
            {
                rb.gravityScale = 4 * gravity_Switcher.gravityAxis;
            } 
        }
        else
        {
            if(rb.velocity.y > 0)
            {
                rb.gravityScale = 6 * gravity_Switcher.gravityAxis;
            }
            else
            {
                rb.gravityScale = 4 * gravity_Switcher.gravityAxis;
            } 
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Score"))
        {
            onPlayerScored?.Invoke();
        }
    }

    private void resetPos()
    {
        transform.position = firstPos;
        rb.velocity = Vector2.zero;
    }

    void OnEnable()
    {
        GameOver_UI.onRestart += resetPos;
    }

    void OnDisable()
    {
        GameOver_UI.onRestart -= resetPos;
    }
}
