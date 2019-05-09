using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : NetworkBehaviour
{

    [SerializeField]
    private float speed = 2000f;
    [SerializeField]
    private float lookSensitivity =5 ;

    private PlayerMotor motor;

    [SyncVar]
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hasAuthority == true)
        {
            int i = 0;
        }
        else
        {
            
            return;
        }


        //calculate movement  volocity as a 3d vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;    // (1,0,0) 
        Vector3 _movVertical = transform.forward * _zMov;    // (0,0,1)

        //final movement vector
         Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        // apply motor
        motor.Move(_velocity);

        // calculate rotation as 3d vector

        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;
        // apply rotation
        motor.Rotate(_rotation);

        // calculate rotation as 3d vector

        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;
        // apply rotation
        motor.RotateCamera(_cameraRotation);

        /// calculate thrust

        if(Input.GetButton("Fire1"))
        {
            motor.addForce = true;
        }

    }
}
