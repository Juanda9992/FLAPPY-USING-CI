using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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

    public int health = 1;

    private SpriteRenderer sRenderer;
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        gravity_Switcher = FindObjectOfType<Gravity_Switcher>();
        rb = GetComponent<Rigidbody2D>();
        firstPos = transform.position;
        sRenderer.sprite = GetSprite();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(onPlayerJump);
        if(Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0) )
        {
            jumping = true;
        }

        if(transform.position.x < -14)
        {
            Death();
        }

    }

    void FixedUpdate()
    {
        if(jumping)
        {
            onPlayerJump?.Invoke();
            jumping = false;
            transform.DOShakeScale(0.1f,0.5f).OnComplete(()=> transform.localScale = Vector2.one);
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

    private Sprite GetSprite()
    {
        return Sprite_Holder.sprite_Holder_inst.currentSprite;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Lethal"))
        {
            health --;
            if(health <= 0)
            {
                Death();
            }
            else
            {
                resetPos();
            }
        }
    }

    private void Death()
    {
        onPlayerDeath?.Invoke();
        resetPos();
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Score"))
        {
            IncreaseScore();
        }
    }

    public void resetPos()
    {
        transform.position = firstPos;
        rb.velocity = Vector2.zero;
        sRenderer.flipY = false;
    }
    
    public void IncreaseScore()
    {
        onPlayerScored?.Invoke();
    }
    private void flipSprite()
    {
        if(gravity_Switcher.gravityAxis > 0)
        {
            sRenderer.flipY = false;
        }
        else
        {
            sRenderer.flipY = true;
        }
    }

    void OnEnable()
    {
        GameOver_UI.onRestart += resetPos;
        Gravity_Switcher.onChangeGravity += flipSprite;
    }

    void OnDisable()
    {
        Gravity_Switcher.onChangeGravity -= flipSprite;
        GameOver_UI.onRestart -= resetPos;
    }
}
