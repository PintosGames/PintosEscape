using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform point1;
    public Transform point2;

    public float speed;

    Vector3 target;

    private void Start()
    {
        transform.position = point1.position;
    }

    private void Update()
    {
        if (transform.position == point2.position) target = point1.position;
        else if (transform.position == point1.position) target = point2.position;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime * Vector2.Distance(point1.position, point2.position));
    }

}
