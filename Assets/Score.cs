using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    void Start()
    {
        timeText.text = Timer.GetTimerTime();
        Debug.Log(Timer.GetTimerTime());
    }

    public void Restart()
    {
        FindObjectOfType<Timer>().timeValue = 0;
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        FindObjectOfType<Timer>().timeValue = 0;
        SceneManager.LoadScene(0);
    }
}
