using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CursorUnlockFalse();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape) )
        {
            CursorUnlock();
        }

        if (Input.GetKey(KeyCode.X))
        {
            CursorUnlock();

        }

        if(Input.GetKey(KeyCode.L))
        {
            CursorUnlockFalse();
        }
        if (Input.GetKey(KeyCode.U))
        {
            CursorUnlock();
        }

        if (Input.GetMouseButtonDown(0))
        {
            CursorUnlock();
        }

        if (Input.GetMouseButtonDown(1))
        {
            CursorUnlockFalse();
        }
        if (Input.GetMouseButtonDown(2))
        {
            CursorUnlock();
        }


    }

    public void CursorUnlockFalse()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }



    public void CursorUnlock()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }




}
