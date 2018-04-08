using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour {

	public Animator anim;    //reference to the bear's animator.
	public Transform ball;   //reference to bear's ball.
	Vector3 ballMove;        //references the ball's velocity
	float yoffset;			 //will offset the bear's position slightly

	// Use this for initialization
	void Start () {
		
		yoffset = -.45f;    //trying to make bear's position in the ball look nice!   
		anim = GetComponent<Animator>();   //sets up reference to animator.

	}
	
	// Update is called once per frame
	void Update () {

		//sets reference for ball's rigidbody and gets its velocity
		ballMove = ball.GetComponent<Rigidbody> ().velocity;
		ballMove = new Vector3 (ballMove.x, 0, ballMove.z);
		//these two control the bear's rotation and position within the ball
		transform.rotation = Quaternion.LookRotation (ballMove);
		transform.position = new Vector3(ball.position.x, ball.position.y + yoffset, ball.position.z);

		float speed = ballMove.magnitude;       //calculates length of the ball's velocity vector. 
		anim.SetFloat("moveSpeed", speed);		//changes "moveSpeed" parameter in anim to control walk animation.


	}
}
