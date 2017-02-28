using UnityEngine;
using System.Collections;

public class CameraTarget : MonoBehaviour {

	public Transform camTransform;

	[HideInInspector]
	public float camDistance;

	public float camPadding = 0.3f;

	private float maxDistance = 50f;

	public LayerMask rayLayer;
	// Update is called once per frame
	void Update () {
		transform.LookAt (camTransform);

		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit, maxDistance, rayLayer)) {
			camDistance = hit.distance - camPadding;
			//Debug.Log (hit.distance);
		}
				

		//Debug.Log (camDistance);
		//Debug.Log (hit.distance);	
	}
}






