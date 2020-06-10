using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class GunController : MonoBehaviour
{
    Animator m_animator;
    
    public GameObject mainBullet;
    public float speed = 200f;

    public float slowdownFactor = 0.4f;

    public int power = 10;

    [Header("Reference Points:")]
    public Transform recoilPosition;
    public Transform rotationPoint;

    [Header("Speed Settings:")]
    public float positionalRecoilSpeed = 8f;
    public float rotationalRecoilSpeed = 8f;

    public float positionalReturnSpeed = 18f;
    public float rotationalReturnSpeed = 38f;

    [Header("Amount Settings:")]
    public Vector3 RecoilRotation = new Vector3(10, 0, 0);
    public Vector3 RecoilKickBack = new Vector3(1f, 0f, -0f);

    Vector3 rotationalRecoil;
    Vector3 positionalRecoil;
    Vector3 overallRotation;
    
    int alt = 0;

    void FixedUpdate()
    {
        rotationalRecoil = Vector3.Lerp(rotationalRecoil, Vector3.zero, rotationalReturnSpeed * Time.deltaTime);
        positionalRecoil = Vector3.Lerp(positionalRecoil, Vector3.zero, positionalReturnSpeed * Time.deltaTime);

        recoilPosition.localPosition = Vector3.Slerp(recoilPosition.localPosition, positionalRecoil, positionalRecoilSpeed * Time.fixedDeltaTime);
        overallRotation = Vector3.Slerp(overallRotation, rotationalRecoil, rotationalRecoilSpeed * Time.fixedDeltaTime);
        rotationPoint.localRotation = Quaternion.Euler(overallRotation);
    }

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetMouseButtonDown(0))
        {
            m_animator.SetTrigger("Shoot");
            Bullet();
            kickBack();
        }

        if (Input.GetKeyDown("space"))
        {
            if (alt == 0)
            {
                slowTime();
                alt = 1;
            } 
            else if (alt == 1)
            {
                normalTime();
                alt = 0;
            }
            
        }
    }

    void Bullet()
    {
        float angle = 90;
        float rotation = 90;
        GameObject instBullet = Instantiate(mainBullet, transform.position, Quaternion.identity) as GameObject;
        instBullet.transform.position = new Vector3(3.2f, 1.564f, -0.7952048f);
        instBullet.transform.rotation = Quaternion.Euler(angle, 0 , rotation);
        Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
        instBulletRigidbody.AddForce(Vector3.left * speed);

    }

    void kickBack()
    {
        rotationalRecoil += new Vector3(RecoilRotation.x, 0, 0);
        positionalRecoil += new Vector3(RecoilKickBack.x, 0, 0);
    }

    void slowTime()
    {
        Time.timeScale = slowdownFactor;
    }

    void normalTime()
    {
        Time.timeScale = 1f;
    }
}