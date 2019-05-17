using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Flying : NetworkBehaviour
{
    public float movementSpeed = 5f;
    public float resetSpeed = 5f ;
    public float shiftSpeed = 5f;
    public float controlSpeed = 10f;
    public float horizontalSensitivity = 1f;
    public float resetHorizontalSensitivity = 1f;
    public float verticalSensitivity = 1f;
    public float resetVerticalSensitivity = 1f;

    private float pitch = 0f;
    private float yaw = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            MoveFunc();
        }



    }

    public void MoveFunc()
    {

        yaw += horizontalSensitivity * Input.GetAxis("Mouse X");
       pitch -= verticalSensitivity * Input.GetAxis("Mouse Y");

        //yaw += horizontalSensitivity + Input.GetAxisRaw("Mouse X");
        //pitch += verticalSensitivity + Input.GetAxisRaw("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = shiftSpeed;
        }
        else
        {
            movementSpeed = resetSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * Time.deltaTime * controlSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * Time.deltaTime * controlSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += -transform.forward * Time.deltaTime * controlSpeed;
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * Time.deltaTime * controlSpeed;
        }

    }


}
