using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleScript : MonoBehaviour
{
    float randomMapSize = 50;
    float testMapStart = 2;

    public float resetScalesize = 1f;

    /// <summary>
    ///  scale 50 plane start transform position -250 to 250
    /// </summary>

    Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
       // trans.position = GetRandomStartPosition(testMapStart);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (trans.localScale.x > collision.collider.transform.localScale.x)
        {
            trans.localScale += collision.collider.transform.localScale;
        }
        else
        {
            // start over game over
            //trans.localScale = new Vector3(1, 1, 1);
            trans.localScale = new Vector3(resetScalesize,resetScalesize ,resetScalesize );
            //trans.position = new Vector3(rX, rY, rZ);
            trans.position = GetRandomStartPosition(randomMapSize);
        }

    }

    public Vector3 GetRandomStartPosition(float randomStart)
    {
        float rX = Random.Range(-randomStart, randomStart);
        float rY = Random.Range(0, 2);
        float rZ = Random.Range(-randomStart, randomStart);

        return new Vector3(rX, rY, rZ);

    }


}
