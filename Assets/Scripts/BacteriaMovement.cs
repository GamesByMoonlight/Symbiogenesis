using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaMovement : MonoBehaviour
{

    public float randomWaitTime = 1f;
    public Rigidbody rig;

    public float speed = 0f;
    public Vector3 newMovement;

   void Awake ()
    {
        rig = GetComponent<Rigidbody>();
    }

    public IEnumerator Start()
    {
        randomWaitTime = Random.Range(4f, 5f);

        speed = Random.Range(1f, 2f);
        
        yield return new WaitForSeconds(randomWaitTime);
       
        StartCoroutine(Start());
    }
    void FixedUpdate()
    {
        Movement();
    }

    public void Movement ()
    {
        newMovement = new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * speed * Time.deltaTime;
        //rig.MovePosition(transform.position + newMovement);
        rig.AddForce(newMovement, ForceMode.Impulse);
    }


}
