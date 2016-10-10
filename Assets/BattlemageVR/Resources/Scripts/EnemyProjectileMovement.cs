using UnityEngine;
using System.Collections;

public class EnemyProjectileMovement : MonoBehaviour
{
    public Vector3 TargetPosition = new Vector2();
    public float MaxSpeed = 1;
    public float Force = .01f;

    float rotateSpeed = 2.0f;
    bool shooting = true;

    // Update is called once per frame
    void Update()
    {
        if (shooting)
        {
            var force = Force * Time.deltaTime;
            var direction = (TargetPosition - transform.position).normalized;
            var body = gameObject.GetComponent<Rigidbody>();
            body.AddForce(direction * force);

            if (body.velocity.magnitude > MaxSpeed)
            {
                body.velocity = body.velocity.normalized * MaxSpeed;
            }
        }
        else
        {
            transform.Rotate(new Vector3(transform.rotation.x + rotateSpeed, transform.rotation.y + rotateSpeed, transform.rotation.z + rotateSpeed));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            shooting = false;
        }
        if(collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
