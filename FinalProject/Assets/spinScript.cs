using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class spinScript : MonoBehaviour
{

    Vector3 Speed = new Vector3(5f, 5f, 5f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.deltaTime;
        float x = Random.Range(0, 10);

        if(x > 8)
        {
            transform.Rotate(Speed.x * t, Speed.y, Speed.z);
        }
        else if(x > 6)
        {
            transform.Rotate(Speed.x, Speed.y * t, Speed.z);
        }
        else if(x > 4)
        {
            transform.Rotate(Speed.x, Speed.y, Speed.z * t);
        }
        else if (x > 2)
        {
            transform.Rotate(Speed.x * t, Speed.y * t, Speed.z);
        }
        else
        {
            transform.Rotate(Speed.x, Speed.y * t, Speed.z * t);
        }
        
    }
}
