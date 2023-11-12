using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_crane : MonoBehaviour
{
    public float followSpeed = 5f;

    void Update()
    {
        // Get the current mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Set the Y position of the object to its current Y position
        mousePosition.y = transform.position.y;
        mousePosition.z = transform.position.z;

        // Move the object towards the mouse position smoothly
        transform.position = Vector3.Lerp(transform.position, mousePosition, followSpeed * Time.deltaTime);
    }
}
