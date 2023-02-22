using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(20, 10, 0);
    }
}
