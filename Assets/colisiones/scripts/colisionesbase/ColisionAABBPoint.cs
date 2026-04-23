using UnityEngine;

public class ColisionAABBPoint : MonoBehaviour
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
        if (CalculateAABBCol())
        {
            mat.color = collidingColor;
        }
        else
        {
            mat.color = freeColor;
        }
    }

    bool CalculateAABBCol()
    {
        bool axisX = point.position.x > colliderCenter.position.x - colliderWidth * 0.5f && 
            point.position.x < colliderCenter.position.x + colliderWidth*0.5f;
        bool axisY = point.position.y > colliderCenter.position.y - colliderHeight * 0.5f &&
            point.position.y < colliderCenter.position.y + colliderHeight * 0.5f;
        bool axisZ = point.position.z > colliderCenter.position.z - colliderLenght * 0.5f &&
            point.position.z < colliderCenter.position.z + colliderLenght * 0.5f;

        return axisX && axisY && axisZ;
    }
}
