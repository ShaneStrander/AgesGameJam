using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlaySwitch : MonoBehaviour
{

    public GameObject[] images;
    public GameObject buttonLeft;
    public GameObject buttonRight;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(index >= 5)
        {
            index = 5;
            buttonRight.SetActive(false);
        }

        if (index > 0)
        {
            buttonLeft.SetActive(true);
        }

        if (index < 5)
        {
            buttonRight.SetActive(true);
        }

        if (index < 0)
        {
            index = 0;
        }

        if(index == 0)
        {
            images[0].gameObject.SetActive(true);
            buttonLeft.SetActive(false);
        }
    }

    public void Next()
    {
        index += 1;

        for(int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
            images[index].gameObject.SetActive(true);
        }
    }

    public void Previous()
    {
        index -= 1;

        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
            images[index].gameObject.SetActive(true);
        }
    }
}
