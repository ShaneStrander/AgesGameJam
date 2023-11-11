using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlat : MonoBehaviour
{
    public Transform posA, posB;
    public int Speed;
    public bool locked = true;
    private bool started = false;
    Vector2 targetPos;
    private Rigidbody2D rb;

    [SerializeField] private MovementScript playerMovementScript;

    void Start()
    {
        targetPos = posA.position;
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            started = true;
            if (transform.parent.tag == "VerticalPlatform")
            {
                rb.velocity = new Vector2(targetPos.x, GetComponentInParent<Transform>().position.y);
            }
            if (transform.parent.tag == "HorizontalPlatform")
            {
                rb.velocity = new Vector2(GetComponentInParent<Transform>().position.x, targetPos.y);
            }
        }
        if (!locked)
        {
            if (Vector2.Distance(transform.position, posA.position) < 0.1f)
            {
                targetPos = posB.position;
                Debug.Log("YES");
                rb.velocity = new Vector2(GetComponentInParent<Transform>().position.x, targetPos.y);
            }

            if (Vector2.Distance(transform.position, posB.position) < 0.1f)
            {
                targetPos = posA.position;
                Debug.Log("NO");
                rb.velocity = new Vector2(GetComponentInParent<Transform>().position.x, targetPos.y);
            }

            //if (transform.parent.tag == "HorizontalPlatform")
            //{
            //    transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPos.x, GetComponentInParent<Transform>().position.y), Speed * Time.deltaTime);
            //}
            //else if (transform.parent.tag == "VerticalPlatform")
            //{
            //    transform.position = Vector2.MoveTowards(transform.position, new Vector2(GetComponentInParent<Transform>().position.x, targetPos.y), Speed * Time.deltaTime);
            //}


            //transform.position = Vector2(transform.position.x, GetComponentInParent<Transform>().position.y);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
}
