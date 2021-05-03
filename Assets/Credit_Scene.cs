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
        audio.Stop("Song2");
        audio.Play("Credits");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed / 15);
        if (transform.position == target.position) StartCoroutine(GoToStartScene());
    }

    IEnumerator GoToStartScene()
    {
        //This is a coroutine
        Debug.Log("Start Wait() function. The time is: " + Time.time);
        Debug.Log("Float duration = " + 3);
        yield return new WaitForSeconds(3);   //Wait
        Debug.Log("End Wait() function and the time is: " + Time.time);
        Core.SceneManager.LoadScene(0);
    }
}
