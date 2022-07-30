using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Up_Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    // Start is called before the first frame update
    void Start()
    {
        GameObject currentPowerUp = Instantiate(obstacles[Random.Range(0,obstacles.Length)],transform.position,Quaternion.identity);      
        currentPowerUp.transform.SetParent(this.transform);  
    }

}
