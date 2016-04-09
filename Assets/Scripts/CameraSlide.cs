using UnityEngine;
using System.Collections;

public class CameraSlide : MonoBehaviour {
	public Transform target;
	float move = 0;
	public float minimum = 0F;
    public float maximum = 2F;
    private bool movedLeft = false;
    private bool movedRight = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {
			move = Mathf.Lerp(minimum, maximum, Time.time);
			Debug.Log(move);
				transform.localPosition = new Vector3(0.71F+move, transform.localPosition.y, transform.localPosition.z);
				movedLeft= true;
		}else
		if (Input.GetKey (KeyCode.D) && !Input.GetKey(KeyCode.A)) {
			move = Mathf.Lerp(minimum, maximum, Time.time);
			transform.localPosition = new Vector3(0.71f+-move, transform.localPosition.y, transform.localPosition.z);
			movedRight = true;
		} else 

		
		transform.LookAt(target);
	
		if (!Input.GetKey(KeyCode.A) && !Input.GetKey (KeyCode.D) && movedLeft == true) {
			move = Mathf.Lerp(maximum, minimum, Time.time);
			transform.localPosition = new Vector3(0.71F+move, transform.localPosition.y, transform.localPosition.z);
			movedLeft = false;
		}
		if (!Input.GetKey (KeyCode.D) && !Input.GetKey(KeyCode.A) && movedRight == true) {
			move = Mathf.Lerp(maximum, minimum, Time.time);
			transform.localPosition = new Vector3(0.71f+-move, transform.localPosition.y, transform.localPosition.z);
			movedRight = false;
		}
	}
}