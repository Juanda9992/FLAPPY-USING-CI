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
        transform.position = new Vector2(transform.position.x,snapValue(Random.Range(-2.8f,2.8f),0.25f));
    }

    void FixedUpdate()
    {
        if(transform.position.x < -15)
        {
            Destroy(gameObject);
        }
        rb.velocity = Vector2.left * 8;
    }

    private float snapValue(float value,float multipleOf)
    {
        return Mathf.Round(value/multipleOf) * multipleOf;  
    }
}
