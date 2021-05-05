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

        public void Pause()
        {
            timeText.text = Timer.GetTimerTime();
            pauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
        }

        public void BackToMenu()
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            FindObjectOfType<Timer>().timeValue = 0;
            Time.timeScale = 1f;
        }

        private void Update()
        {
            if (pauseMenu.activeInHierarchy || gameOver.activeInHierarchy) pauseButton.gameObject.SetActive(false);
            else pauseButton.gameObject.SetActive(true);
        }
    }

}