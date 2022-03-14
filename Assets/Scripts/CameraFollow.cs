using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothness = 0.1f;
    Vector3 offset;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform == null || target == null) { return; }
        Vector3 oldPos = transform.position;
        transform.position = Vector3.Lerp(oldPos, target.position + offset, 1.0f - smoothness);
    }
}
