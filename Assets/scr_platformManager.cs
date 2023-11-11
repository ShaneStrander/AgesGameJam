using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_platformManager : MonoBehaviour
{
    public GameObject staticPlatform;
    public GameObject bouncePlatform;
    public GameObject timerPlatform; 
    public int numberOfPlatforms = 5;     // The initial number of platforms
    public float respawnTime = 2f;        // Time in seconds before respawning a platform
    public float minX = -5f;              // Minimum X position for respawn
    public float maxX = 5f;               // Maximum X position for respawn
    public float minY = -3f;              // Minimum Y position for respawn
    public float maxY = 3f;               // Maximum Y position for respawn

    private List<GameObject> platforms = new List<GameObject>();

    void Start()
    {
        // Spawn initial platforms
        //SpawnPlatforms();
    }

    void SpawnPlatform(GameObject selectedPrefab)
    {
        // Choose a random platform prefab
        //GameObject selectedPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];

        // Instantiate the selected platform prefab at a random position
        Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject platform = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        //platforms.Add(platform);
    
    }

    void Update()
    {
        // Check if you want to respawn a platform (e.g., when a platform is destroyed)
        // For demonstration purposes, I'm using the space key as a trigger. You can replace it with your own condition.
        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("staticPlatBubble"))
        {
            SpawnPlatform(staticPlatform);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("bouncePlatBubble"))
        {
            SpawnPlatform(bouncePlatform);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("timerPlatBubble"))
        {
            SpawnPlatform(timerPlatform);
            Destroy(collision.gameObject);
        }
    }
}
