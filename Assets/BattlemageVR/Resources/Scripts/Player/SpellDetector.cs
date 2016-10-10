using UnityEngine;
using System.Collections;

public class SpellDetector : MonoBehaviour
{
    bool isConjuring = false;
    bool completedConjur = false;
    bool handOpen = true;
    bool castingSpell = false;

    float currentTime;
    float startTime;
    float timeToConjur = 2.0f;

    public GameObject Palm;
    GameObject newlyConjuredSpell;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isConjuring)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= timeToConjur)
            {
                CompleteConjuring();
            }
        }

        if (completedConjur && castingSpell && handOpen)
        {
            CastSpell();
        }
    }

    void CompleteConjuring()
    {
        GameObject activeSpell = Resources.Load("Prefabs/MagicBall") as GameObject;
        Vector3 spellPos = Palm.transform.position - (Palm.transform.up * 0.15f);
        newlyConjuredSpell = GameObject.Instantiate(activeSpell, spellPos, Quaternion.identity) as GameObject;

        //Debug.Log("Finished Conjuring!");
        completedConjur = true;
        isConjuring = false;
    }

    public void Conjuring()
    {
        isConjuring = true;
        completedConjur = false;
        currentTime = 0.0f;
        startTime = Time.time;
        //Debug.Log("Started Conjuring!");
    }

    public void StopConjuring()
    {
        isConjuring = false;
        //Debug.Log("Stopped Conjuring!");
    }

    public void CastSpell()
    {
        if (completedConjur)
        {
            //Debug.Log("Cast Spell!");
            newlyConjuredSpell.GetComponent<Cast>().CastSpell(-Palm.transform.up);
            completedConjur = false;
        }
        else
        {
            //Debug.Log("Dry Fire.");
        }
    }

    public void HandClosed()
    {
        Debug.Log("Hand Closed");
        handOpen = false;
    }

    public void HandOpen()
    {
        Debug.Log("Hand Open");
        handOpen = true;
    }

    public void CastingSpell()
    {
        castingSpell = true;
    }

    public void NotCastingSpell()
    {
        castingSpell = false;
    }
}
