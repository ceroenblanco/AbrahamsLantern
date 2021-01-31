using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target;

    Vector3 offset;

    private void Start()
    {
        offset = transform.position;
    }

    private void Update()
    {
        transform.position = target.position + offset;
    }
}
