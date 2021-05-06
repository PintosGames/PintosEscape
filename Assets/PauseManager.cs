using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Core
{
    public class PauseManager : MonoBehaviour
    {
        public static bool isPaused;
        public TextMeshProUGUI timeText;
        public GameObject pauseMenu;
        public Button pauseButton;

        public void Pause()
        {
            timeText.text = Timer.GetTimerTime();
            pauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }

        public void Restart()
        {
            FindObjectOfType<Timer>().timeValue = 0;
            SceneManager.ReloadScene();
        }

        public void Resume()
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
        }

        public void BackToMenu()
        {
            FindObjectOfType<Timer>().timeValue = 0;
            pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        private void Update()
        {
            if (pauseMenu.activeInHierarchy || !CoreManager.current.scene.scenes[CoreManager.current.scene.currentBuildIndex].gameScene) pauseButton.gameObject.SetActive(false);
            else pauseButton.gameObject.SetActive(true);
        }
    }

}