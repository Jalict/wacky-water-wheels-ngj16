using UnityEngine;
using System.Collections;

public class DriveSounds : MonoBehaviour {
	public AudioClip collisionSound1;
	public AudioClip collisionSound2;
	public AudioClip collisionSound3;
	public AudioClip collisionSound4;
	public AudioClip collisionSound5;
	public AudioClip collisionSound; // just to debug

	int numberOfHit = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision){
		numberOfHit += 1;

		switch (numberOfHit)
		{
	    	case 1:
	        collisionSound = collisionSound1;
	        break;
	    	case 2:
	        collisionSound = collisionSound2;
	        break;
	        case 3:
	        collisionSound = collisionSound3;
	        break;
	    	case 4:
	        collisionSound = collisionSound4;
	        break;
	        case 5:
	        collisionSound = collisionSound5;
	        break;
		}
		AudioSource.PlayClipAtPoint(collisionSound, transform.position);
		if(numberOfHit>=5){
			numberOfHit = 0;
		}
	}
}
