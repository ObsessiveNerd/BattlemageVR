using UnityEngine;
using System.Collections;

public class EnemyProjectileSpawnZone : MonoBehaviour
{
    public float SpawnRateInSeconds = 1;

    private float _lastSpawnTime = 0;

	// Update is called once per frame
	void Update () {
	    if(Time.time - _lastSpawnTime > SpawnRateInSeconds)
        {
            _lastSpawnTime = Time.time;
            SpawnRandomProjectile();
        }
	}

    private void SpawnRandomProjectile()
    {
        var t = transform;
        var extent = t.localScale / 2;
        var topForwardRight = t.position + t.up * extent.y / 2 + t.right * extent.x / 2 + t.forward * extent.z;
        var bottomBackLeft = t.position - t.up * extent.y / 2 - t.right * extent.x / 2 - t.forward * extent.z;
        var randPosition = new Vector3(
            RandRange(topForwardRight.x, bottomBackLeft.x),
            RandRange(topForwardRight.y, bottomBackLeft.y),
            RandRange(topForwardRight.z, bottomBackLeft.z));

        var projectile = Instantiate(PrefabFactory.RedFireballPrefab);
        projectile.transform.position = randPosition;
        var moveScript = projectile.AddComponent<MoveToLocation>();
        moveScript.Speed = 1f;
        moveScript.TargetPosition = new Vector3(0, 1, 0);
        projectile.transform.SetParent(transform, true);
    }

    private static float RandRange(float a, float b)
    {
        if(a < b)
            return Random.Range(a, b);
        return Random.Range(b, a);
    }

    // Draw the bounds of the spawn zone in edit mode
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
