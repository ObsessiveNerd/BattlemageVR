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
    Mana playerMana;

    // Use this for initialization
    void Start()
    {
        playerMana = GetComponent<Mana>();
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
        GameObject activeSpell = Resources.Load("Prefabs/FireBall") as GameObject;
        Vector3 spellPos = Palm.transform.position - (Palm.transform.up * 0.15f);
        newlyConjuredSpell = GameObject.Instantiate(activeSpell, spellPos, Quaternion.identity) as GameObject;

        completedConjur = true;
        isConjuring = false;
    }

    public void Conjuring()
    {
        isConjuring = true;
        completedConjur = false;
        currentTime = 0.0f;
        startTime = Time.time;
    }

    public void StopConjuring()
    {
        isConjuring = false;
    }

    public void CastSpell()
    {
        if (completedConjur)
        {
            //TODO: Maybe send camera.forward and cast the direction you're looking?
            newlyConjuredSpell.GetComponent<Cast>().CastSpell(-Palm.transform.up);
            playerMana.LoseMana(newlyConjuredSpell.GetComponent<Cast>().ManaCost);
            completedConjur = false;
        }
        else
        {

        }
    }

    public void HandClosed()
    {
        handOpen = false;
    }

    public void HandOpen()
    {
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
