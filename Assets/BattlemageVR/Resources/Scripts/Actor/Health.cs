﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;

    public Slider healthSlider;

    // Use this for initialization
    void Start()
    {
        CurrentHealth = MaxHealth;
        
    }

    void OnCollisionEnter(Collision collision)
    {
        DamageStatistics stats = collision.gameObject.GetComponent<DamageStatistics>();
        LoseHealth(stats.Damage);
    }

    public void GainHealth(int healthGained)
    {
        if (CurrentHealth + healthGained > MaxHealth)
            CurrentHealth = MaxHealth;
        else
            CurrentHealth += healthGained;

        healthSlider.value = CurrentHealth;
    }

    public void LoseHealth(int healthLost)
    {
        if(CurrentHealth - healthLost <= 0)
        {
            CurrentHealth = 0;
            //TODO: publish event Game Over
        }
        else
        {
            CurrentHealth -= healthLost;
        }

        healthSlider.value = CurrentHealth;
    }
}
