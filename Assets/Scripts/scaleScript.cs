using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleScript : MonoBehaviour
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
        }
        if (collision.collider.tag == "Food")
        {
            if (soundManager != null)
                soundManager.GrowthSound(GetComponent<AudioSource>());
            collision.collider.transform.localScale = new Vector3( resetScalesize,resetScalesize, resetScalesize);
            collision.collider.transform.position = GetRandomStartPosition(randomMapSize);

        }



        if (trans.localScale.x > collision.collider.transform.localScale.x)
        {
            // this grows
            trans.localScale += collision.collider.transform.localScale;

            //collider gets reset
            if(collision.collider.tag=="Player")
            {
                collision.collider.transform.localScale = new Vector3(resetScaleSizePlayer, resetScaleSizePlayer, resetScaleSizePlayer);
                collision.collider.transform.position = GetRandomStartPosition(randomMapSize);
            }

        }
        else
        {
            // collider growss
            // grow collider first because size changes...
            collision.collider.transform.localScale += trans.localScale;


            // this gets reset
            trans.localScale = new Vector3(resetScalesize,resetScalesize ,resetScalesize );
            trans.position = GetRandomStartPosition(randomMapSize);


        }



    }

 

    public Vector3 GetRandomStartPosition(float randomStart)
    {
        float rX = Random.Range(-randomStart, randomStart);
        float rY = Random.Range(0, 20);
        float rZ = Random.Range(-randomStart, randomStart);

        return new Vector3(rX, rY, rZ);

    }


}
