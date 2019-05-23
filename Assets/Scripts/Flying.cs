using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Flying : NetworkBehaviour
{

    public GameObject playerCamera;

    public float movementSpeed = 10f;
    public float resetSpeed = 10f ;
    public float shiftSpeed = 50f;
    public float controlSpeed = 20f;
    public float horizontalSensitivity = .5f;
    public float resetHorizontalSensitivity = .5f;
    public float verticalSensitivity = .5f;
    public float resetVerticalSensitivity = .5f;

    private float pitch = 0f;
    private float yaw = 0f;


    private void Start()
    {
        if (isLocalPlayer == true)
        {

            //playerCamera.SetActive = true;
        }
        else
        {
            //playerCamera.SetActive = false;
        }

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
