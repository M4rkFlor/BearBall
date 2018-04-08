using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Player : NetworkBehaviour {
	//player is the host
	[SyncVar]
	public bool host;
	//how many banans you have
	public int BannanaCount;
	//call to the network mananger
	NetworkManager man;

	public Material color1;
	public Material color2;
	public Material color3;
	public Material color4;
	//calls the  canvases
	public Canvas can;
	public Canvas endCan;
	public Canvas myCan;
	public Canvas quitButton;
	//the countdown variables
	float time = 3.0f;
	[SyncVar]
	public int playerCount;

	int tempCount;

	Rigidbody body;

	public Canvas nextLevelButton;

	[SyncVar]
	public bool goal;
	public bool startTime;
	[SyncVar]
	public bool started;
	[SyncVar]
	public int color;

	float deathHeight;



	//the timer variables
	float countUp = 0.0f;
	public bool startCountUp = false;

	Vector3 startPos;
	// Use this for initialization
	public override void OnStartLocalPlayer() {
		//cannot use the code if aren't the local player
		if (!localPlayerAuthority)
			return;

		deathHeight = -125;

		Cursor.visible = false;
		body = this.GetComponent<Rigidbody> ();
		//initializes all the variables
		Camera cam;
		man = GameObject.Find("NetworkManager").GetComponent<n>();
		cam = Camera.main;
		cam.GetComponent<CamControl> ().target = this.transform;
		if (man.numPlayers == 1) {
			host = true;
			tempCount = 1;
		}
		print (host);
		startPos = transform.position;
		GetComponent<UnityStandardAssets.Vehicles.Ball.BallUserControl> ().start = moveCheck();
		startTime = false;
		myCan = (Canvas)Instantiate (can, Vector3.zero, Quaternion.Euler(Vector3.zero));
		refuseConnect ();
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		color = players.Length;
		SetColor ();
		print ("my color num " + color);
		//NetworkServer.SpawnObjects ();

	}


	// Update is called once per frame
	void Update () {
		//calls the RPC to start the countdown on all the players screens when the host presses enter
		if (isServer && Input.GetKeyDown (KeyCode.Return)) {
			RpcStartTheTimers ();
			playerCount = man.numPlayers;
		}
		SetColor ();

		if (goal && isLocalPlayer) {
			Destroy(GameObject.FindGameObjectWithTag("Banvas"));
			myCan = (Canvas)Instantiate (endCan, Vector3.zero, Quaternion.Euler(Vector3.zero));
			//deathHeight = -400;
			if (host) {
				Cursor.visible = true;
				if(SceneManager.GetActiveScene().name.Equals(man.onlineScene))
				myCan = (Canvas)Instantiate (nextLevelButton, Vector3.zero, Quaternion.Euler(Vector3.zero));
				else
				myCan = (Canvas)Instantiate (quitButton, Vector3.zero, Quaternion.Euler(Vector3.zero));
			}
			goal = false;
		}

		if (transform.position.y < deathHeight) {
			if (body != null) {
				body.isKinematic = true;
				body.isKinematic = false;
				transform.position = startPos;
			}
		}
		StartTheTimers ();

		if (myCan != null) {
			ChangeBananaText ();
			CountDownText ();
			CountUpText ();
		}
		print ("starttime is " + startTime);


		//work above this line
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if (man != null) {
			if (host && tempCount < man.numPlayers) {
				tempCount++;
				GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
				players [tempCount - 1].GetComponent<Player> ().color = tempCount;
				SetColor ();
			}

		}

	}

	void ChangeBananaText(){
		string bananas = BannanaCount.ToString ();
		//calls the text on the canvas to change it
		if(myCan.GetComponentInChildren<changeBananaText> ()!= null)
			myCan.GetComponentInChildren<changeBananaText> ().ChangeText (bananas);
	}

	void CountUpText(){
		//counts up your time from starting
		if (startCountUp) {
			countUp += Time.deltaTime;
		}
		//changes the float point to only 2 decimal places
		countUp *= 100;
		float countUp2 = (int)countUp;
		countUp /= 100;
		countUp2 /= 100;
		string sendTime = countUp2.ToString ();
		//calls the text on the canvas to change it
		if(myCan.GetComponentInChildren<scriptText> () != null)
			myCan.GetComponentInChildren<scriptText> ().ChangeText (sendTime);
	}

	void CountDownText(){
		//counts down from 3 seconds
		if (startTime) {
			time -= Time.deltaTime;
			if (time <= 0) {
				startCountUp = true;;
				startTime = false;
				time = 0;
			}
			//casts the time to an integer and then to string to display
			int time2 = (int)time;
			time2 += 1;
			string timeString = time2.ToString ();
			//calls the text on the canvas to change it
			if (myCan.GetComponentInChildren<changeCountDown> () != null) {
				myCan.GetComponentInChildren<changeCountDown> ().ChangeText (timeString,time);

			}
		}
	}

	IEnumerator CountDown(){
		
		//Waits 3 seconds to let the balls move
		yield return new WaitForSeconds(3);
		freeTheBalls ();
	}
		
	void freeTheBalls(){
		//loops through all the players and allows them to move when the method is called
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i < players.Length; i++) {
			players [i].GetComponent<UnityStandardAssets.Vehicles.Ball.BallUserControl> ().start = true;
		}
	}

	bool moveCheck(){
		//checks to make sure all the players can't move if the host hasn't started the game
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i < players.Length; i++) {
			if (players [i].GetComponent<UnityStandardAssets.Vehicles.Ball.BallUserControl> ().start == true)
				return true;
		}
		return false;
	}

	void refuseConnect(){
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i < players.Length; i++) {
			//loops through all the players and sets their start time to true
			if (players [i].GetComponent<Player> ().started == true) {
				man.GetComponent<n> ().kick ();
			} else if (players [i].GetComponent<Player> ().host == true) {
				if(players [i].GetComponent<Player> ().playerCount>=4)
					man.GetComponent<n>().kick();
			}

		}
	}

	void StartTheTimers(){
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i < players.Length; i++) {
			//loops through all the players and sets their start time to true
			if (players [i].GetComponent<Player> ().startTime == true) {
				startTime = true;
			}
		}
	}

	//passes over the network when the players can start
	[ClientRpc]
	public void RpcStartTheTimers(){
		startTime = true;
		started = true;
		StartCoroutine(CountDown ());
		print ("in the command");
	}

	void SetColor()
	{
		switch (color) {

		case 1:
			this.GetComponent<Renderer> ().material = color1;
			print ("painted 1");
			break;
		case 2:
			this.GetComponent<Renderer> ().material = color2;
			print ("painted 2");
			break;
		case 3:
			this.GetComponent<Renderer> ().material = color3;
			print ("painted 3");
			break;
		case 4:
			this.GetComponent<Renderer> ().material = color4;
			print ("painted 4");
			break;

		}
	}
	public void PlaySound(AudioClip sound)
	{
		if (isLocalPlayer) {
			this.GetComponent<AudioSource> ().clip = sound;
			this.GetComponent<AudioSource> ().Play ();
		}
	}
}
