using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeConeAnimation : MonoBehaviour
{
    ParticleSystem smokeCone;
    // Start is called before the first frame update
    void Start()
    {
        smokeCone = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            smokeCone.Play();
    }
}
