using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scriptText : MonoBehaviour{
	//text var
	Text txtRef;
	// Use this for initialization
	void Start () {
		//calls the text box on the caqnvas
		txtRef = GetComponent<Text> ();
	}

	//changes the text to the var passesd in
	public void ChangeText(string change){
		txtRef.text = change;
	}
}
