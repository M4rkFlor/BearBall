using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorSet : MonoBehaviour {
	int Color;
	public Material color1;
	public Material color2;
	public Material color3;
	public Material color4;
	// Use this for initialization
	// Update is called once per frame
	void Update () {
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

		for (int i = 0; i < players.Length; i++) {
			switch (players [i].GetComponent<Player> ().color) {

			case 1:
				players [i].GetComponent<Renderer> ().material = color1;
				print ("painted 1");
					break;
				case 2:
					players [i].GetComponent<Renderer>().material = color2;
				print ("painted 2");
					break;
				case 3:
					players [i].GetComponent<Renderer>().material = color3;
				print ("painted 3");
					break;
				case 4:
					players [i].GetComponent<Renderer>().material = color4;
				print ("painted 4");
					break;

			}
		}

	}
}
