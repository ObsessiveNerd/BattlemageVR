using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{

    Slider slider;
    Mana playerHealth;

    int tempMaxHealth = 100;
    int tempHealth = 100;

    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
        playerHealth = GameObject.Find("Player").GetComponent<Mana>();

    }

    public void SetHealthBar()
    {
        slider.value = playerHealth.CurrentMana;
    }

}
