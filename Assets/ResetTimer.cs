using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTimer : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<Timer>().timeValue = 0f;
    }
}
