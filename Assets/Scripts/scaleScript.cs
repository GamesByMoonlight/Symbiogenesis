using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class scaleScript : NetworkBehaviour
{
    float randomMapSize = 50;
    float testMapStart = 2;

    public float resetScalesize = 1f;
    public float resetScaleSizePlayer = 1.5f;

    /// <summary>
    ///  scale 50 plane start transform position -250 to 250
    /// </summary>

    Transform trans;

    public SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        trans = GetComponent<Transform>();
       // trans.position = GetRandomStartPosition(testMapStart);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (this.tag == "Virus")
        {
            return;
        }

        if ( collision.collider.tag=="Virus")
        {
            if (soundManager != null)
             soundManager.ShrinkingSound(GetComponent<AudioSource>());

            trans.localScale = new Vector3(resetScaleSizePlayer, resetScaleSizePlayer, resetScaleSizePlayer);
            trans.position = GetRandomStartPosition(randomMapSize);
            return;

        }


        if (this.tag == "Food")
        {
            trans.localScale = new Vector3(resetScalesize, resetScalesize, resetScalesize);
            trans.position = GetRandomStartPosition(randomMapSize);


            collision.collider.transform.localScale += new Vector3(.1f, .1f, .1f);

            return;



        }
        if (collision.collider.tag == "Food")
        {
            trans.localScale += new Vector3(.1f, .1f, .1f);

            if (soundManager != null)
                soundManager.GrowthSound(GetComponent<AudioSource>());
            collision.collider.transform.localScale = new Vector3( resetScalesize,resetScalesize, resetScalesize);
            collision.collider.transform.position = GetRandomStartPosition(randomMapSize);

            return;

        }

        if(!isLocalPlayer)
        {
            return;
        }

            if (trans.localScale.x > collision.collider.transform.localScale.x)
        {
            PlayerSizeGrow = true;
            return;
        }
        else
        {
            PlayerSizeReset = true;
            return;
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        PlayerSizeGrow = false;
        PlayerSizeReset = false;

    }

    private void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        if(PlayerSizeGrow)
        {
            trans.localScale += new Vector3(.1f, .1f, .1f);
        }
        if(PlayerSizeReset)
        {
               trans.localScale = new Vector3(resetScaleSizePlayer, resetScaleSizePlayer, resetScaleSizePlayer);
               trans.position = GetRandomStartPosition(randomMapSize);

            CmdGrowPlayer();
            RpcPlayerReset();
        }

    }

    [Command]
    public void CmdPlayerReset()
    {
        trans.localScale = new Vector3(resetScaleSizePlayer, resetScaleSizePlayer, resetScaleSizePlayer);
        trans.position = GetRandomStartPosition(randomMapSize);


    }

    [ClientRpc]
    public void RpcPlayerReset()
    {
        trans.localScale = new Vector3(resetScaleSizePlayer, resetScaleSizePlayer, resetScaleSizePlayer);
        trans.position = GetRandomStartPosition(randomMapSize);


    }

    [Command]
    public void CmdGrowPlayer()
    {

    }


    public bool PlayerSizeReset = false;
    public bool PlayerSizeGrow = false;


    public Vector3 GetRandomStartPosition(float randomStart)
    {
        float rX = Random.Range(-randomStart, randomStart);
        float rY = Random.Range(0, 200);
        float rZ = Random.Range(-randomStart, randomStart);

        return new Vector3(rX, rY, rZ);

    }


}
