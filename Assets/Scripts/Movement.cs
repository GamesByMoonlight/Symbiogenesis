using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    public Camera playerCam;
    Rigidbody rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        float translationVertical = Input.GetAxis("Vertical")*-1;
        translationVertical = translationVertical * speed;
        translationVertical *= Time.deltaTime;

        Vector3 cameraRelative = playerCam.transform.TransformDirection(0, 0, -1);

        Vector3 movementV = new Vector3((cameraRelative.x * translationVertical ),
            cameraRelative.y * translationVertical, (cameraRelative.z * translationVertical));

        rBody.MovePosition(transform.position + movementV );
    }
}
