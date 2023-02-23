using UnityEngine;
using System.Collections;

public class PacerX : MonoBehaviour
{

    public float speed = 5.0f;
    public float xMax = 5f;
    public float xMin = 15f; //starting position
    public float zStart = 20f;
    private int direction = 1; //positive to start

    void Update()
    {
        float xNew = transform.position.x +
                    direction * speed * Time.deltaTime;
        if (xNew >= xMax)
        {
            xNew = xMax;
            direction *= -1;
            transform.Rotate(0, -180, 0);
        }
        else if (xNew <= xMin)
        {
            xNew = xMin;
            direction *= -1;
            transform.Rotate(0, -180, 0);
        }
        transform.position = new Vector3(xNew, 0.125f, zStart);
    }
}