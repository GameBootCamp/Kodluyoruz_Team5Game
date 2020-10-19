using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    NONE,
    HORIZONTAL,
    VERTICAL,
    Z_AXIS
}

public class MovePlatform : MonoBehaviour
{
    public Direction direction;
    public float speed;
    public float movementRange;

    private Vector3 directionVector = Vector3.zero;
    private Vector3 defaultPosition;
    private float posChange;

    private void Start()
    {
        defaultPosition = transform.position;
    }

    private void SetDirectionVector()
    {
        if (direction == Direction.NONE)
            directionVector = Vector3.zero;

        else if (direction == Direction.HORIZONTAL)
            directionVector = new Vector3(1, 0, 0);

        else if (direction == Direction.VERTICAL)
            directionVector = new Vector3(0, 1, 0);

        else if (direction == Direction.Z_AXIS)
            directionVector = new Vector3(0, 0, 1);
    }

    public void Update()
    {
        if (direction == Direction.NONE)
            return;

        SetDirectionVector();
        Move();
    }

    private void Move()
    {
        posChange = Mathf.Sin(Time.time * speed) * movementRange;
        transform.position = defaultPosition + directionVector * posChange;
    }
}