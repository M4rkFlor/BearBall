using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class quitButton : MonoBehaviour {


	GameObject n;
	Transform thequitButton;
	Transform ipField;


	// Use this for initialization
	void Start () {
		n = GameObject.Find("NetworkManager");
		thequitButton = this.transform.GetChild (0);
		SetTheButtons ();

	}

	// Update is called once per frame
	void Update () {

	}

	void SetTheButtons()
	{
		n nScript = n.GetComponent<n> ();
		thequitButton.GetComponent<Button> ().onClick.AddListener (Application.Quit);
	}
}
