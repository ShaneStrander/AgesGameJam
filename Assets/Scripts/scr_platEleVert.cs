using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_platEleVert : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f;

    private Vector3 initialPosition;
    private bool movingUp = true;

    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        // Calculate the next position based on movement direction
        Vector3 targetPosition = movingUp ? initialPosition + Vector3.up * moveDistance : initialPosition;

        // Move the platform towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // If the platform reaches the target position, change direction
        if (transform.position == targetPosition)
        {
            movingUp = !movingUp;
        }
    }
}
