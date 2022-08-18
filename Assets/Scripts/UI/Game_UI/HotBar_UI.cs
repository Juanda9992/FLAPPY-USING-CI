using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using TMPro;
public class HotBar_UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI heartText;
    private Player_Shoot shoot;
    private Player_Jump player;
    [SerializeField] private CanvasGroup button;

    [SerializeField] private GameObject letter;
    // Start is called before the first frame update
    void Start()
    {
        if(!Platform_Manager.isOnWindows())
        {
            letter.SetActive(false);
        }
        shoot = GameObject.FindObjectOfType<Player_Shoot>();
        player = GameObject.FindObjectOfType<Player_Jump>();
    }

    void Update()
    {
        heartText.text = player.health.ToString();
    }

    private void ShowButton()
    {
        button.DOFade(1,0.2f);
    }
    private void HideButton()
    {
        button.DOFade(0,0.2f);
    }

    void OnEnable()
    {
        Player_Shoot.onAmmoIncreased += ShowButton;
        Player_Shoot.onAmmoOut += HideButton;
    }
    void OnDisable()
    {
        Player_Shoot.onAmmoIncreased -= ShowButton;
        Player_Shoot.onAmmoOut -= HideButton;
    }

}
