using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform plane;
    public Vector3 cameraoffest;

    // Update is called once per frame
    void Update()
    {
        transform.position = plane.position + cameraoffest;
    }
}
