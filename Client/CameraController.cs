using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public Transform target;

    public Vector3 offset;
    Vector3 velocity = Vector3.zero;


    float smoothingSpeed = 0.25f;

    void Start()
    {
        target = FindObjectOfType<PlayerControl>().gameObject.transform;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            CameraFollow();
        }
    }

    void CameraFollow()
    {

        Vector3 camPosition = target.position + offset;
        Vector3 smoothing = Vector3.SmoothDamp(transform.position, camPosition, ref velocity, smoothingSpeed);
        transform.position = smoothing;
    }
}
