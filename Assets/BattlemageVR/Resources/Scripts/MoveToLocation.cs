using UnityEngine;
using System.Collections;

public class MoveToLocation : MonoBehaviour
{
    public Vector3 TargetPosition = new Vector2();
    public float MaxSpeed = 1;
    public float Force = .01f;

    // Update is called once per frame
    void Update () {
        //var moveAmount = Speed * Time.deltaTime;
        //var direction = TargetPosition - transform.position;
        //
        //if(moveAmount > direction.magnitude)
        //{
        //    moveAmount = direction.magnitude;
        //}
        //
        //transform.position += moveAmount * direction.normalized;

        var force = Force * Time.deltaTime;
        var direction = (TargetPosition - transform.position).normalized;
        var body = gameObject.GetComponent<Rigidbody>();
        body.AddForce(direction * force);

        if(body.velocity.magnitude > MaxSpeed)
        {
            body.velocity = body.velocity.normalized * MaxSpeed;
        }
    }
}
