using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateTransform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 PolarToCartesian2D(Vector2 origin, float r, float theta)
    {

        float xMove = Mathf.Sin(theta * Mathf.Deg2Rad) * r;
        float yMove = Mathf.Cos(theta * Mathf.Deg2Rad) * r;

        float xResult = xMove + origin.x;
        float yResult = yMove + origin.y;

        return new Vector2(xResult, yResult);

    }

    public Vector2 CartesianToPolar2D(Vector2 origin, float x, float y)
    {
        // 平方根の計算が重かったらx/cosθに変える
        float rMove = Mathf.Sqrt(Mathf.Pow((x - origin.x), 2f) + Mathf.Pow((y - origin.y), 2f));
        float theta = Mathf.Atan2((y - origin.y), (x - origin.x));

        return new Vector2(rMove, theta);

    }

}
