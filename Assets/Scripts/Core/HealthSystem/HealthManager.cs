using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.HealthSystem
{
    public class HealthManager : MonoBehaviour
    {
        public HealthSystem healthSystem;
        public Animator animator;

        private void OnEnable()
        {
            animator = GameObject.FindGameObjectWithTag("Health").GetComponent<Animator>();
        }

        private void Start()
        {
            healthSystem = new HealthSystem(CoreManager.current.player.GetComponent<Player>().playerData.maxHealth);
            healthSystem.OnHealthChanged += HealthChange;
            animator.SetInteger("health", healthSystem.GetHealth());
        }

        private void HealthChange(object sender, System.EventArgs e)
        {
            animator.SetInteger("health", healthSystem.GetHealth());
        }
    }
}