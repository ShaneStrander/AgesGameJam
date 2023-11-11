using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scr_invPlatSpawn : MonoBehaviour
{
    public GameObject platformType;

    private void OnMouseDown()
    {
        SpawnPlatform();
    }

    public GameObject SpawnPlatform()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject spawnedPlatform = Instantiate(platformType, mousePos, Quaternion.identity);
        Debug.Log("SPAAWNED");

        return spawnedPlatform;
    }
}
