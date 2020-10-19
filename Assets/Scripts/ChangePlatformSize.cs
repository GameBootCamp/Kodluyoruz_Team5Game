#define DEBUG
using Game;
using UnityEngine;

public enum SizeChangeType
{
    NONE,
    WIDTH_CHANGE,
    LENGTH_CHANGE,
    DEPTH_CHANGE,
    UNIFORM_CHANGE
}

public class ChangePlatformSize : MonoBehaviour
{
    public SizeChangeType sizeChangeType;
    public float maxSizeLimit = 3;
    public float MinSizeLimit = 2;

    private Vector3 defaultSize;
    private Vector3 changeVector = Vector3.zero;

    private void Start()
    {
        defaultSize = transform.localScale;
        SetChangeVector();
    }

    void Update()
    {
        if (sizeChangeType == SizeChangeType.NONE)
            return;
#if DEBUG
        SetChangeVector();
#endif
        UpdateSize();
    }

    private void SetChangeVector()
    {
        if (sizeChangeType == SizeChangeType.NONE)
            changeVector = Vector3.zero;

        else if (sizeChangeType == SizeChangeType.WIDTH_CHANGE)
            changeVector = Constants.X_AXIS;

        else if (sizeChangeType == SizeChangeType.LENGTH_CHANGE)
            changeVector = Constants.Y_AXIS;

        else if (sizeChangeType == SizeChangeType.DEPTH_CHANGE)
            changeVector = Constants.Z_AXIS;

        else if (sizeChangeType == SizeChangeType.UNIFORM_CHANGE)
            changeVector = new Vector3(1, 1, 1);
    }

    private void UpdateSize()
    {
        float changeAmount = Mathf.PingPong(Time.time, (maxSizeLimit - MinSizeLimit)) + MinSizeLimit;
        transform.localScale = defaultSize + changeVector * changeAmount;
    }




}
