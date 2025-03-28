using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrust = 10f;      // แรงขับเคลื่อน
    public float liftForce = 20f;   // แรงยกตัวขึ้น
    public float maxSpeed = 30f;   // ความเร็วสูงสุด
    public float maxTurn = 10f;   // ความเร็วสูงสุด
    public float turnSpeed = 10f;    // ความเร็วการหมุน
    public float rollSpeed = 1f;    // ความเร็วการหมุนตัว (เอียงซ้าย-ขวา)
    public Transform firePoint;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
        LimitSpeed();
        Raycast();
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
        // กด Spacebar เพื่อบินขึ้น (เพิ่มแรงยกตัว)
        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.AddForce(transform.up * -liftForce);
        }
    }

    void HandleRotation()
    {
        float turn = Input.GetAxis("Horizontal"); // ซ้าย-ขวา (A,D)
        float pitch = Input.GetAxis("Vertical");  // ขึ้น-ลง (W,S)

        // กำหนด angularVelocity ให้เครื่องบินหมุน
        Vector3 newAngularVelocity = rb.angularVelocity;

        // ถ้ามีการกด A หรือ D ให้เปลี่ยนทิศทางของเครื่องบินทันที
        if (turn != 0)
        {
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0, Space.World);
        }

        // จำกัดความเร็วในการหมุน (เลี้ยวซ้าย-ขวา)
        if (rb.angularVelocity.magnitude > maxSpeed)
        {
            rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, maxSpeed);
        }

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
    void Raycast()
    {
        Debug.DrawRay(firePoint.position, transform.forward * 30, Color.green);
    }


}
