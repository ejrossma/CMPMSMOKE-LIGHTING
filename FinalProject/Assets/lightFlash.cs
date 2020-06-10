using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlash : MonoBehaviour
{
    private Light myLight;


    void Start()
    {
        myLight = GetComponent<Light>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myLight.enabled = true;
        } else
        {
            myLight.enabled = false;
        }
    }
}
