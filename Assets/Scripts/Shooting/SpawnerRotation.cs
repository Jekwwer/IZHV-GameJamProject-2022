using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRotation : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 5;

    void Start()
    {
        transform.parent = target.transform;
        transform.LookAt(target.transform);
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        target.transform.Rotate(vertical, horizontal, 0);
    }
}


