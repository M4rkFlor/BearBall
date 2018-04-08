using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	GameObject n;
	Transform hostButton;
	Transform joinButton;
	Transform ipField;
	Transform helpButton;
	Transform helpImage;

	// Use this for initialization
	void Start () {

		Cursor.visible = true;

		n = GameObject.Find("NetworkManager");
		hostButton = this.transform.GetChild (0);
		joinButton = this.transform.GetChild(2);
		ipField = this.transform.GetChild(1);
		helpButton = this.transform.GetChild(4);
		helpImage = this.transform.GetChild(5);

		SetTheButtons ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetTheButtons()
	{
		n nScript = n.GetComponent<n> ();
		hostButton.GetComponent<Button> ().onClick.AddListener (nScript.hostButton);
		joinButton.GetComponent<Button> ().onClick.AddListener (nScript.joinButton);
		ipField.GetComponent<InputField> ().onValueChanged.AddListener (nScript.setIP);
		helpButton.GetComponent<Button> ().onClick.AddListener (showHelp);
	}


	void showHelp()
	{
		helpImage.gameObject.SetActive (!helpImage.gameObject.activeInHierarchy);
	}


}
