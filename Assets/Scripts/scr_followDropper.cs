using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scr_followDropper : MonoBehaviour
{

    [HideInInspector]
    public bool beingHeld = false;
    public bool isStart = false;
    public GameObject platformManager;
    public GameObject score;
    public GameObject spawner = null;
    public GameObject crane = null;

    public float gravitySpeed = 0.5f;
    public float dropSpeedMUltiplier = 0.05f;

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
            gameObject.layer = 6;
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = (new Vector2(rb.velocity.x, -gravitySpeed * 0.3f));
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
        if (collision.gameObject.tag == "DropTrigger" && !Input.GetMouseButton(0) && crane.GetComponent<scr_crane>().inDropArea)
        {
            beingHeld = false;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (!dropped)
            {
                Debug.Log("DROP");
                rb.velocity = Vector3.zero;
                dropped = true;
                rb.bodyType = RigidbodyType2D.Kinematic;
                gameObject.layer = 6;
                foreach (Transform child in transform)
                {
                    child.gameObject.layer = 6;
                }
                rb.velocity = (new Vector2(rb.velocity.x, -gravitySpeed * (1 + dropSpeedMUltiplier)));
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
            score.GetComponent<scr_score>().score += 100;
            platformManager.GetComponent<scr_platformManager>().SpawnCrate();
            if (spawner != null)
            { 
                spawner.GetComponent<scr_invPlatSpawn>().dropSpeedMultiplier += 1f;
            }
            Destroy(gameObject);
        }
    }
}
