using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRotatedIdiot : MonoBehaviour
{
    public float RotationSpeed = 6f;
    [SerializeField] private bool inverse;

    // Update is called once per frame
    void Update()
    {
        if (inverse)
        {
            transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime));
        }
        else
        {
            transform.Rotate(Vector3.forward * -1 * (RotationSpeed * Time.deltaTime));
        }
    }
}
