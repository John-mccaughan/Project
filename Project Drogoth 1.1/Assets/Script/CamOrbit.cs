using UnityEngine;
using System.Collections;

public class CamOrbit : MonoBehaviour {

	public Transform target;
	private Transform camTransform;
	private CameraTarget camTarget;

	private Camera cam;

	public float maxDistance = 10f;
	public float distance = 2f;
	private float currentX = 0f;
	private float currentY = 0f;
	public float sensitivityX = 4f;
	public float sensitivityY = 4f;

	public float maxY = 70f;
	public float minY = 0f;

    public float turn = 5f;
    public float turnr = -5f;


    // Use this for initialization
    void Start () {
		camTransform = transform;
		camTarget = target.GetComponent<CameraTarget> ();
	}

	void Update () {
        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX;
            currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

            currentY = Mathf.Clamp(currentY, minY, maxY);

            if (camTarget.camDistance > 0)
            {
                distance = camTarget.camDistance;
            }

            if (distance > maxDistance)
            {
                distance = maxDistance;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, turnr, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, turn, 0);
            }
        }
    }
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);
		camTransform.position = target.position + rotation * dir;

		camTransform.LookAt (target);
	}
}
