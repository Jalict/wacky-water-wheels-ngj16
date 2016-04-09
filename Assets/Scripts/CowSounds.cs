using UnityEngine;
using System.Collections;

public class CowSounds : MonoBehaviour {
	public AudioClip cowSound;
	int timer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		AudioSource.PlayClipAtPoint(cowSound, transform.position);
	
	}
}
