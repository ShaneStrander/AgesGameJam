using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scr_followDropper : MonoBehaviour
{

    [HideInInspector]
    public bool beingHeld = false;

    private float moveMultiplier = 10;
    private float jitter = 0.01f;
    private void Update()
    {
        if (beingHeld)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 myPos = transform.position;
            Vector3 posDiff = mousePos - myPos;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();


            if (Mathf.Abs((myPos.x - mousePos.x)) > jitter)
            {
                rb.velocity = (new Vector3(posDiff.x * moveMultiplier, rb.velocity.y, posDiff.z * 0));
            }

            if (Mathf.Abs((myPos.y - mousePos.y)) > jitter)
            {
                rb.velocity = (new Vector3(rb.velocity.x, posDiff.y * moveMultiplier, posDiff.z * 0));
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DropTrigger" && !Input.GetMouseButton(0))
        {
            Debug.Log("DROP");
            beingHeld = false;
        }
    }
}
