using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changeCountDown : MonoBehaviour {
	//text var
	Text txtRef;
	// Use this for initialization
	void Start () {
		//sets the text to the text box its attached to
		txtRef = GetComponent<Text> ();
	}

	public void ChangeText(string change,float time){
		//changes the text to the var passesd in
		txtRef.text = change;
		if (time <= 0) {
			//displays go for 1 second when the timer is done
			txtRef.text = "GO!";
			Destroy (this.gameObject, 1);
		}
	}
}
