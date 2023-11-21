using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    private bool isCollider;
    private float temp2;
    public int cnt = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollider)
        {
            temp2 += Time.deltaTime;
        }
        if (temp2 >= 0.4f)
        {
            //Debug.Log("collider false!");
            SerialPortScript.Instance.SendStopSignal();
            Debug.Log("stop signal");
            temp2 = 0;
            isCollider = false;
            cnt = 2;
        }

        if(PhotonManager.Instance != null)
            PhotonManager.Instance.count = cnt;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {/*
            ContactPoint contact = collision.contacts[0];
            Vector3 normal = contact.normal;
            Vector3 position = contact.point;

            float relativeVelocity = collision.relativeVelocity.magnitude;
            float mass = GetComponent<Rigidbody>().mass;
            float impulse = relativeVelocity * GetComponent<Rigidbody>().mass;
            Vector3 acceleration = (relativeVelocity / Time.fixedDeltaTime) * normal / mass;
            Debug.Log("Collision Detected! Normal: " + normal + " Point: " + position + " Relative Velocity: " + relativeVelocity + " Acceleration: " + acceleration);
            Debug.Log("Collision Detected! Relative Velocity: " + relativeVelocity + " Impulse: " + impulse);*/
            isCollider = true;
            SerialPortScript.Instance.SendSignal();
            Debug.Log("collider!");
            cnt = 1;
        }

    }
}
