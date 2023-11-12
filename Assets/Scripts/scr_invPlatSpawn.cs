using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scr_invPlatSpawn : MonoBehaviour
{
    public GameObject platformType;
    public GameObject audioSource;
    public GameObject platCounter;
    public GameObject score;
    private void OnMouseDown()
    {
        if (platCounter.GetComponent<scr_platformInventoryCounter>().RemoveFromInventory())
        {
            SpawnPlatform();
        }
        else
        {
            audioSource.GetComponent<scr_soundEffects>().playSound(audioSource.GetComponent<scr_soundEffects>().sfNoInventory);
        }
    }

    public GameObject SpawnPlatform()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject spawnedPlatform = Instantiate(platformType, mousePos, Quaternion.identity);
        spawnedPlatform.GetComponent<scr_followDropper>().beingHeld = true;
        spawnedPlatform.GetComponent<scr_followDropper>().score = score;
        if (spawnedPlatform.TryGetComponent<scr_platBounce>(out scr_platBounce platBounce))
        {
            spawnedPlatform.GetComponent<scr_platBounce>().audioSource = audioSource;
        }
        
        
        return spawnedPlatform;
    }
}
