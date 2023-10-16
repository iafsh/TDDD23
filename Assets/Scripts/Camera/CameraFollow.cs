using System;
using Unity.Mathematics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.5f;
    public Transform target;
    public Collider2D Walls;
    private Vector3 offset = new Vector3(0, 0.3f, -10);

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position ;
        //float a=math.clamp(desiredPosition.x, Walls.bounds.min.x + 4, Walls.bounds.max.x - 4);
        //print(a);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition + offset;
        
    }
    
    
}
