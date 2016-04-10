using UnityEngine;
using System.Collections;

public class CameraSlide : MonoBehaviour {
    public Transform target;

    public float maximum = 2f;

	private float smooth = 3.5f;

    public float amount;

    // Use this for initialization
    void Start () {
        amount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) && amount < maximum) {
            amount += 8f * Time.deltaTime;
        }
        else if (amount > 0.1f)
        {
			amount -= 14f * Time.deltaTime;
        }

		if(Input.GetKey(KeyCode.D) && amount > -maximum) {
            amount -= 8f *Time.deltaTime;
        }
         else if(amount < 0.1f) {
            amount += 14f * Time.deltaTime;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0.87f + amount, transform.localPosition.y, transform.localPosition.z), smooth * Time.deltaTime);

		transform.LookAt(target);
    }
}
