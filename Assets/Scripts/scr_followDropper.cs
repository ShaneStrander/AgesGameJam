using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scr_followDropper : MonoBehaviour
{

    [HideInInspector]
    public bool beingHeld = false;
    public bool isStart = false;
    public float gravitySpeed = 1f;
    public GameObject platformManager;

    private float moveMultiplier = 10;
    private float jitter = 0.01f;
    private bool dropped = false;

    private void Start()
    {
        if (isStart)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Debug.Log("DROP");
            rb.velocity = Vector3.zero;
            dropped = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = (new Vector2(rb.velocity.x, -gravitySpeed * 1));
        }
    }
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
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.velocity = (new Vector2(rb.velocity.x, -gravitySpeed*1));
                if (gameObject.tag == "HorizontalPlatform" || gameObject.tag == "VerticalPlatform")
                {
                    gameObject.GetComponentInChildren<MovePlat>().locked = false;
                    Debug.Log("UNLOCK");
                }
                //rb.gravityScale = personalGravity;
            }
        }
    }

    //Colliding with Killzone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "KillZone")
        {
            //Call platform manager spawn crate
            platformManager.GetComponent<scr_platformManager>().SpawnCrate();
            Destroy(gameObject);
        }
    }
}
