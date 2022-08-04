using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Random_Points_Obstacle : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private int maxPoints = 4;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = Random.Range(1,maxPoints);
        text = GetComponent<TextMeshProUGUI>();
        text.text = score.ToString();   
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Player"))
        {
            Player_Jump player = GameObject.FindObjectOfType<Player_Jump>(); 
            for(int i = 0;i < score ;i++)
            {
                player.IncreaseScore();
            }
            
        }
    }
}
