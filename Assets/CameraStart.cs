using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class CameraStart : MonoBehaviour
{
    public Transform endTransform;
	public Transform startTransform;
    public Transform focus;

    public DepthOfField dof;
    public CameraSlide slide;
    public GameManager gm;

    private float percentage;

    // Use this for initialization
    void Start () {
        percentage = 0;
        transform.localPosition = startTransform.localPosition;
        transform.localRotation = startTransform.localRotation;

        dof.enabled = true;

        StartCoroutine(MoveToPos());
    }

	// Update is called once per frame
	void Update () {

    }

    IEnumerator MoveToPos()
    {
        bool started = false;

        while(!started) {
            yield return new WaitForEndOfFrame();

			if(Input.GetKey(KeyCode.W)) {
				started = true;
			}
        }

        while (Vector3.Distance(transform.localPosition, endTransform.localPosition) > 0.1f)
        {
            percentage += Time.deltaTime;

            transform.localPosition = Vector3.Lerp(startTransform.localPosition, endTransform.localPosition, percentage);
			transform.localRotation	= Quaternion.Lerp(startTransform.localRotation, endTransform.localRotation, percentage);

            yield return new WaitForEndOfFrame();
        }

        dof.enabled = false;
        slide.enabled = true;

        gm.isAllowedToDepth = true;
    }
}
