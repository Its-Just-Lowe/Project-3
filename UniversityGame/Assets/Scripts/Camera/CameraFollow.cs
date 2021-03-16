using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    public bool usesBounds = false;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;

            if (usesBounds)
            {
                desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
                desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);
            }

            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPos;
        }
    }
}
