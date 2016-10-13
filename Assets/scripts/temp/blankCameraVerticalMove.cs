using UnityEngine;
using System.Collections;


public class blankCameraVerticalMove : MonoBehaviour {

	public float sensitivityY = 1F;
	public float minAngleY = -90f;
	private float angleY = 0F;
	private Quaternion originalRotation;
	
	// Use this for initialization
	void Start () {
		originalRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
            angleY += Input.GetAxis("Mouse Y") * sensitivityY;
            angleY = fitAngle(angleY);
            Quaternion yQuaternion = Quaternion.AngleAxis(-angleY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
    }
	
	
	public float fitAngle (float angle)
	{
		if (angle < minAngleY)
			angle = minAngleY;
		if (angle > 90F)
			angle = +90F;
		return angle;
	}
}
