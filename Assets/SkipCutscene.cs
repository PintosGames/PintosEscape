using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkipCutscene : MonoBehaviour
{
    public void SkipScene()
    {
        Core.SceneManager.LoadNextScene();
    }
}
