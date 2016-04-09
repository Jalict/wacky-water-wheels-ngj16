using UnityEngine;
using System.Collections;

public class Driver : MonoBehaviour
{
    public WheelCollider[] wheelColliders;
    public Transform[] wheelTransforms;

    public float maxWheelRotation = 15f;

    // Use this for initialization
    void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        float accel = 0f;
        float steer = 0;

        if (Input.GetKey(KeyCode.W))
        {
            accel = 1000f; //TODO ?????
        }

        if (Input.GetKey(KeyCode.A))
        {
            steer -= 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            steer += 1f;
        }

        Move(accel, steer);
    }

    void Move(float accel, float steer) {
        foreach (WheelCollider wheelCollider in wheelColliders)
        {
            wheelCollider.motorTorque = accel;

            if(wheelCollider.CompareTag("Front"))
                wheelCollider.steerAngle = steer * maxWheelRotation;
        }

        foreach (Transform wheelTransform in wheelTransforms)
        {
            if (wheelTransform.CompareTag("Front"))
            {
                wheelTransform.localRotation = Quaternion.Euler(0,90 + steer * maxWheelRotation, 90);
            }
        }
    }
}
