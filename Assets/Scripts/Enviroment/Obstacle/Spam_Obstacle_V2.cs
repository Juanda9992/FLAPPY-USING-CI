using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spam_Obstacle_V2 : MonoBehaviour
{
    [SerializeField]private int maxClicks, minClicks, randomClicks,currentClicks;
    [SerializeField] private GameObject wallObject;
    [SerializeField] private TextMeshProUGUI clicksText;

    // Start is called before the first frame update
    void Start()
    {
        randomClicks = Random.Range(minClicks,maxClicks);
        clicksText.text = randomClicks.ToString();
    }

    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
    private void IncrementCLicks()
    {
        randomClicks = Mathf.Clamp(randomClicks,1,maxClicks);
        randomClicks--;
        clicksText.text = randomClicks.ToString();
        if(randomClicks <=0)
        {
            if(wallObject.activeSelf)
            {
                Audio_Manager.instance.PlaySound("Door");
            }
            wallObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        Player_Jump.onPlayerJump += IncrementCLicks;
    }
    void OnDisable()
    {
        Player_Jump.onPlayerJump -= IncrementCLicks;
    }
}
