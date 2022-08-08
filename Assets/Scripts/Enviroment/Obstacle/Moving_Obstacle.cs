using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Obstacle : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(transform.position.x,snapValue(Random.Range(-3f,3f),1));
    }

    void FixedUpdate()
    {
        if(transform.position.x < -20)
        {
            Destroy(gameObject);
        }
        if(Game_State.gameStarting)
        {
            rb.velocity = Vector2.left * 8;    
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }

    private float snapValue(float value,float multipleOf)
    {
        return Mathf.Round(value/multipleOf) * multipleOf;  
    }
    private void DestroyObstacle()
    {
        Destroy(this.gameObject);
    }

    void OnEnable()
    {
        GameOver_UI.onRestart += DestroyObstacle;
    }

    void OnDisable()
    {
        GameOver_UI.onRestart -= DestroyObstacle;
    }

}
