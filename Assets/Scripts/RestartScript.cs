using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class RestartScript : NetworkBehaviour { 
    public int TotalSpawnedObjects = 20;  // multiply 4 gameobjects
    /// 
    /// </summary>
    public GameObject Cube1;
    public GameObject Sphere1;
    public GameObject Capsule1;
    public GameObject Cylinder1;
    public GameObject Virus;

    public float randomMapSize = 15f;
    public float rs = 20f;
    public float ry = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //if (!isServer)
        //{
        //    return;
        //}

        int randomizer = 1; //Random.Range(1, 3);

        for (int i = 0; i < TotalSpawnedObjects; i++)
        {
           var c1 =   Instantiate(Cube1, GetRandomStartPosition1(randomMapSize*randomizer), Random.rotation);
           var s1 =  Instantiate(Sphere1, GetRandomStartPosition1(randomMapSize * randomizer), Random.rotation);
           var cp1 =  Instantiate(Capsule1, GetRandomStartPosition1(randomMapSize * randomizer), Random.rotation);
           var cy1 = Instantiate(Cylinder1,  GetRandomStartPosition1(randomMapSize * randomizer), Random.rotation);
           var vir = Instantiate(Virus, GetRandomStartPosition1(randomMapSize * randomizer), Random.rotation);


            NetworkServer.Spawn(c1);
            NetworkServer.Spawn(s1);
            NetworkServer.Spawn(cp1);
            NetworkServer.Spawn(cy1);
            NetworkServer.Spawn(vir);

        }


    }


    public Vector3 GetRandomStartPosition1(float randomStart)
    {
        float rX = Random.Range(-randomStart, randomStart);
        float rY = Random.Range(-randomStart, randomStart);//Random.Range(ry, rs);
        float rZ = Random.Range(-randomStart, randomStart);

        return new Vector3(rX, rY, rZ); 
    }

}
