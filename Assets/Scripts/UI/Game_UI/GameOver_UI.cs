using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class GameOver_UI : MonoBehaviour
{
    public delegate void onGameRestarted();
    public static event onGameRestarted onRestart;
    [SerializeField]
    private RectTransform panel;
    [SerializeField] private SaveModel saveModel;
    private Score_UI score;
    

    [SerializeField] private TextMeshProUGUI scoreText,maxScoreText;

    void Awake()
    {
        score = GameObject.FindObjectOfType<Score_UI>();
    }
    private void ShowPanel()
    {
        scoreText.text = "Score: " + score.score;
        maxScoreText.text = "Highest Score: " + saveModel.highestScore.ToString();
        panel.DOMoveY(transform.position.y,1f).SetDelay(1f);
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
        Game_State.gameStarting = true;
        panel.DOMoveY(2540,1f);
        onRestart?.Invoke();
    }

}
