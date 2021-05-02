using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Friend_Manager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
