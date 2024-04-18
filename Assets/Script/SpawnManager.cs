using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab; 

    Vector3 spawnPos = new Vector3(25, 0, 0); 
    PlayerController playerController; 

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>(); 
        InvokeRepeating("SpawnObstacle", 2, 1.5f); 
    }

    void SpawnObstacle()
    {
        if (playerController.gameOver == false) 
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); 
        }
    }
}
