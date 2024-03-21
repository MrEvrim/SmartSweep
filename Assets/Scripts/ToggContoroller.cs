using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggContoroller : MonoBehaviour
{
    public float MoveSpeed = 50;
    public float MaxSpeed = 14;
    public float Drag = 0.91f;
    public float Traction = 3f;
    public float SteerAngle = 20f;
    public GameObject whell1;
    public GameObject whell2;
    public GameObject[] tekerler;
    public AudioSource drift;
    public AudioSource engine;

    private float rotasyonHizi;
    private Vector3 MoveForce;
    private float originalPitch;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        originalPitch = drift.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        rotasyonHizi = MoveForce.z * 100;

        //tekerDondur
        foreach (GameObject teker in tekerler)
        {
            teker.transform.Rotate(Vector3.right * Time.deltaTime * rotasyonHizi);
        }

        //hareket
        MoveForce += transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        //dönme
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        //Sürtünme
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        //motor ses
        engine.pitch = originalPitch + MoveForce.magnitude * 0.3f;

        //Particle System for tire tracks
        if (Input.GetKey("space"))
        {
            MoveSpeed = 0;
            MaxSpeed -= 0.8f;
            Drag = 1f;
            drift.mute = false;
        }
        else
        {
            MaxSpeed = 95;
            MoveSpeed = 30;
            Drag = 0.97f;
            drift.mute = true;
        }
    }
}