using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class CamControl : NetworkBehaviour {

	public Transform target;							// target for camera to look at
	private float targetHeight 		= 1.0f;					// height of target
	private float distanceC 	    = 4.0f;					// Reamins The constatnt Disstance
	private float distance 			= 4.0f;					// distance between target and camera
	private float xSpeed 			= 250.0f;				// movement on horizontal
	private float x 				= 0.0f;					// store axis x from input
	private float y 				= 0.0f;					// store axix y from input

	// Use this for initialization
	public override void OnStartLocalPlayer() {
		if (!localPlayerAuthority)
			return; 
		Vector2 angles = transform.eulerAngles;															// set vector 2 values from this transform (camera)
		x = angles.y;																							// set x to equal angle x
		y = angles.x;		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (!localPlayerAuthority)
			return; 
		Vector3 vTargetOffset;																			// store vertical target offset amount (x,y,z)

		x += Input.GetAxis("Mouse X") * xSpeed * 0.01f;															// set x to axis movement horizontal
		y -= Input.GetAxis("Mouse Y") * xSpeed * 0.01f;
		//y=target.GetChild(0).transform.rotation.y;
	

		//distance += Input.GetAxis("CameraZ") * xSpeed * 0.0005f;
		if (y < 10)
			y = 10;
		if (y > 80)
			y = 80;
		distance = Mathf.Log10(y)/(1/distanceC);
		//Quaternion rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(y, x, 0), Time.deltaTime * 3);		// set rotation value to equal the rotation of the camera and time
		Quaternion rotation =Quaternion.Euler(y, x, 0);
		vTargetOffset = new Vector3 (0, -targetHeight, 0);														// calculate desired camera position
		Vector3 position = target.position - (rotation * Vector3.forward * distance + vTargetOffset); 			// set camera position and angle based on rotation, wanted distance and target offset amount

//		RaycastHit hit;
//		if (Physics.Raycast (transform.position, Vector3.down, out hit)) 
//		{
//			print ("distance " + hit.distance);
//			if (hit.distance < 1.4f) {
//				rotation = Quaternion.Euler (rotation.x, rotation.y, rotation.z + 1f);
//			} 
//			else if (hit.distance > 1.6f) {
//				rotation = Quaternion.Euler (rotation.x -1f, rotation.y, rotation.z);
//			}
		
		//}
		//position = new Vector3(position.x,0,position.z);
		transform.rotation = rotation;																			// set camera rotation to current rotation amount
		transform.position = position;			
	}
}
