using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogError(collision.tag);
        if (collision.gameObject.tag == "Player") Core.CoreManager.GameOver();
    }
}
