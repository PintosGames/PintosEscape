using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public new AudioManager audio;

    public void Restart()
    {
        Core.SceneManager.ReloadScene();
        Core.CoreManager.current.gameOverAnimator.SetBool("open", false);
    }

    public void Exit()
    {
        Destroy(audio.gameObject);

        Core.SceneManager.LoadScene(0);
        Core.CoreManager.current.gameOverAnimator.SetBool("open", false);
    }
}
