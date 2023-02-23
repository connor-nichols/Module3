using UnityEngine;
using System.Collections;

public class PacerZ : MonoBehaviour
{

    public float speed = 5.0f;
    public float zMax = 5f;
    public float zMin = 15f; //starting position
    public float xStart = 20f;
    private int direction = 1; //positive to start

    private void Start()
    {
    }

    void Update()
    {
        float zNew = transform.position.z +
                    direction * speed * Time.deltaTime;

        if (zNew >= zMax)
        {
            zNew = zMax;
            direction *= -1;
            transform.Rotate(0, -180, 0);
        }
        else if (zNew <= zMin)
        {
            zNew = zMin;
            direction *= -1;
            transform.Rotate(0, -180, 0);
        }
        transform.position = new Vector3(xStart, 0.125f, zNew);
    }
}