using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class hostSwitch : MonoBehaviour {

	GameObject n;
	Transform hostButton;
	Transform joinButton;
	Transform ipField;


	// Use this for initialization
	void Start () {
		n = GameObject.Find("NetworkManager");
		hostButton = this.transform.GetChild (0);
		SetTheButtons ();

	}

	// Update is called once per frame
	void Update () {

	}

	void SetTheButtons()
	{
		n nScript = n.GetComponent<n> ();
		hostButton.GetComponent<Button> ().onClick.AddListener (nScript.changeMeLevel);
	}
}
