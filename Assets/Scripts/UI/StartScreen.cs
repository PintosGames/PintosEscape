using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public void StartGame()
    {
        Core.SceneManager.LoadNextScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
