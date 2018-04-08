using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watercollison : MonoBehaviour {
	//Confetti variables 
	public bool Confetti;
	public ParticleSystem ConfettiParticle;
	// Use this for initialization
	void Start () {
		//sets the Confetti to the particle system that was attached
		ConfettiParticle = this.GetComponent<ParticleSystem> ();
	}

	void OnTriggerEnter(Collider other) 
	{
		//if the player runs into the portal turn on that confetti
		if (other.tag == "Player") {
			ConfettiParticle.Play ();
			Confetti = true;
			print ("collided");
			other.GetComponent<Player> ().startCountUp = false;
			other.GetComponent<UnityStandardAssets.Vehicles.Ball.BallUserControl> ().start = false;
			other.GetComponent<Player> ().goal = true;
			other.GetComponent<UnityStandardAssets.Vehicles.Ball.BallUserControl> ().move = Vector3.zero;
		}
	}

}
