using UnityEngine;
using System.Collections;
using System;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothFactor = 0.5f;

    private Vector3 initialPosition;
    private Vector3 offset;
    private bool turnStartPoint = false;

    private void Awake()
    {
        initialPosition = transform.position;
        offset = target.position - transform.position;
    }

    void FixedUpdate()
    {
        if (turnStartPoint)
        {
            transform.position = Vector3.Slerp(transform.position, initialPosition, smoothFactor * 5);
            float distance = Vector3.Distance(transform.position, initialPosition);
            if (Math.Abs(distance) <= 0)
                turnStartPoint = false;
            Debug.Log(turnStartPoint);
        }

        else
        {
            if (target.position.y < 0)
                return;
                
            transform.position = Vector3.Slerp(transform.position, target.position - offset, smoothFactor);
        }
    }
}