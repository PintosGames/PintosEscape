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

        public HealthSystem(int maxHealth)
        {
            this.maxHealth = maxHealth;
            health = maxHealth;
            if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
        }

        public int GetHealth()
        {
            return health;
        }

        public void Damage()
        {
            if (health > 0) health--;
            if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
        }

        public void Heal()
        {
            if (health < maxHealth) health++;
            Debug.Log("Healing");
            if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
        }

        public void FullHeal()
        {
            health = maxHealth;
            if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
        }
    }

}