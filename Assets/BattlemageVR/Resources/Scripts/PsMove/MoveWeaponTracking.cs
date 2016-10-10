using UnityEngine;
using System.Collections;

public class MoveWeaponTracking : MonoBehaviour
{
    public GameObject Handle;
    GameObject Player;
    GameObject OvrRig;
    GameObject BasePlayer;

    bool isMirror = false;

    float playerX;
    float playerY;
    float playerZ;

    float yOffsetGem;
    float yOffsetHandle;

    public float zOffset;
    public float yOffset;

    Quaternion temp = new Quaternion(0, 0, 0, 0);

    bool moveControllerOn = false;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        OvrRig = Player.transform.FindChild("LMHeadMountedRig").gameObject;
        BasePlayer = Player.transform.FindChild("BasePlayer").gameObject;
        Handle = transform.FindChild("Handle").gameObject;
        playerX = BasePlayer.transform.position.x;
        playerY = BasePlayer.transform.position.y;
        playerZ = BasePlayer.transform.position.z;
    }

    void FixedUpdate()
    {
        if (PSMoveInput.IsConnected && PSMoveInput.MoveControllers[0].Connected)
        {
            if (moveControllerOn == false)
            {
                
                zOffset = PSMoveInput.MoveControllers[0].Data.Position.z + playerZ + 3.0f;
                yOffsetGem = PSMoveInput.MoveControllers[0].Data.Position.y - playerY;
                yOffsetHandle = PSMoveInput.MoveControllers[0].Data.HandlePosition.y - playerY;
                moveControllerOn = true;
            }
            Vector3 gemPos, handlePos;
            MoveData moveData = PSMoveInput.MoveControllers[0].Data;

            gemPos = new Vector3(playerX + moveData.Position.x, (moveData.Position.y - yOffsetGem) + yOffset, moveData.Position.z);
            handlePos = new Vector3(playerX + moveData.HandlePosition.x, (moveData.HandlePosition.y - yOffsetHandle) + yOffset, moveData.HandlePosition.z);

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
        else
        {
            moveControllerOn = false;
        }
    }
}
