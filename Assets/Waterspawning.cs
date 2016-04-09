using UnityEngine;
using System.Collections;

public class Waterspawning : MonoBehaviour {

	public Rigidbody waterObject;
	private int waterAmount = 1000;
	public int waterSpawned = 0;
	private Transform spawningPoint;


	// Use this for initialization
	void Start () {
		spawningPoint = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(waterSpawned < waterAmount){
			waterSpawned++;
			Vector3 randSpawnPos = new Vector3(Random.Range(-0.8f, 0.8f),0,Random.Range(-0.8f, 0.8f));
			StartCoroutine(SpawningCoroutine(randSpawnPos, spawningPoint));
		}
	}


	IEnumerator SpawningCoroutine(Vector3 randTarget, Transform target){
		Rigidbody waterInstance;
		waterInstance = Instantiate(waterObject, spawningPoint.position + randTarget, target.rotation) as Rigidbody;

		yield return null;
	}
}
