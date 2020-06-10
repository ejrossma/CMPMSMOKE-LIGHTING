using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeAnimation : MonoBehaviour
{
    ParticleSystem smoke;
    // Start is called before the first frame update
    void Start()
    {
        smoke = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            smoke.Play();
    }
}
