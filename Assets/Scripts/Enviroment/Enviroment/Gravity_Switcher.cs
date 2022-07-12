using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Switcher : MonoBehaviour
{
    public int gravityAxis = 1;
    public bool switched = false;

    public void FlipGravity()
    {
        gravityAxis *= -1;
    }



}
