using Game;
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
        SetDirectionVector();
    }

    public void Update()
    {
        if (direction == Direction.NONE)
            return;
#if DEBUG
        SetDirectionVector();
#endif
        Move();
    }

    private void SetDirectionVector()
    {
        if (direction == Direction.NONE)
            directionVector = Vector3.zero;

        else if (direction == Direction.HORIZONTAL)
            directionVector = Constants.X_AXIS;

        else if (direction == Direction.VERTICAL)
            directionVector = Constants.Y_AXIS;

        else if (direction == Direction.Z_AXIS)
            directionVector = Constants.Z_AXIS;
    }

    private void Move()
    {
        posChange = Mathf.Sin(Time.time * speed) * movementRange;
        transform.position = defaultPosition + directionVector * posChange;
    }
}