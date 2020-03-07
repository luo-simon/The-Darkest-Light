using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public float angle;

    void Update()
    {

        angle = GetAngleFromVector(transform.parent.transform.position);
        transform.eulerAngles = Vector3.forward * (angle + 90);
    }

    private float GetAngleFromVector(Vector2 vector)
    {
        // tan(a) = vector.y / vector.x
        // a = arctan(vector.y / vector.x)
        return Mathf.Atan2(vector.y, vector.x) * (180 / Mathf.PI);
    }
}
