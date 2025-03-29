using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrust = 10f;
    public float liftForce = 20f;
    public float maxSpeed = 30f;
    public float maxTurn = 10f;
    public float turnSpeed = 10f;  
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
        
        if (Input.GetKey(KeyCode.W))
        {
          rb.AddForce(transform.forward * thrust);
        }
        if (Input.GetKey(KeyCode.S))
        {
          rb.AddForce(transform.forward * -thrust);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * liftForce);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.AddForce(transform.up * -liftForce);
        }
    }

    void HandleRotation()
    {
        float turn = Input.GetAxis("Horizontal");
        float pitch = Input.GetAxis("Vertical");

        Vector3 newAngularVelocity = rb.angularVelocity;

      
        if (turn != 0)
        {
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0, Space.World);
        }

        if (rb.angularVelocity.magnitude > maxSpeed)
        {
            rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, maxSpeed);
        }

        rb.angularVelocity = newAngularVelocity;
    }

    void LimitSpeed()
    {
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
