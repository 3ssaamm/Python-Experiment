using UnityEngine;

public class thruster : MonoBehaviour
{
    public float thrust = 1.0f;
    public Vector3 rotationAngles = new Vector3(45, 30, 60); // rotation angles in X, Y and Z direction

    // Positive direction vectors
    public Vector3 rightDirection = Vector3.right;
    public Vector3 upDirection = Vector3.up;
    public Vector3 forwardDirection = Vector3.forward;

    // Negative direction vectors
    public Vector3 leftDirection = -Vector3.right;
    public Vector3 downDirection = -Vector3.up;
    public Vector3 backwardDirection = -Vector3.forward;

    private Rigidbody Rb;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Create rotation quaternion from Euler angles
        Quaternion rotation = Quaternion.Euler(rotationAngles);

        // Apply rotated impulses along the X, Y, and Z axes in local space
        Rb.AddForce(transform.TransformDirection(rotation * rightDirection) * thrust);
        Rb.AddForce(transform.TransformDirection(rotation * leftDirection) * thrust);
        Rb.AddForce(transform.TransformDirection(rotation * upDirection) * thrust);
        Rb.AddForce(transform.TransformDirection(rotation * downDirection) * thrust);
        Rb.AddForce(transform.TransformDirection(rotation * forwardDirection) * thrust);
        Rb.AddForce(transform.TransformDirection(rotation * backwardDirection) * thrust);
    }

    void Update()
    {
        // Create rotation quaternion from Euler angles
        Quaternion rotation = Quaternion.Euler(rotationAngles);

        // Draw rays in the Scene view to visualize the rotated impulses
        Debug.DrawRay(transform.position, transform.TransformDirection(rotation * rightDirection) * thrust, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(rotation * leftDirection) * thrust, Color.blue);
        Debug.DrawRay(transform.position, transform.TransformDirection(rotation * upDirection) * thrust, Color.green);
        Debug.DrawRay(transform.position, transform.TransformDirection(rotation * downDirection) * thrust, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(rotation * forwardDirection) * thrust, Color.magenta);
        Debug.DrawRay(transform.position, transform.TransformDirection(rotation * backwardDirection) * thrust, Color.cyan);
    }
}
