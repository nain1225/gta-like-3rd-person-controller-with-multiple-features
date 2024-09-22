using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Controller : MonoBehaviour
{
    [Header("Wheel Transforms")]
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform backRightWheelTransform;

    [Header("Wheel Colliders")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider backLeftWheelCollider;
    public WheelCollider backRightWheelCollider;

    [Header("Wheel Acceleration")]
    public float carAccelerationForce = 100f;
    private float presentAcceleration = 0f;

    [Header("Wheel Steering")]
    public float wheelTorque = 100f;
    private float presentTorque = 0f;
    private void Update()
    {
        Move();
        MoveSteering();
    }

    public void Move()
    {   
        presentAcceleration = carAccelerationForce * Input.GetAxis("Vertical");

        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;
        backLeftWheelCollider.motorTorque = presentAcceleration;
        backRightWheelCollider.motorTorque = presentAcceleration;

    }
    public void MoveSteering()
    {   
        presentTorque = wheelTorque * Input.GetAxis("Horizontal");

        frontLeftWheelCollider.steerAngle = presentTorque;
        frontRightWheelCollider.steerAngle = presentTorque;


        //animate
        SteeringWheel(frontRightWheelCollider, frontRightWheelTransform);
        SteeringWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        SteeringWheel(backRightWheelCollider, backRightWheelTransform);
        SteeringWheel(backLeftWheelCollider, backLeftWheelTransform);
    }
    public void SteeringWheel(WheelCollider wc,Transform wt)
    {
        Vector3 position;
        Quaternion rotation;

        wc.GetWorldPose(out position, out rotation);
        wt.position = position;
        wt.rotation = rotation;
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Controller : MonoBehaviour
{
    [Header("Wheel Transforms")]
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform backRightWheelTransform;

    [Header("Wheel Colliders")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider backLeftWheelCollider;
    public WheelCollider backRightWheelCollider;

    [Header("Wheel Acceleration")]
    public float carAccelerationForce = 100f;
    private float presentAcceleration = 0f;

    [Header("Wheel Steering")]
    public float wheelTorque = 100f;
    private float presentTorque = 0f;

    private void Start()
    {
        // Debug: Ensure transforms and colliders are assigned
        if (!frontLeftWheelTransform || !frontRightWheelTransform || !backLeftWheelTransform || !backRightWheelTransform)
        {
            Debug.LogError("Wheel Transforms are not assigned!");
        }
        if (!frontLeftWheelCollider || !frontRightWheelCollider || !backLeftWheelCollider || !backRightWheelCollider)
        {
            Debug.LogError("Wheel Colliders are not assigned!");
        }
    }

    private void Update()
    {
        Move();
        MoveSteering();
        UpdateWheelTransforms();
    }

    public void Move()
    {
        presentAcceleration = carAccelerationForce * Input.GetAxis("Vertical");

        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;
        backLeftWheelCollider.motorTorque = presentAcceleration;
        backRightWheelCollider.motorTorque = presentAcceleration;
    }

    public void MoveSteering()
    {
        presentTorque = wheelTorque * Input.GetAxis("Horizontal");

        frontLeftWheelCollider.steerAngle = presentTorque;
        frontRightWheelCollider.steerAngle = presentTorque;
    }

    private void UpdateWheelTransforms()
    {
        UpdateWheelTransform(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelTransform(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelTransform(backLeftWheelCollider, backLeftWheelTransform);
        UpdateWheelTransform(backRightWheelCollider, backRightWheelTransform);
    }

    private void UpdateWheelTransform(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);

        // Adjust rotation to correct 90-degree offset if needed
        Quaternion rotationCorrection = Quaternion.Euler(0, 0, 90);
        rotation *= rotationCorrection;

        wheelTransform.position = position;
        wheelTransform.rotation = rotation;

        // Debug: Log positions and rotations
        Debug.Log($"{wheelTransform.name} Position: {position}, Rotation: {rotation.eulerAngles}");
    }
}
*/