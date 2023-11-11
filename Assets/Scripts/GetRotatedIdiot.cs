using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRotatedIdiot : MonoBehaviour
{
    public float RotationSpeed = 6f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime));
    }
}
