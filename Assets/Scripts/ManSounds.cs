using UnityEngine;
using System.Collections;

public class ManSounds : MonoBehaviour {
	public AudioClip manSound;
	public AudioClip manCollisionSound;
	float timer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += timer * Time.deltaTime;
		if(timer>=250){
			AudioSource.PlayClipAtPoint(manSound, transform.position);
			timer = 0f;
		}
	}
	void OnCollisionEnter(Collision collision){
		AudioSource.PlayClipAtPoint(manCollisionSound, transform.position);
	}
}
