using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changeBananaText : MonoBehaviour {
	//text var
	Text txtRef;
	// Use this for initialization
	void Start () {
		txtRef = GetComponent<Text> ();
	}

	public void ChangeText(string change){
		//changes the text displayed on the canvas to the string passed in
		txtRef.text = "Bananas " + change;
	}
}
