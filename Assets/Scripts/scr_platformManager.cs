using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_platformManager : MonoBehaviour
{
    
    public float minX = -5f;              // Minimum X position for respawn
    public float maxX = 5f;               // Maximum X position for respawn
    public float minY = -3f;              // Minimum Y position for respawn
    public float maxY = 3f;               // Maximum Y position for respawn

    //public List<GameObject> platforms = new List<GameObject>();
    public List<GameObject> platforms;

    public void SpawnCrate()
    {
        int randomizer = Random.Range(0, platforms.Count);

        Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject platform = Instantiate(platforms[randomizer], spawnPosition, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CrateStatic"))
        {
            //SpawnPlatform(staticPlatform);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("CrateBounce"))
        {
            //SpawnPlatform(bouncePlatform);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("CrateTimer"))
        {
            //SpawnPlatform(timerPlatform);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("CrateHoriMove"))
        {
            //SpawnPlatform(horiMovePlatform);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("CrateVertMove"))
        {
            //SpawnPlatform(vertMovePlatform);
            Destroy(collision.gameObject);
        }

    }
}
