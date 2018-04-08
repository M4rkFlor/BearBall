using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class spawnBananas : NetworkBehaviour {
	// Use this for initialization
	void Start () {
		//spawns the banana at a specific position 
		GameObject[] bananas = GameObject.FindGameObjectsWithTag("Banana");
		for (int i = 0; i < bananas.Length; i++) {
			CmdSpawnBanana (bananas[i]);
		}
		//CmdSpawnBanana (new Vector3(10,1,0));
	}

	//Spawns the banana over the server
	[Command]
	void CmdSpawnBanana (GameObject banana){
		//Vector3 position = new Vector3 (10,1,0);
		GameObject obj = (GameObject)Instantiate (banana, (banana.transform.position), Quaternion.Euler(new Vector3(0,0,90)));
		NetworkServer.Spawn (obj);
	}
}
