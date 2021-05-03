using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public new AudioManager audio;

    private void Start()
    {
        audio.Play("Menu");
    }

    public void StartGame()
    {
        Destroy(audio.gameObject);

        Core.SceneManager.LoadNextScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
