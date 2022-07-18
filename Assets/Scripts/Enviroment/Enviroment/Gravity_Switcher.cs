using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Switcher : MonoBehaviour
{
    public delegate void onGravityChanged();
    public static event onGravityChanged onChangeGravity;
    public int gravityAxis = 1;
    public bool switched = false;

    public void FlipGravity()
    {
        gravityAxis *= -1;
        onChangeGravity?.Invoke();
    }

    private void ResetGravity()
    {
        gravityAxis = 1;
    }

    void OnEnable()
    {
        GameOver_UI.onRestart += ResetGravity;
    }
    void OnDisable()
    {
        GameOver_UI.onRestart -= ResetGravity;
    }
    



}
