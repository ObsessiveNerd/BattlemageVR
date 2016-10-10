using UnityEngine;
using System.Collections;

public class Mana : MonoBehaviour
{
    public int MaxMana = 100;
    public int CurrentMana;

    // Use this for initialization
    void Start()
    {
        CurrentMana = MaxMana;
    }

    public void GainMana(int manaGained)
    {
        if (CurrentMana + manaGained > MaxMana)
            CurrentMana = MaxMana;
        else
            CurrentMana += manaGained;
    }

    public void LoseMana(int manaLost)
    {
        if (CurrentMana - manaLost <= 0)
        {
            CurrentMana = 0;
        }
        else
        {
            CurrentMana -= manaLost;
        }
    }
}
