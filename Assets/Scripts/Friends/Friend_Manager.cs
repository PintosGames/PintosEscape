using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Friend_Manager : MonoBehaviour
{
    public Friend_Class friend;

    public Animation aniMan;

    private void Start()
    {
        aniMan.clip = friend.animation;
    }

    void Update()
    {
        if (aniMan.clip == null) aniMan.clip = friend.animation;
    }
}
