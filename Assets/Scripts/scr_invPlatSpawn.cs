using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scr_invPlatSpawn : MonoBehaviour
{
    public GameObject platformType;
    public GameObject audioSource;

    private void OnMouseDown()
    {
        SpawnPlatform();
    }

    public GameObject SpawnPlatform()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject spawnedPlatform = Instantiate(platformType, mousePos, Quaternion.identity);
        spawnedPlatform.GetComponent<scr_followDropper>().beingHeld = true;
        if (spawnedPlatform.TryGetComponent<scr_platBounce>(out scr_platBounce platBounce))
        {
            spawnedPlatform.GetComponent<scr_platBounce>().audioSource = audioSource;
        }
        
        
        return spawnedPlatform;
    }
}
