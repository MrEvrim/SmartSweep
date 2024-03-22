using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class DroneCont : MonoBehaviour
{
    Rigidbody rb;
    float udAxis, fbAxis, rlAxis;
    float fbAngle = 0, rlAngle = 0;
    [SerializeField]
    float speed = 1.3f, angle = 25;
    bool isOnGround = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Controlls();
        transform.localEulerAngles = Vector3.back * rlAngle + Vector3.right * fbAngle;
    }
    private void FixedUpdate()
    {
        rb.AddRelativeForce(rlAxis, udAxis, fbAxis);
    }
    void Controlls()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            udAxis = 10 * speed;
            isOnGround = false;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            udAxis = 8;
            isOnGround = false;
        }
        else
            udAxis = 9.81f;

        if (Input.GetKey(KeyCode.W))
        {
            fbAngle = Mathf.Lerp(fbAngle, angle, Time.deltaTime);
            fbAxis = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            fbAngle = Mathf.Lerp(fbAngle, -angle, Time.deltaTime);
            fbAxis = -speed;
        }
        else
        {
            fbAngle = Mathf.Lerp(fbAngle, 0, Time.deltaTime);
            fbAxis = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rlAngle = Mathf.Lerp(rlAngle, angle, Time.deltaTime);
            rlAxis = speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rlAngle = Mathf.Lerp(rlAngle, -angle, Time.deltaTime);
            rlAxis = -speed;
        }
        else
        {
            rlAngle = Mathf.Lerp(rlAngle, 0, Time.deltaTime);
            rlAxis = 0;
        }

        if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.D)))
        {
            fbAngle = Mathf.Lerp(fbAngle, angle, Time.deltaTime);
            rlAngle = Mathf.Lerp(rlAngle, angle, Time.deltaTime);
            fbAxis = 0.5f * speed;
            rlAxis = 0.5f * speed;
        }

        if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.A)))
        {
            fbAngle = Mathf.Lerp(fbAngle, angle, Time.deltaTime);
            rlAngle = Mathf.Lerp(rlAngle, -angle, Time.deltaTime);
            fbAxis = 0.5f * speed;
            rlAxis = 0.5f * speed;
        }
        if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.D)))
        {
            fbAngle = Mathf.Lerp(fbAngle, -angle, Time.deltaTime);
            rlAngle = Mathf.Lerp(rlAngle, angle, Time.deltaTime);
            fbAxis = -0.5f * speed;
            rlAxis = -0.5f * speed;
        }
        if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.D)))
        {
            fbAngle = Mathf.Lerp(fbAngle, -angle, Time.deltaTime);
            rlAngle = Mathf.Lerp(rlAngle, -angle, Time.deltaTime);
            fbAxis = -0.5f * speed;
            rlAxis = -0.5f * speed;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
            isOnGround = true;
    }
}
