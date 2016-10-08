﻿using UnityEngine;
using System.Collections;

public class MoveWeaponTracking : MonoBehaviour
{
    //public GameObject Ball;
    public GameObject Handle;

    bool isMirror = false;

    float zOffset = 5.0f;
    Quaternion temp = new Quaternion(0, 0, 0, 0);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (PSMoveInput.IsConnected && PSMoveInput.MoveControllers[0].Connected)
        {

            Vector3 gemPos, handlePos;
            MoveData moveData = PSMoveInput.MoveControllers[0].Data;
            gemPos = moveData.Position;
            handlePos = moveData.HandlePosition;
            if (isMirror)
            {
                transform.localPosition = Handle.transform.localPosition = handlePos;
                transform.localRotation = Handle.transform.localRotation = Quaternion.Euler(moveData.Orientation);
            }
            else
            {
                gemPos.z = -gemPos.z + zOffset;
                handlePos.z = -handlePos.z + zOffset;
                transform.localPosition = Handle.transform.localPosition = handlePos;
                transform.localRotation = Handle.transform.localRotation = Quaternion.LookRotation(gemPos - handlePos);
                Handle.transform.Rotate(new Vector3(0, 0, moveData.Orientation.z));
                transform.Rotate(new Vector3(0, 0, moveData.Orientation.z));

                /* using quaternion rotation directly
                 * the rotations on the x and y axes are inverted - i.e. left shows up as right, and right shows up as left. This code fixes this in case 
                 * the object you are using is facing away from the screen. Comment out this code if you do want an inversion along these axes
                 * 
                 * Add by Karthik Krishnamurthy*/

                temp = moveData.QOrientation;
                temp.x = -moveData.QOrientation.x;
                temp.y = -moveData.QOrientation.y;
                Handle.transform.localRotation = temp;
                transform.localRotation = temp;

                transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f));
                transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
            }
        }
    }
}
