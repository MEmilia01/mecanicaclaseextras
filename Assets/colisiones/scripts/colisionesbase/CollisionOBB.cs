using UnityEngine;

public class CollisionOBB : MonoBehaviour
{
    public Transform colliderCenter;
    public float colliderHeight;
    public float colliderWidth;
    public float colliderLenght;


    public Transform point;
    public Material mat;
    public Color collidingColor;
    public Color freeColor;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CalculateOBBCol())
        {
            mat.color = collidingColor;
        }
        else
        {
            mat.color = freeColor;
        }
    }

    bool CalculateOBBCol()
    {
        if (colliderCenter == null || point == null)
            return false;

        Vector3 axisRight = colliderCenter.right.normalized;
        Vector3 axisUp = colliderCenter.up.normalized;
        Vector3 axisForward = colliderCenter.forward.normalized;

        Vector3 centerToPoint = point.position - colliderCenter.position;

        float projectionRight = Vector3.Dot(centerToPoint, axisRight);
        float projectionUp = Vector3.Dot(centerToPoint, axisUp);
        float projectionForward = Vector3.Dot(centerToPoint, axisForward);

        float halfWidth = colliderWidth * 0.5f;
        float halfHeight = colliderHeight * 0.5f;
        float halfLength = colliderLenght * 0.5f;

        if (Mathf.Abs(projectionRight) <= halfWidth &&
        Mathf.Abs(projectionUp) <= halfHeight &&
        Mathf.Abs(projectionForward) <= halfLength)
        {
            return true;
        }

        return false;
    }
}
