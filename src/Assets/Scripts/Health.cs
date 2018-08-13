using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{

    public int maxHealth;
    public float CurrentHealth { get; private set; }
    public UnityEvent killed;
    public bool destroyOnDeath = true;

    internal bool AtFullHealth()
    {
        return CurrentHealth == maxHealth;
    }

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        // Short circuit so that killed only gets invoked once
        if (CurrentHealth <= 0)
            return;

        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            killed.Invoke();
            CurrentHealth = 0;

            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
        }
    }
}
