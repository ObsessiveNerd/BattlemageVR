using UnityEngine;
using System.Collections;

public class FollowHand : MonoBehaviour
{
    GameObject palm;
    Cast castScript;

    // Use this for initialization
    void Start()
    {
        palm = GameObject.Find("palm");
        castScript = GetComponent<Cast>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!castScript.casting)
        {
            Vector3 spellPos = palm.transform.position - (palm.transform.up * 0.15f);
            transform.position = spellPos;
        }
    }
}
