using UnityEngine;
using System.Collections;

public class CowSounds : MonoBehaviour {
	public AudioClip cowSound;
	public AudioClip cowCollisionSound;
	int timer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer++;
		if(timer>=100){
			AudioSource.PlayClipAtPoint(cowSound, transform.position);
			timer = 0;
		}
	}
	void OnCollisionEnter(Collision collision){
		AudioSource.PlayClipAtPoint(cowCollisionSound, transform.position);
	}
}
