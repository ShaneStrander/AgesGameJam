using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_platformManager : MonoBehaviour
{
    
    private float minX;              // Minimum X position for respawn
    private float maxX;               // Maximum X position for respawn
    private float minY;              // Minimum Y position for respawn
    private float maxY;               // Maximum Y position for respawn

    //public List<GameObject> platforms = new List<GameObject>();
    public List<GameObject> platforms;
    public GameObject[] counters = new GameObject[6];

    public GameObject boundary;

    void Start()
    {
        minX = boundary.transform.position.x - boundary.GetComponent<BoxCollider2D>().bounds.size.x / 2f;
        maxX = boundary.transform.position.x + boundary.GetComponent<BoxCollider2D>().bounds.size.x / 2f;
        minY = boundary.transform.position.y - boundary.GetComponent<BoxCollider2D>().bounds.size.y / 2f;
        maxY = boundary.transform.position.y + boundary.GetComponent<BoxCollider2D>().bounds.size.y / 2f;

        Debug.Log(minX);
        Debug.Log(maxX);
        Debug.Log(minY);
        Debug.Log(maxY);

    }

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
