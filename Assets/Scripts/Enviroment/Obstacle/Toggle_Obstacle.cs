using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Obstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject toggleWall;
    private bool isToggled = true;

    private void ToggleWallOnTouch()
    {
        isToggled = !isToggled;
        toggleWall.SetActive(isToggled);
    }

    void OnEnable()
    {
        Player_Jump.onPlayerJump+= ToggleWallOnTouch;
    }

    void OnDisable()
    {
        Player_Jump.onPlayerJump -= ToggleWallOnTouch;
    }
}
