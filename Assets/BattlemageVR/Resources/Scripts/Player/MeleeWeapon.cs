using UnityEngine;
using System.Collections;

public class MeleeWeapon : MonoBehaviour
{
    GameObject Player;
    DamageStatistics stats;
    Mana mana;
    public Camera cam;

    void Start()
    {
        Player = GameObject.Find("Player");
        stats = GetComponent<DamageStatistics>();
        mana = Player.GetComponent<Mana>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyArcherProjectile")
        {
            DamageStatistics projectileStats = collision.gameObject.GetComponent<DamageStatistics>();
            mana.GainMana(projectileStats.ManaBoost);   
            float camZ = cam.transform.forward.normalized.z;
            Vector3 newArrowVelocity = new Vector3(
                PSMoveInput.MoveControllers[0].Data.Velocity.normalized.x, 
                PSMoveInput.MoveControllers[0].Data.Velocity.normalized.y, 
                camZ) * 10;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(newArrowVelocity, ForceMode.Impulse);
            Destroy(collision.gameObject, 3.0f);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.LoseHealth(stats.Damage);
        }
    }
}
