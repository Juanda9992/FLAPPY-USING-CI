using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.right * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.FindObjectOfType<Player_Jump>().IncreaseScore();
        Destroy(other.transform.parent.gameObject);
        Destroy(this.gameObject);
    }
}
