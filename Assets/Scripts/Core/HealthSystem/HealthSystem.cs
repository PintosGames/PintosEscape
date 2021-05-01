using System;
using UnityEngine;

namespace Core.HealthSystem
{
    [Serializable]
    public class HealthSystem
    {
        public event EventHandler OnHealthChanged;

        public int health;
        public int maxHealth;

        public float damageCooldown;

        public float lastDamage;

        public HealthSystem(int maxHealth, float damageCooldown)
        {
            this.maxHealth = maxHealth;
            this.damageCooldown = damageCooldown;
            health = maxHealth;
        }

        public int GetHealth()
        {
            return health;
        }

        public void Damage()
        {
            if (Time.time > lastDamage + damageCooldown)
            {
                if (health > 0) health--;
                if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
                lastDamage = Time.time;
                CoreManager.current.player.layer = LayerMask.NameToLayer("Damaged");
            }
        }

        public void Heal()
        {
            if (health < maxHealth) health++;
            if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
        }

        public void FullHeal()
        {
            health = maxHealth;
            if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
        }
    }

}