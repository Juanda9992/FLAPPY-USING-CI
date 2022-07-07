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
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.left * 8;
    }
}
