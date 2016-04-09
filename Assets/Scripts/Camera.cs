using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	public Transform target;
	//float x1 = 0f;
		float x;
	float y;
	float z;

public Vector3 startPos;

	

	// Use this for initialization
	void Start () {
		x = transform.localPosition.x;
		y = transform.localPosition.y;
		z = transform.localPosition.z;
		//startPos = (0f,0f,0f); 
		//Vector3 startPos = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position);

		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.A)) {
			//transform.position = Vector3.Lerp(startPos,startPos, 10);
			transform.RotateAround(Vector3.zero, Vector3.up, 10 * Time.deltaTime);


			//thisTransform.position = Vector3.Lerp(transform.position, transform.position, 10);
			//transform.Translate (x, 0f, 0f);
			//x+=0.002f;
				}
		if (Input.GetKey (KeyCode.D)) {
			transform.RotateAround(Vector3.zero, Vector3.down, 10 * Time.deltaTime);
			//transform.position = Vector3.Lerp(transform.position,transform.position, 10);
			//thisTransform.position = Vector3.Lerp(transform.position, transform.position, 10);
			//transform.Translate (x, 0f, 0f);
			//x-=0.002f;
				}


		transform.LookAt(target);
	
	}
}
