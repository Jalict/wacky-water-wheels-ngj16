using UnityEngine;
using System.Collections;

public class Driver : MonoBehaviour
{
    public WheelCollider[] wheelColliders;
    public Transform[] wheelTransforms;
    public Transform forcePoint;

    private Rigidbody rigidBody;

    private AudioSource acceSound;
    private float p;
    private float avgRpm;

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
        acceSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        steer = 0;
        brake = 0;
        power = 0;

        if (Input.GetKey(KeyCode.W)){ 
            power = maxPower * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) { 
            power = -maxPower * Time.deltaTime; 
        }


        if (Input.GetKey(KeyCode.A))
        {
            steer = -1f * maxWheelRotation;
            
            rigidBody.AddForceAtPosition(forcePoint.right * magicForceAmount, forcePoint.position, ForceMode.Force);
        } else {/* TIP IT BACK*/ }
        if (Input.GetKey(KeyCode.D))
        {
            steer = 1f * maxWheelRotation;
            rigidBody.AddForceAtPosition(-forcePoint.right * magicForceAmount, forcePoint.position, ForceMode.Force);
        } else {/* TIP IT BACK*/ }

        if (Input.GetKey(KeyCode.Space)) { brake = 1; }

        if(rigidBody.velocity.magnitude > 1){
            p = rigidBody.velocity.magnitude / 10;
            acceSound.pitch = Mathf.Clamp(p, 0.3f, 1.0f);
        } else if (rigidBody.velocity.magnitude < 1){
            acceSound.pitch = 0.3f;
        }

        Move(power, steer, brake);
    }

    void Move(float power, float steer, float brake) {
        avgRpm = 0;
        foreach (WheelCollider wheelCollider in wheelColliders)
        {
            avgRpm += wheelCollider.rpm;
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

        avgRpm /= wheelColliders.Length;

        foreach (Transform wheelTransform in wheelTransforms)
        {
            if (wheelTransform.CompareTag("Front"))
            {
                wheelTransform.localRotation = Quaternion.Euler(0,90 + steer, 90);
            }
        }
    }
}
