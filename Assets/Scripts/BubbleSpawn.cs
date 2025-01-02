using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawn : MonoBehaviour
{
    public GameObject bubblePrefab; 
    public Transform spawnPoint;    
    public float spawnInterval = 5f; 

    void Start()
    {
        
        InvokeRepeating(nameof(SpawnBubble), 0f, spawnInterval);
    }

    void SpawnBubble()
    {
        
        Instantiate(bubblePrefab, spawnPoint.position, Quaternion.identity);
    }
}
