using UnityEngine;

public class CollisionFuntions : MonoBehaviour
{
    public Transform colliderCenter;
    public Vector2 ratonposicion;


    [Header("Colision AABB y OBB")]
    public float colliderHeight;
    public float colliderWidth;
    public float colliderLenght;

    [Header("Colision circulo")]
    public float radius;

    public Transform point;
    public Material mat;
    public Color collidingColor;
    public Color freeColor;

    void Start()
    { }

    void Update()
    {
        if (freeColor)
        {
            mat.color = collidingColor;
        }
        else
        {
            mat.color = freeColor;
        }
    }



    bool CalculateEsfereRadius()
    {
        return radius > (Vector3.Distance(colliderCenter.position, point.position));
    }

    bool CalculateAABBCol()
    {
        bool axisX = point.position.x > colliderCenter.position.x - colliderWidth * 0.5f &&
            point.position.x < colliderCenter.position.x + colliderWidth * 0.5f;
        bool axisY = point.position.y > colliderCenter.position.y - colliderHeight * 0.5f &&
            point.position.y < colliderCenter.position.y + colliderHeight * 0.5f;
        bool axisZ = point.position.z > colliderCenter.position.z - colliderLenght * 0.5f &&
            point.position.z < colliderCenter.position.z + colliderLenght * 0.5f;

        return axisX && axisY && axisZ;
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
