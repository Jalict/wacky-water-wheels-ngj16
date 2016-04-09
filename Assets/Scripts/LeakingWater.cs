using UnityEngine;
using System.Collections;

public class LeakingWater : MonoBehaviour {

	private float fullTruck = 43f;
	public float currentWaterAmount = 43f;
	private float emptyTruck = -38f;
	public GameObject waterPlane;
	private float waterRotation;

	// Use this for initialization
	void Start () {
		waterRotation = transform.localRotation.z;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentWaterAmount > emptyTruck){
			if(Mathf.Abs(transform.localRotation.z * Mathf.Rad2Deg) > 2.0f) { 
				Vector3 v = waterPlane.transform.localPosition;
				currentWaterAmount -= Mathf.Abs(transform.localRotation.z * Mathf.Rad2Deg)/50;
				v.y = currentWaterAmount;
				waterPlane.transform.localPosition = v;
			}
		}
		Debug.Log(transform.localRotation.z * Mathf.Rad2Deg);

		waterPlane.transform.Rotate(Vector3.forward, (waterRotation - transform.localRotation.z)*200);
		waterRotation = transform.localRotation.z;
	}
}
