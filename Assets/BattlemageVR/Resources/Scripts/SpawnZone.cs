using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public float SpawnRateInSeconds = 1;
    public GameObject SpawnObject;

    private float _lastSpawnTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _lastSpawnTime > SpawnRateInSeconds)
        {
            _lastSpawnTime = Time.time;
            SpawnRandom();
        }
    }

    private void SpawnRandom()
    {
        var t = transform;
        var extent = t.localScale / 2;
        var topForwardRight = t.position + t.up * extent.y + t.right * extent.x + t.forward * extent.z;
        var bottomBackLeft = t.position - t.up * extent.y - t.right * extent.x - t.forward * extent.z;
        var randPosition = new Vector3(
            RandRange(topForwardRight.x, bottomBackLeft.x),
            RandRange(topForwardRight.y, bottomBackLeft.y),
            RandRange(topForwardRight.z, bottomBackLeft.z));

        var spawn = Instantiate(SpawnObject);
        spawn.transform.position = randPosition;
        spawn.transform.SetParent(transform, true);
    }

    private static float RandRange(float a, float b)
    {
        if (a < b)
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
