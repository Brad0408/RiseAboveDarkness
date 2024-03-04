using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    //New camera pos modifications
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, offset.z);
    }
}

