using UnityEngine;
using System.Collections;

public class LeakingWater : MonoBehaviour {

	private float fullTruck = 38f;
	public float currentWaterAmount = 38f;
	private float emptyTruck = -34f;
	public GameObject waterPlane;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(transform.localRotation.x * Mathf.Rad2Deg);
		if(currentWaterAmount > emptyTruck){
			if(Mathf.Abs(transform.localRotation.x * Mathf.Rad2Deg) > 5.0f ) { 
				Vector3 v = waterPlane.transform.localPosition;
				currentWaterAmount -= Mathf.Abs(transform.localRotation.x * Mathf.Rad2Deg)/50;
				v.y = currentWaterAmount;
				waterPlane.transform.localPosition = v;
			}
		}
	}
}
