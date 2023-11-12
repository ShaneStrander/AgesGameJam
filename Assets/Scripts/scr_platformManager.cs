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
    public GameObject[] counters = new GameObject[6];

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
            counters[0].GetComponent<scr_platformInventoryCounter>().AddToInventory();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("CrateBounce"))
        {
            counters[1].GetComponent<scr_platformInventoryCounter>().AddToInventory();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("CrateTimer"))
        {
            counters[2].GetComponent<scr_platformInventoryCounter>().AddToInventory();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("CrateWall"))
        {
            counters[3].GetComponent<scr_platformInventoryCounter>().AddToInventory();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("CrateHoriMove"))
        {
            counters[4].GetComponent<scr_platformInventoryCounter>().AddToInventory();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("CrateVertMove"))
        {
            counters[5].GetComponent<scr_platformInventoryCounter>().AddToInventory();
            Destroy(collision.gameObject);
        }

    }
}
