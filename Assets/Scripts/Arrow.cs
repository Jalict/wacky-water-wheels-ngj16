using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
    public Transform targetLocation;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		transform.LookAt(targetLocation);
    }
}
