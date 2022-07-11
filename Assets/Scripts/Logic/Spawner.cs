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
    // Start is called before the first frame update
    void Start()
    {
        currentTimeBetweenSpawn = timeBetweenSpawn / 2;
    }

    // Update is called once per frame
    void Update()
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

    private void Spawn()
    {
        currentTimeBetweenSpawn = timeBetweenSpawn;
            Instantiate(obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)],transform.position,Quaternion.identity); 
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
}
