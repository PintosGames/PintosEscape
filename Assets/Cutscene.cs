using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public void EndOfCutscene()
    {
        Core.SceneManager.LoadNextScene();
    }
}
