using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Transform target;
    public float cameraSpeed;

    Vector3 offset;

  
    void Start()
    {
        offset = transform.position - target.position;  
    }

    
    void Update()
    {
        transform.position = target.position + offset;
    }
}
