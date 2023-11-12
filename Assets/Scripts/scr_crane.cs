using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_crane : MonoBehaviour
{
    public float followSpeed = 5f;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // if in inventory
        if (mousePosition.x > 12.5f)
        {
            //mousePosition.y = transform.position.y;
            mousePosition.x = 16.5f;
        }
        else 
        {
            mousePosition.y = 9.8f;
            //mousePosition.x = 7f;
        }

        //usePosition.y = transform.position.y;
        mousePosition.z = transform.position.z;
        

        transform.position = Vector3.Lerp(transform.position, mousePosition, followSpeed * Time.deltaTime);
    }
}
