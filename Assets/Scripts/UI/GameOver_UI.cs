using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOver_UI : MonoBehaviour
{
    public delegate void onGameRestarted();
    public static event onGameRestarted onRestart;
    [SerializeField]
    private RectTransform panel;


    private void ShowPanel()
    {
        panel.DOMoveY(540,1f);
    }

    void OnEnable()
    {
        Player_Jump.onPlayerDeath+= ShowPanel;
    }

    void OnDisable()
    {
        Player_Jump.onPlayerDeath -= ShowPanel;
    }

    [ContextMenu("Debug")]
    public void DebugPosY()
    {
        Debug.Log(panel.transform.position.y);
    }

    public void restart()
    {
        panel.DOLocalMoveY(2540,1f);
        onRestart?.Invoke();
    }
}
