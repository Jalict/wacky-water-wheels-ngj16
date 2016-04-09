using UnityEngine;
using System.Collections;

public class Driver : MonoBehaviour
{
    public WheelCollider[] wheelColliders;
    public Transform[] wheelTransforms;
    public Transform forcePoint;

    private Rigidbody rigidBody;

    public float maxWheelRotation;
    public float maxPower;
    public float magicForceAmount;

    private float power;
    private float brake;
    private float steer;

    // Use this for initialization
    void Start () {
        power = 0;
        brake = 0;
        steer = 0;

        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        steer = 0;
        brake = 0;
        power = 0;

        if (Input.GetKey(KeyCode.W)) { power = maxPower * Time.deltaTime; }
        else {/* TIP IT BACK*/ }
        if (Input.GetKey(KeyCode.S)) { power = -maxPower * Time.deltaTime; }
        else {/* TIP IT BACK*/ }

        if (Input.GetKey(KeyCode.A)) { steer = -1f * maxWheelRotation; rigidBody.AddForceAtPosition(transform.right * magicForceAmount, forcePoint.position, ForceMode.Impulse);}
        if (Input.GetKey(KeyCode.D)) { steer = 1f * maxWheelRotation; rigidBody.AddForceAtPosition(-transform.right * magicForceAmount, forcePoint.position, ForceMode.Impulse);}

        if (Input.GetKey(KeyCode.Space)) { brake = 1; }

        Move(power, steer, brake);
    }

    void Move(float power, float steer, float brake) {
        foreach (WheelCollider wheelCollider in wheelColliders)
        {
            // BRAKING
            if(brake > 0) {
                wheelCollider.brakeTorque = brake;
                if (wheelCollider.CompareTag("Back"))
                    wheelCollider.motorTorque = 0;
            }
            // NOT BRAKING
            else {
                wheelCollider.brakeTorque = 0;
                if (wheelCollider.CompareTag("Back"))
                    wheelCollider.motorTorque = power; // IF POWER > 0 THEN IT IS DRIVING
            }

            if(wheelCollider.CompareTag("Front"))
                wheelCollider.steerAngle = steer;

        }

        foreach (Transform wheelTransform in wheelTransforms)
        {
            if (wheelTransform.CompareTag("Front"))
            {
                wheelTransform.localRotation = Quaternion.Euler(0,90 + steer, 90);
            }
        }
    }
}
