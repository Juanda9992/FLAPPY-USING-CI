using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclePrefabs;
    [SerializeField]
    public float timeBetweenSpawn;
    public float currentTimeBetweenSpawn; 
    public bool spawned = false;

    [HideInInspector]
    public int currentNumber;
    [HideInInspector]
    public int lastNumber;
    private bool isSpawning = true;
    private Time_Speed_Controller timeController;
    // Start is called before the first frame update
    void Start()
    {
        currentTimeBetweenSpawn = timeBetweenSpawn / 2;
        timeController = GameObject.FindObjectOfType<Time_Speed_Controller>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.timeScale);
        if(isSpawning)
        {
            if(currentTimeBetweenSpawn > 0)
            {
                currentTimeBetweenSpawn -= Time.deltaTime;
            }
            else
            {
                
                Spawn();
            }

        }
    }

    private void Spawn()
    {
        currentTimeBetweenSpawn = timeBetweenSpawn;
        currentNumber = GenerateNumber();
        Instantiate(obstaclePrefabs[currentNumber],transform.position,Quaternion.identity);
        lastNumber = currentNumber; 
    }

    public void checkForSpawn()
    {
        if(currentTimeBetweenSpawn <= 0)
        {
            spawned = true;
        }
        else
        {
            spawned = false;
        }
    }

    public int GenerateNumber(bool basedOnLenght = true)
    {
        if(basedOnLenght)
        {
            int number = Random.Range(0,obstaclePrefabs.Length);
            if(lastNumber == 2)
            {
                while(number == 3 || number == 4)
                {
                    number = Random.Range(0,obstaclePrefabs.Length);
                }
            }
            return number;
        }
        else    
        {        
            int number = Random.Range(0,8);
            if(lastNumber == 2)
            {
                while(number == 3 || number == 4)
                {
                    number = Random.Range(0,obstaclePrefabs.Length);
                }
            }
            else if((lastNumber == 7) && (number ==7))
            {
                while(number == 7)
                {
                    number = Random.Range(0,obstaclePrefabs.Length);
                }
            }
            else if(lastNumber == 8 && (number == lastNumber))
            {
                while(number == 8)
                {
                    number = Random.Range(0,obstaclePrefabs.Length);
                }
            }
            else if(lastNumber == 9)
            {
                while((number == 9) && (Time.timeScale != 1))
                {
                    number = Random.Range(0,obstaclePrefabs.Length);
                }
            }

            return number;
        }


    }

    private void cancelSpawn()
    {
        isSpawning = false;
    }

    private void resetSpawn()
    {
        isSpawning = true;
        currentTimeBetweenSpawn = timeBetweenSpawn / 2;
    }

    void OnEnable()
    {
        Player_Jump.onPlayerDeath += cancelSpawn;
        GameOver_UI.onRestart += resetSpawn;
    }

    void OnDisable()
    {
        Player_Jump.onPlayerDeath -= cancelSpawn;
        GameOver_UI.onRestart -= resetSpawn;
    }
}
