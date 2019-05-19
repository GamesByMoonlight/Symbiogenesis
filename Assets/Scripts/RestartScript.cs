using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class RestartScript : NetworkBehaviour { 
    public int TotalSpawnedObjects =20;
    public GameObject Cube1;
    public GameObject Sphere1;
    public GameObject Capsule1;
    public GameObject Cylinder1;

    float randomMapSize = 200f;
    float rs = 200f;
    float ry = 3f;


    // Start is called before the first frame update
    void Start()
    {
        //if (!isServer)
        //{ return; }

        for (int i = 0; i < TotalSpawnedObjects; i++)
        {
           var c1 =   Instantiate(Cube1, GetRandomStartPosition1(randomMapSize), Quaternion.identity);
           var s1 =  Instantiate(Sphere1, GetRandomStartPosition1(randomMapSize), Quaternion.identity);
           var cp1 =  Instantiate(Capsule1, GetRandomStartPosition1(randomMapSize), Quaternion.identity);
           var cy1 = Instantiate(Cylinder1,  GetRandomStartPosition1(randomMapSize), Quaternion.identity);

            NetworkServer.Spawn(c1);
            NetworkServer.Spawn(s1);
            NetworkServer.Spawn(cp1);
            NetworkServer.Spawn(cy1);


        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public Vector3 GetRandomStartPosition1(float randomStart)
    {
        float rX = Random.Range(-randomStart, randomStart);
        float rY = Random.Range(1, 20);
        float rZ = Random.Range(-randomStart, randomStart);

        return new Vector3(rX, rY, rZ); 
    }

}
