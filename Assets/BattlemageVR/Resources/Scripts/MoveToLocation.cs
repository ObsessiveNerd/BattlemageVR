using UnityEngine;
using System.Collections;

public class MoveToLocation : MonoBehaviour {
    public Vector3 TargetPosition = new Vector2();
    public float Speed = 1;

	// Update is called once per frame
	void Update () {
        var moveAmount = Speed * Time.deltaTime;
        var direction = TargetPosition - transform.position;

        if(moveAmount > direction.magnitude)
        {
            moveAmount = direction.magnitude;
        }

        transform.position += moveAmount * direction.normalized;
	}
}
