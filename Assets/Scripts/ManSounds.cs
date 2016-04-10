using UnityEngine;
using System.Collections;

public class ManSounds : MonoBehaviour {
	public AudioClip manSound;
	public AudioClip manCollisionSound;

	void OnCollisionEnter(Collision collision){
		AudioSource.PlayClipAtPoint(manCollisionSound, transform.position);
		AudioSource.PlayClipAtPoint(manSound, transform.position);
	}
}
