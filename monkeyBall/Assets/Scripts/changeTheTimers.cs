using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changeTheTimers : MonoBehaviour {
	Text txtRef;
	// Use this for initialization
	void Start () {
		txtRef = GetComponent<Text> ();
	}

	public void ChangeText(string timer){
		//changes the text displayed on the canvas to the string passed in
		txtRef.text = timer;
	}
}
