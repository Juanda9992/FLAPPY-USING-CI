using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float xMovement;

    void Update()
    {
        if(Game_State.gameStarting)
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime,transform.position.y);
            if(transform.position.x <= minX)
            {
                transform.position = new Vector2(transform.position.x + xMovement,transform.position.y);
            }
        }
    }
}
