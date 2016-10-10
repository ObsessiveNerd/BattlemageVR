using UnityEngine;
using System.Collections;

public class Cast : MonoBehaviour
{
    public float Speed;
    Vector3 castDirection;
    public bool casting = false;

    void Start()
    {
    }

    void Update()
    {
        if (casting)
        {
            transform.position = (transform.position + (castDirection * Speed * Time.deltaTime));
        }
    }

    public void CastSpell(Vector3 castDir)
    {
        castDirection = castDir;
        casting = true;
    }
}
