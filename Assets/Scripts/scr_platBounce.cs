using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_platBounce : MonoBehaviour
{
    public float bounceForce = 0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                // Calculate the bounce direction (you can customize this based on your needs)
                Vector2 bounceDirection = Vector2.up;

                // Apply the bounce force to the player
                playerRb.velocity = new Vector2(playerRb.velocity.x, 0f); // Reset vertical velocity
                playerRb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}
