using UnityEngine;
using System.Collections;

public class DespawnAtLocation : MonoBehaviour
{
    public Vector3 TargetLocation = new Vector3(0, 0, 0);

	// Update is called once per frame
	void Update () {
	    if((transform.position - TargetLocation).magnitude < .0001f)
        {
            Destroy(gameObject);
        }
	}
}
