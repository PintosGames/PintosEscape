using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.HealthSystem
{
    public class HealthManager : MonoBehaviour
    {
        public HealthSystem healthSystem;
        public Animator animator;

        public bool damaged;

        private void OnEnable()
        {
            animator = GameObject.FindGameObjectWithTag("Health").GetComponent<Animator>();
        }

        private void Start()
        {
            healthSystem = new HealthSystem(CoreManager.current.player.GetComponent<Player>().playerData.maxHealth, CoreManager.current.player.GetComponent<Player>().playerData.damageCooldown);
            healthSystem.OnHealthChanged += HealthChange;
            animator.SetInteger("health", healthSystem.GetHealth());
            CoreManager.UpdatePresence();
        }

        private void Update()
        {
            CoreManager.current.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (Time.time > healthSystem.lastDamage + healthSystem.damageCooldown && healthSystem.health != 0) CoreManager.current.player.gameObject.layer = LayerMask.NameToLayer("Player");
        }

        private void HealthChange(object sender, System.EventArgs e)
        {
            animator.SetInteger("health", healthSystem.GetHealth());
            CoreManager.UpdatePresence();
        }
    }
}