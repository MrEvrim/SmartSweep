using UnityEngine;

public class DroneCont : MonoBehaviour
{
    public float moveSpeed = 0; 
    public float riseSpeed = 3f; 
    public float descendSpeed = 2f; 
    public float rotationSpeed = 100f; 
    public float maxRiseSpeed = 6f; 
    public float maxDescendSpeed = 4f; 
    public float maxAltitude = 20f; 
    public float maxMoveSpeed = 25f; 
    public float slowDownRate = 1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            moveSpeed -= slowDownRate * Time.deltaTime;
        }

        // Drone'u ileri ve geri hareket ettirme
        float forwardInput = Input.GetAxis("Vertical");
        moveSpeed += forwardInput * Time.deltaTime; 
        moveSpeed = Mathf.Clamp(moveSpeed, -maxMoveSpeed, maxMoveSpeed); 
        Vector3 moveDirection = transform.forward * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDirection);

        // Drone'u sağa ve sola döndürme
        float turnInput = Input.GetAxis("Horizontal");
        Quaternion turnRotation = Quaternion.Euler(0f, turnInput * rotationSpeed * Time.deltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);

        // Q tuşuna basıldığında yukarı hareket
        if (Input.GetKey(KeyCode.Q))
        {
            if (riseSpeed < maxRiseSpeed)
            {
                riseSpeed += Time.deltaTime;
            }
            rb.MovePosition(rb.position + Vector3.up * riseSpeed * Time.deltaTime);
        }
        else
        {
            // Yükselme hızını sıfırla istersen burada aşağı indirebilirsin.
            riseSpeed = 0f;
        }


        if (Input.GetKey(KeyCode.E))
        {
            if (descendSpeed < maxDescendSpeed)
            {
                descendSpeed += Time.deltaTime;
            }
            rb.MovePosition(rb.position + Vector3.down * descendSpeed * Time.deltaTime);
        }
        else
        {
            // Alçalma hızını sıfırla same
            descendSpeed = 0f;
        }

        if (transform.position.y > maxAltitude)
        {
            transform.position = new Vector3(transform.position.x, maxAltitude, transform.position.z);
        }
    }
}