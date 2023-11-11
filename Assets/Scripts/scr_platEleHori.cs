using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_platEleHori : MonoBehaviour
{
    public float moveDistance = 5f; // The distance the platform moves
    public float moveSpeed = 2f; // The speed at which the platform moves

    private Vector3 initialPosition;
    private bool movingRight = true;

    private Rigidbody2D platformRigidbody;

    void Start()
    {
        initialPosition = transform.position;
        platformRigidbody = GetComponent<Rigidbody2D>();
        platformRigidbody.isKinematic = true; // Set the Rigidbody2D to Kinematic
        platformRigidbody.velocity = new Vector2(moveSpeed, 0f);
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        // If the platform reaches the target position, change direction
        if ((movingRight && transform.position.x >= initialPosition.x + moveDistance) ||
            (!movingRight && transform.position.x <= initialPosition.x))
        {
            movingRight = !movingRight;
            platformRigidbody.velocity = new Vector2(movingRight ? moveSpeed : -moveSpeed, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("test");
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

}
