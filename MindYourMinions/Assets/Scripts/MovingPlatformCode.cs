using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformCode : MonoBehaviour
{
    public float delta = .5f;  // Amount to move up and down from the start point
    public float speed = .5f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 v = startPos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
