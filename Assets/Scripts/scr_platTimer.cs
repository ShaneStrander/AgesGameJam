using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_platTimer : MonoBehaviour
{
    private bool playerOnPlatform = false;
    private float disappearTime = 1f;
    private float elapsedTime = 0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            ChangeColor();
            Invoke("DisappearPlatform", disappearTime);
        }
    }

    private void Update()
    {
        if (playerOnPlatform)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / disappearTime);
            Color lerpedColor = Color.Lerp(Color.white, Color.red, t);
            GetComponent<SpriteRenderer>().color = lerpedColor;
        }
    }

    private void ChangeColor()
    {
        // Change the platform color to pink initially
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void DisappearPlatform()
    {
        // Disable the platform after the transition
        gameObject.SetActive(false);
    }
}
