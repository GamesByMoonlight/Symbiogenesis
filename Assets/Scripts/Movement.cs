using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour
{
    public float speed = 5;
    public GameObject playerCamObject;
    public Camera playerCam;
    Rigidbody rBody;

    void Start()
    {
        //Debug.Log("HI");
        //Debug.Log(isLocalPlayer);

        if (isLocalPlayer == true)
        {

            playerCamObject.SetActive(true);
        }
        else
        {
            playerCamObject.SetActive(false);
        }

        rBody = GetComponent<Rigidbody>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    public void MoveFunction()
    {
        //Debug.Log("Inside moveFunction");
        //Debug.Log(isLocalPlayer);

        float translationVertical = Input.GetAxis("Vertical") * -1;

        translationVertical = translationVertical * speed;
        translationVertical *= Time.deltaTime;

        Vector3 cameraRelative = playerCam.transform.TransformDirection(0, 0, -1);

        Vector3 movementV = new Vector3((cameraRelative.x * translationVertical),
            cameraRelative.y * translationVertical, (cameraRelative.z * translationVertical));

        rBody.MovePosition(transform.position + movementV);
    }

    void FixedUpdate()
    {
        //Debug.Log("Hello inside Update");
        //Debug.Log(isLocalPlayer);

        if (isLocalPlayer == true)
        {
            MoveFunction();
        }

        //Debug.Log("end of update");
        //Debug.Log(isLocalPlayer);
    }


}
