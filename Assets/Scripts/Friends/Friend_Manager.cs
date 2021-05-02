using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Friend_Manager : MonoBehaviour
{
    public Friend_Class friend;

    public Animator animator;

    private void Start()
    {
        animator.Play(friend.name);
    }

    void Update()
    {
        
    }
}
