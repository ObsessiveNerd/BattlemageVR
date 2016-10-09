using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    Health playerHealth;

    int tempMaxHealth = 100;
    int tempHealth = 100;

    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
        playerHealth = GameObject.Find("Player").GetComponent<Health>();

    }

    public void SetHealthBar()
    {
        slider.value = playerHealth.CurrentHealth;
    }

}
