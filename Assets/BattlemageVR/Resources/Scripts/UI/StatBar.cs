using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public GameObject BarBackgroundStartPoint;

    // Use this for initialization
    void Start()
    {
        transform.position = BarBackgroundStartPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
