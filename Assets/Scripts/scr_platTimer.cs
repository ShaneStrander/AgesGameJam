using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_platTimer : MonoBehaviour
{
    private bool playerOnPlatform = false;
    private float disappearTime = 1f;
    private float elapsedTime = 0f;
    private bool hasBeenTouched = false;
    private float t;

    private Animator anim;


    private BoxCollider2D coll;

    [SerializeField] private LayerMask playerLayer;

    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        GetComponent<SpriteRenderer>().color = Color.white;
        anim = GetComponent<Animator>();
    }


    private bool detectPlayer()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.up, 0.1f, playerLayer);
    }

    private void Update()
    {
        if (detectPlayer())
        {
            //ChangeColor();'
            Debug.Log("AÖLFJSDA_FL");
            hasBeenTouched = true;

            Invoke("DisappearPlatform", disappearTime);
          
                
        }
        if(hasBeenTouched)
        {

            anim.SetTrigger("Touched");
            elapsedTime += Time.deltaTime;
            t = Mathf.Clamp01(elapsedTime / disappearTime);
            Color lerpedColor = Color.Lerp(Color.white, Color.red, t);
            GetComponent<SpriteRenderer>().color = lerpedColor;
        }
        
    }

    private void ChangeColor()
    {
        if (!hasBeenTouched)
        {
            Debug.Log("fvsdegnbouivfdrsenubioj");
            Color lerpedColor = Color.Lerp(Color.white, Color.red, t);
            GetComponent<SpriteRenderer>().color = lerpedColor;
            hasBeenTouched = true;
        }
    }

    private void DisappearPlatform()
    {
        // Disable the platform after the transition
        gameObject.SetActive(false);
    }
}
