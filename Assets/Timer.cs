using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeValue;

    public TextMeshProUGUI timeText;

    public static Timer current;

    void Start()
    {
        if (current == null)
        {
            current = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update() => UpdateTime();

    public void UpdateTime()
    {
        if (CoreManager.current.scene.scenes[CoreManager.current.scene.currentBuildIndex].gameScene)
        {
            timeText.gameObject.SetActive(true);

            timeValue += Time.deltaTime;

            timeText.text = GetTimerTime();
        }
        else timeText.gameObject.SetActive(false);
    }

    public static string GetTimerTime()
    {
        float minutes = Mathf.RoundToInt(current.timeValue / 60);
        float seconds = Mathf.RoundToInt(current.timeValue % 60);
        float milliseconds = current.timeValue % 1 * 1000;

        string time = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        time = time.Remove(time.Length - 1, 1);

        return time;
    }
}
