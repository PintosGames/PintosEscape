using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class HealPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CoreManager.current.health.healthSystem.Heal();
    }
}
