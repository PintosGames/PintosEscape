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
        public GameObject gameOver;
        public Button pauseButton;

        public Sprite resume;
        public Sprite pause;

        public void Pause()
        {
            if (!isPaused)
            {
                pauseMenu.SetActive(true);
                timeText.text = Timer.GetTimerTime();
                isPaused = true;
                Time.timeScale = 0f;
            }
            else
            {
                Resume();
            }
        }

        public void Resume()
        {
            isPaused = false;
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }

        public void BackToMenu()
        {
            isPaused = false;
            FindObjectOfType<Timer>().timeValue = 0;
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
            pauseMenu.SetActive(false);
        }

        public void Restart()
        {
            isPaused = false;
            FindObjectOfType<Timer>().timeValue = 0;
            Time.timeScale = 1f;
            SceneManager.ReloadScene();
            pauseMenu.SetActive(false);
        }

        private void Update()
        {
            if (!pauseMenu.activeInHierarchy || !gameOver.activeInHierarchy) pauseButton.image.sprite = pause;
            else pauseButton.image.sprite = resume;
        }
    }

}