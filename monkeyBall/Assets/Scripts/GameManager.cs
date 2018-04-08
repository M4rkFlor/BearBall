using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{

	public static GameManager Instance { set; get; }

	// Use this for initialization
	void Start () 
	{

		Instance = this;
		DontDestroyOnLoad (gameObject);

	}
	
	// Update is called once per frame
	void Update () 
	{



	}

	public void ConnectButton()
	{



	}

	public void HosttButton()
	{



	}

}
