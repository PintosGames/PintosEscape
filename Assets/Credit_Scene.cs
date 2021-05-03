using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit_Scene : MonoBehaviour
{
    public float speed;
    public Transform target;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed / 15);
    }
}
