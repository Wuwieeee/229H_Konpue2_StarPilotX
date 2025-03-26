using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrust = 30f;      // แรงขับเคลื่อน
    public float liftForce = 20f;   // แรงยกตัวขึ้น
    public float maxSpeed = 100f;   // ความเร็วสูงสุด
    public float turnSpeed = 2f;    // ความเร็วการหมุน
    public float rollSpeed = 2f;    // ความเร็วการหมุนตัว (เอียงซ้าย-ขวา)

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
        LimitSpeed();
    }

    void HandleMovement()
    {
        // กด W เพื่อเร่งเครื่องบินไปข้างหน้า
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * thrust);
        }

        // กด Spacebar เพื่อบินขึ้น (เพิ่มแรงยกตัว)
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * liftForce);
        }
    }

    void HandleRotation()
    {
        float roll = Input.GetAxis("Horizontal"); // ซ้าย-ขวา (A,D)
        float pitch = Input.GetAxis("Vertical");  // ขึ้น-ลง (W,S)

        // กำหนด angularVelocity ให้เครื่องบินหมุน
        Vector3 newAngularVelocity = rb.angularVelocity;

        newAngularVelocity.x = pitch * turnSpeed; // ก้ม-เงย
        newAngularVelocity.y = roll * turnSpeed;  // เลี้ยวซ้าย-ขวา
        newAngularVelocity.z = -roll * rollSpeed; // เอียงตัวเมื่อเลี้ยว

        rb.angularVelocity = newAngularVelocity;
    }

    void LimitSpeed()
    {
        // จำกัดความเร็วสูงสุด
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
    }
}
