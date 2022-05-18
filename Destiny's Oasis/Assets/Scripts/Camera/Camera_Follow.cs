using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
// Script to allow the camera object to follow the player sprite
{
    public Transform target;
    // Gets the transform data (location, rotation etc) of the target
    public Vector3 offset;
    // enables an offset to be modified without hardcoding

    void Update()
    {
        transform.position = target.position + offset;
        // places the camera at the same location as the camera with the offset
    }
}
