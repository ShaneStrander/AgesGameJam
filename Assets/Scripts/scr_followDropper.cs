using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scr_followDropper : MonoBehaviour
{

    [HideInInspector]
    public bool beingHeld = false;
    public float personalGravity = 1f;

    private float moveMultiplier = 10;
    private float jitter = 0.01f;
    private bool dropped = false;
    private void Update()
    {
        if (beingHeld)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 myPos = transform.position;
            Vector3 posDiff = mousePos - myPos;


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
            beingHeld = false;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (!dropped)
            {
                Debug.Log("DROP");
                rb.velocity = Vector3.zero;
                dropped = true;
                rb.gravityScale = personalGravity;
            }
        }
    }
}
