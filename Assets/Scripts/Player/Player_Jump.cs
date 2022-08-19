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
    private bool hasDeath = false;

    private Camera_Controller camera_Controller;
    private SpriteRenderer sRenderer;
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        gravity_Switcher = FindObjectOfType<Gravity_Switcher>();
        rb = GetComponent<Rigidbody2D>();
        firstPos = transform.position;
        sRenderer.sprite = GetSprite();
        camera_Controller = GameObject.FindObjectOfType<Camera_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Game_State.gameStarting)
        {
            if(Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0) )
            {
                jumping = true;
            }

        }

        if(transform.position.x < -14)
        {
            Death();
        }

        IncreasePlayTime();

    }

    void FixedUpdate()
    {
        if(jumping)
        {
            onPlayerJump?.Invoke();
            jumping = false;
            transform.DOShakeScale(0.1f,0.5f).OnComplete(()=> transform.localScale = Vector2.one);
            rb.velocity = Vector2.up * jumpVelocity * gravity_Switcher.gravityAxis;
            Stats_Handler.stats_Handler_inst.totalJumps++;
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
                Destroy(other.gameObject);
                Camera.main.GetComponent<Camera_Controller>().Shake();
            }
        }
    }

    private void Death()
    {
        
        onPlayerDeath?.Invoke();
        if(!hasDeath)
        {
            Game_State.gameStarting = false;
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            camera_Controller.zoomOnDeath(transform.position);
            hasDeath = true;
            Stats_Handler.stats_Handler_inst.totalDeaths ++;
        }
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
        rb.isKinematic = false;
        transform.position = firstPos;
        rb.velocity = Vector2.zero;
        health = 1;
        sRenderer.flipY = false;
        hasDeath = false;
    }
    
    private void IncreasePlayTime()
    {
        Stats_Handler.stats_Handler_inst.totalPlayTime += Time.deltaTime;
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
