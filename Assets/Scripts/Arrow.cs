using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
    public Transform targetLocation;
    public Transform originPoint;
    public float angle;

    // Use this for initialization
    void Start () {
        angle = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float angle = Mathf.Atan2(targetLocation.position.z - originPoint.position.z, targetLocation.position.x - originPoint.position.x);
        angle = (angle + 180f) % 360f;
        angle = 360f - angle;
        transform.localPosition = new Vector3(0.75f + (Mathf.Cos(angle) * 4f), 2.5f, Mathf.Sin(angle) * 4f);
        // 0.75 2.5 4
    }
}
