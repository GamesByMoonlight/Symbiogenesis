using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float resetSpeed = 20f ;
    public float shiftSpeed = 50f;
    public float controlSpeed = 20f;
    public float horizontalSensitivity = 20f;
    public float resetHorizontalSensitivity = 20f;
    public float verticalSensitivity = 20f;
    public float resetVerticalSensitivity = 20f;

    private float pitch = 0f;
    private float yaw = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {

        MoveFunc();
    }

    // Update is called once per frame
    void Update()
    {



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
