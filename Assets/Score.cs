using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI timeCheck;

    private int[] time;
    private float checkTimeValue;

    void Start()
    {
        timeText.text = Timer.GetTimerTime();

        time = Timer.GetTimeInInt();

        checkTimeValue = (time[0] * 3) + (time[1] * 1) + (time[2] * 3);
        checkTimeValue = checkTimeValue - ((checkTimeValue / 10) * 10);
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
