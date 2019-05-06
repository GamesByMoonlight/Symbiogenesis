using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScript : MonoBehaviour
{
    public int TotalSpawnedObjects =200;
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
        for (int i = 0; i < TotalSpawnedObjects; i++)
        {
            Instantiate(Cube1, GetRandomStartPosition1(randomMapSize), Quaternion.identity);
            Instantiate(Sphere1, GetRandomStartPosition1(randomMapSize), Quaternion.identity);
            Instantiate(Capsule1, GetRandomStartPosition1(randomMapSize), Quaternion.identity);
            Instantiate(Cylinder1,  GetRandomStartPosition1(randomMapSize), Quaternion.identity);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public Vector3 GetRandomStartPosition1(float randomStart)
    {
        float rX = Random.Range(-randomStart, randomStart);
        float rY = Random.Range(1, 5);
        float rZ = Random.Range(-randomStart, randomStart);

        return new Vector3(rX, rY, rZ); 
    }

}
