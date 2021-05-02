using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioManager audio;

    public string title;

    private void Start()
    {
        audio.Play(title);
    }
}
