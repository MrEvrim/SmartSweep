using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MoveSon : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float rotationSpeed = 75.0f;
    public float brushSpeed = 1000f;
    public GameObject lWheel;
    public GameObject rWheel;
    public GameObject brush1;
    public GameObject brush2;

    public float wheelRotationSpeed = 200f;

    private Rigidbody rb;
    private float moveInput;
    private float rotationInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

        RotateWheels(moveInput, rotationInput);
    }
    void FixedUpdate()
    {
        MoveSonObj(moveInput);
        RotateSonObj(rotationInput);
    }
    void MoveSonObj(float input)
    {
        Vector3 moveDiriction = transform.forward * input * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDiriction);
    }
    void RotateSonObj(float input)
    {
        float rotation = input * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
    void RotateWheels(float moveInput, float rotationInput)
    {
        float wheelRotation = moveInput * wheelRotationSpeed * Time.deltaTime;
        //wheel dönme
        lWheel.transform.Rotate(0f, 0f, wheelRotation - rotationInput * wheelRotationSpeed * Time.deltaTime);
        rWheel.transform.Rotate(0f, 0f, wheelRotation + rotationInput * wheelRotationSpeed * Time.deltaTime);
        brush1.transform.Rotate(-brushSpeed * Time.deltaTime, 0f, 0f);
        brush2.transform.Rotate(brushSpeed * Time.deltaTime, 0f, 0f);
    }
}
