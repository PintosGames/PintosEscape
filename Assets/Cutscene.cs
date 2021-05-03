using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public new AudioManager audio;

    private void Start()
    {
        audio.Play("Song1");
    }

    public void EndOfCutscene()
    {
        Core.SceneManager.LoadNextScene();
    }
}
