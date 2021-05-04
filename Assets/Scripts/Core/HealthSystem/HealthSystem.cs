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
                if (health == 0)
                {
                    Die();
                    return;
                }
                lastDamage = Time.time;
                CoreManager.current.player.gameObject.layer = LayerMask.NameToLayer("Damaged");
            }
        }

        public void Die()
        {
            var player = CoreManager.current.player;

            player.StateMachine.ChangeState(player.DeadState);
            player.RB.AddForce(new Vector2(0, CoreManager.current.player.playerData.knockbackPower * 3));
            player.gameObject.layer = LayerMask.NameToLayer("Dead");
            Debug.Log("ded");
        }

        public void Kill()
        {
            health = 0;
            if (health == 0) CoreManager.GameOver();
            GameObject.FindObjectOfType<AudioManager>().Play("Damage");
            if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
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