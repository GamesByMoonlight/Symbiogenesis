using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNameScript : NetworkBehaviour
{
    [SyncVar]
    public string pname = "Player";

    public void OnGUI()
    {
        //if (isLocalPlayer)
       // {
            pname = GUI.TextField(new Rect(25, Screen.height - 40, 100, 30), pname);
            if (GUI.Button(new Rect(130, Screen.height - 40, 80, 30), "Change"))
            {
                CmdChangeName(pname);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            //            GetComponent<drive>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isLocalPlayer)
        {
            float scaleSize = this.transform.localScale.x * 100;
            int scaleSizeInt = (int)scaleSize;
            this.GetComponentInChildren<TextMesh>().text = $"{pname} {scaleSizeInt.ToString()} ";

        }
        else
        {
            this.GetComponentInChildren<TextMesh>().text = $"{pname}";
        }



        CmdChangeName(pname);

    }


    [Command]
    public void CmdChangeName(string newName)
    {
        pname = newName;
    }

}
