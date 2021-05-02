using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void Restart()
    {
        Core.SceneManager.ReloadScene();
        Core.CoreManager.current.gameOverAnimator.SetBool("open", false);
    }

    public void Exit()
    {
        Core.SceneManager.LoadScene(0);
        Core.CoreManager.current.gameOverAnimator.SetBool("open", false);
    }
}
