using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit_Scene : MonoBehaviour
{
    public float speed;
    public Transform target;
    public AudioManager audio;

    private void Start()
    {
        audio.Play("Credits");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed / 15);
        if (transform.position == target.position) Core.SceneManager.LoadScene(0);;
    }
}
