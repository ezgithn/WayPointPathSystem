using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    public Transform target; 
    [SerializeField]
    public Vector3 offset = new Vector3(0f, 5f, -10f);
    [SerializeField]
    public float smoothSpeed = 0.125f;

    
    private void LateUpdate()
    {
        var desiredPosition = target.position + offset;
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
