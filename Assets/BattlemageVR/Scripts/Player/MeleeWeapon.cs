using UnityEngine;
using System.Collections;

public class MeleeWeapon : MonoBehaviour
{
    GameObject Player;
    DamageStatistics stats;
    Mana mana;

    void Start()
    {
        Player = GameObject.Find("Player");
        stats = GetComponent<DamageStatistics>();
        mana = Player.GetComponent<Mana>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Projectile")
        {
            DamageStatistics projectileStats = collision.gameObject.GetComponent<DamageStatistics>();
            mana.GainMana(projectileStats.ManaBoost);
        }
        else if (collision.gameObject.name == "Enemy")
        {
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            enemyHealth.LoseHealth(stats.Damage);
        }
    }
}
