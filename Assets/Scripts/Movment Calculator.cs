using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentCalculator : MonoBehaviour
{
    public Transform target; // The object to track
    public float updateFrequency = 1.0f; // How often to update the calculations (in seconds)

    public Vector3 displacement; // The object's displacement
    private Vector3 previousPosition; // The object's position in the previous frame
    private Vector3 currentPosition; // The object's position in the current frame
    public Vector3 velocity; // The object's velocity
    public Vector3 acceleration; // The object's acceleration
    private Vector3 previousVelocity; // The object's velocity in the previous frame
    public float timer; // The timer


    void Start()
    {
        // Initialize the previous position and velocity to the current position and velocity
        previousPosition = target.position;
        previousVelocity = velocity;
    }

    int counter = 0;

    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if it's time to update the calculations
        if (timer >= updateFrequency)
        {
            // Update the current position
            currentPosition = target.position;

            // Calculate the velocity
            velocity = (currentPosition - previousPosition) / updateFrequency;

            // Calculate the acceleration
            acceleration = (velocity - previousVelocity) / updateFrequency;

            // Calculate the displacement
            displacement += currentPosition - previousPosition;

            // Update the previous position and velocity
            previousPosition = currentPosition;
            previousVelocity = velocity;

            // Reset the timer
            timer = 0.0f;

            // Increment the counter
            counter++;

            // Display the results in the inspector
            Debug.Log("[" + counter + "] Displacement: " + displacement); 
            Debug.Log("[" + counter + "] Velocity: " + velocity);
            Debug.Log("[" + counter + "] Acceleration: " + acceleration);
        }
    }
}