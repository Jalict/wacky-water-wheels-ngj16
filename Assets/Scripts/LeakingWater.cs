using UnityEngine;
using System.Collections;

public class LeakingWater : MonoBehaviour {

	public float currentWaterAmount = 43f;
	private float emptyTruck = -38f;
	private float waterDifferance;
	private float fullTank;
	public GameObject waterPlane;
	public Transform failTarget;
	private float waterRotation;
	public ParticleSystem rightParticleSystem;
	public ParticleSystem leftParticleSystem;

	//Time and score measuring stuff
	public bool gameFinished;
	public int score;
	private float startTime;
	private float runningTime;


	// Use this for initialization
	void Start () {
		waterRotation = transform.localRotation.z;
		startTime = Time.time;
		gameFinished = false;
		score = 0;
		fullTank = currentWaterAmount + Mathf.Abs(emptyTruck);
	}
	
	// Update is called once per frame
	void Update () {
		waterDifferance = fullTank / (currentWaterAmount + 38);
		if(currentWaterAmount > emptyTruck){
			if(Mathf.Abs(transform.localRotation.z * Mathf.Rad2Deg) > 2.0f * waterDifferance) { 
				Vector3 v = waterPlane.transform.localPosition;
				currentWaterAmount -= Mathf.Abs(transform.localRotation.z * Mathf.Rad2Deg)/(50/waterDifferance);
				v.y = currentWaterAmount;
				waterPlane.transform.localPosition = v;
				if(transform.localRotation.z * Mathf.Rad2Deg < -1f){
					leftParticleSystem.Stop();
					rightParticleSystem.Play();
				}
				else if(transform.localRotation.z * Mathf.Rad2Deg > 1f){
					rightParticleSystem.Stop();
					leftParticleSystem.Play();
				}
			}else{
				rightParticleSystem.Stop();
				leftParticleSystem.Stop();
			}
		}
		waterPlane.transform.Rotate(Vector3.forward, (waterRotation - transform.localRotation.z)*200);
		waterRotation = transform.localRotation.z;
	}

	void FixedUpdate() {
		if(gameFinished){
			runningTime = Time.time - startTime;
		}
		Debug.Log(Vector3.Distance(transform.position, failTarget.position));
		if(Vector3.Distance(transform.position, failTarget.position) > 8){
			gameFinished = true;
		}
	}

	void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.name == "FinishBox")
        {
        	gameFinished = true;
        	score = (((int)(runningTime / (Mathf.Pow((int)runningTime,2))) + 123) * 44) + ((int)currentWaterAmount + 39) * 25;
            Destroy(col.gameObject);
        }
    } 


}
