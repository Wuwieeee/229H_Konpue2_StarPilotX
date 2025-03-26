using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float engineThrust = 40;
    public float reverseThrust = 25f;
    public float liftForce = 0.5f;
    public float drag = 0.03f;
    public float angularDrag = 0.03f;

    public float yawPower = 60f;
    public float pitchPower = 30f;
    public float rollPower = 20f;



    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = drag;
        rb.angularDamping = angularDrag;

    }

    void FixedUpdate()
    {
        HandleThrust();    // ควบคุมการเร่งความเร็ว
        HandleLift();      // จำลองแรงยกของเครื่องบิน
        HandleControls();  // ควบคุมการเลี้ยวและการหมุน
    }

    void HandleThrust()
    {
        float thrustInput = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            thrustInput = engineThrust; // กด W ไปข้างหน้า
        }
        else if (Input.GetKey(KeyCode.S))
        {
            thrustInput = -reverseThrust; // กด S ถอยหลัง (ช้ากว่าไปหน้า)
        }

        rb.AddForce(transform.forward * thrustInput, ForceMode.Force);
    }

    void HandleLift()
    {
        float effectiveLift = rb.linearVelocity.magnitude * liftForce;
        rb.AddForce(Vector3.up * effectiveLift, ForceMode.Force);
    }

    void HandleControls()
    {
        float yaw = 0f;
        float pitch = Input.GetAxis("Vertical") * pitchPower * Time.deltaTime;
        float roll = 0f;

        // Yaw (เลี้ยวซ้ายขวา)
        if (Input.GetKey(KeyCode.A)) yaw = -yawPower; // เลี้ยวซ้าย
        if (Input.GetKey(KeyCode.D)) yaw = yawPower;  // เลี้ยวขวา

        // Roll (เอียงปีก)
        if (Input.GetKey(KeyCode.Q)) roll = rollPower * Time.deltaTime;
        if (Input.GetKey(KeyCode.E)) roll = -rollPower * Time.deltaTime;

        // เพิ่มแรงบิดให้เครื่องบินหมุนตามแกนต่างๆ
        rb.AddTorque(transform.up * yaw, ForceMode.Force);       // หมุนซ้าย-ขวา
        rb.AddTorque(transform.right * pitch, ForceMode.Force);  // เงย/กดหัว
        rb.AddTorque(transform.forward * roll, ForceMode.Force); // เอียงปีก
    }

}
