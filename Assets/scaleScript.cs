using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleScript : MonoBehaviour
{
   
    Transform trans;


    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (trans.localScale.x > collision.collider.transform.localScale.x)
        {
            trans.localScale += collision.collider.transform.localScale;

        }

        trans.localScale += collision.collider.transform.localScale;

    }

}
