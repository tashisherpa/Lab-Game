using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;

    //update is called once per frame
    private void FixedUpdate()
    {
        this.transform.position = new Vector3(followTransform.transform.position.x, followTransform.transform.position.y, this.transform.position.z);
    }
}
