using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 point1;
    public Vector3 point2;

    public float speed;

    Vector3 target;

    private void Start()
    {
        transform.position = point1;
    }

    private void Update()
    {
        if (transform.position == point2) target = point1;
        else if (transform.position == point1) target = point2;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

}
