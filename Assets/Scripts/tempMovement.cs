using UnityEngine;
using System.Collections;

public class tempMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-10f * Time.deltaTime, 0f, 0f);
				}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (10f * Time.deltaTime, 0f, 0f);
				}
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (0f, 0f, 5f * Time.deltaTime);
				}

		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (0f, 0f, -5f * Time.deltaTime);

				}

	}
}
