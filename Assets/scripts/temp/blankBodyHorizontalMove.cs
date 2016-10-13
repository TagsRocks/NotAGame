using UnityEngine;
using System.Collections;

public class blankBodyHorizontalMove : MonoBehaviour {
	
	public float sensitivityX = 1F;
	private float angleX = 0F;
	private Quaternion originalRotation;

	// Use this for initialization
	void Start () {
		originalRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
            angleX += Input.GetAxis("Mouse X") * sensitivityX;
            angleX = fitAngle(angleX);
            Quaternion xQuaternion = Quaternion.AngleAxis(angleX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
	}


	public static float fitAngle (float angle)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return angle;
	}
}
