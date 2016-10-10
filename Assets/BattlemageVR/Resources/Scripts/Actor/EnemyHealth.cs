using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;

    // Use this for initialization
    void Start()
    {
        CurrentHealth = MaxHealth;
        
    }

    public void GainHealth(int healthGained)
    {
        if (CurrentHealth + healthGained > MaxHealth)
            CurrentHealth = MaxHealth;
        else
            CurrentHealth += healthGained;
    }

    public void LoseHealth(int healthLost)
    {
        if(CurrentHealth - healthLost <= 0)
        {
            CurrentHealth = 0;
            Destroy(gameObject);
        }
        else
        {
            CurrentHealth -= healthLost;
        }
    }
}
