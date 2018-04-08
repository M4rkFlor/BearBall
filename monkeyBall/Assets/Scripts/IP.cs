using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IP : MonoBehaviour {

	public Text Port;

	// Use this for initialization
	void Start () {

		//Debug.Log ("" + Network.player.ipAddress);

		Port.text = "Your IP: " + Network.player.ipAddress;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
