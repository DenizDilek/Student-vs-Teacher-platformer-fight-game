using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;


    void FixedUpdate()
    {
        Vector3 desiredposition = target.position + offset;
        Vector3 smoothedposition = Vector3.SmoothDamp(transform.position, desiredposition, ref velocity, smoothSpeed * Time.fixedDeltaTime);
        transform.position = smoothedposition;
    }
}
