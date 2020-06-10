using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Eject : MonoBehaviour
{

    public Rigidbody bulletCasing;
    int ejectSpeed = 2;

    Rigidbody clone;

    public float speed = 100f;

    Vector3 pos = new Vector3(0.01f, 0.08f, 0.18f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clone = Instantiate(bulletCasing, transform.position, Quaternion.Euler(90, 0, 90));
            clone.velocity = transform.TransformDirection(Vector3.up * Random.Range(ejectSpeed, 3));
        }
    }
}
