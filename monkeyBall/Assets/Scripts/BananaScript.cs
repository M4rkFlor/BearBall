using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class BananaScript : NetworkBehaviour {

	// Use this for initialization
	public AudioClip sound;
	void Start () {
		//CmdSpawnBanana ();
	}
	
	// Update is called once per frame
	void Update () {
		//rotates the banana in a circle
		transform.Rotate (new Vector3 (5, 0, 0));
	}
	/*[Command]
	void CmdSpawnBanana (){
		//Vector3 position = new Vector3 (10,1,0);
		GameObject obj = (GameObject)Instantiate (this.gameObject, (this.gameObject.transform.position), Quaternion.Euler(new Vector3(0,0,90)));
		NetworkServer.Spawn (obj);

	}
	*/
	void OnTriggerEnter(Collider other) {
		//destroys the banana if the player runs into it
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<Player> ().BannanaCount += 1;
			other.gameObject.GetComponent<Player> ().PlaySound(sound);
			Destroy (gameObject);
		}

	}
}
