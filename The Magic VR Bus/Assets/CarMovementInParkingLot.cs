using UnityEngine;

public class CarMovementInParkingLot : MonoBehaviour
{
    // Reference the objects Rigidbody component
    public Rigidbody _rb;

    // Variable to control the forward speed (should be slow in the parking lot)
    public float forwardSpeed = 5f;

    // Variable to save the original position
    private Vector3 originalPosition;

    // Use for initialization
    void Start()
    {
        // Get the original position
        originalPosition = transform.position;
    }

    // FixedUpdate is preferred for handling physics
    void FixedUpdate()
    {
        // Start the car moving
        // _rb.AddForce(forwardSpeed * Time.deltaTime, 0, 0);
        _rb.velocity = new Vector3(forwardSpeed , 0, 0);

        // Return to the original position so the car keeps looping
        if(transform.position.x > 19)
        {
            transform.position = originalPosition;
        }
    }
}
