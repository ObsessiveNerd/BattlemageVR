using UnityEngine;
using System.Collections;

public class MoveConnect : MonoBehaviour
{
    public string IpAddress;
    public int Port;

    // Use this for initialization
    void Start()
    {
        PSMoveInput.Connect(IpAddress, Port);
    }
}
