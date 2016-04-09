using UnityEngine;
using System.Collections;

public class WaterContainer : MonoBehaviour {
	float xRot;
	float yRot;
	float zRot;


	// Use this for initialization
	void Start () {
		xRot = transform.rotation.x;
		yRot = transform.rotation.y;
		zRot = transform.rotation.z;

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			transform.eulerAngles = new Vector3(xRot, yRot, zRot);
			xRot += 1f;
		}
		if(Input.GetKey(KeyCode.D)){
			transform.eulerAngles = new Vector3(xRot, yRot, zRot);
			xRot -= 1f;
		}

	}
}