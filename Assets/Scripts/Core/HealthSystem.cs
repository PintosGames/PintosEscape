using System;

public class HealthSystem
{
    public event EventHandler OnHealthChanged;

    private int health;
    private int maxHealth;

    public HealthSystem(int maxHealth)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
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
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    public void FullHeal()
    {
        health = maxHealth;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }
}
