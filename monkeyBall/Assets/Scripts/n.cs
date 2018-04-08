using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class n : NetworkManager {

	bool autoJoin = true;

	//	bool checkfirst=false;
//	public virtual void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
//	{
//		var player = (GameObject)GameObject.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
//		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
//	}

//	override public void OnStartClient(UnityEngine.Networking.NetworkClient client){
//		print ("Nigga we made it");
//		if(refusal)
//			StopClient();
//	}

	//ends that mans career
	public void kick(){StopClient ();}
	//makes the start host able to return void
	public void hostButton(){StartHost ();}
	//makes the client be able to return void
	public void joinButton(){StartClient ();}


	public void changeMeLevel()
	{
		ServerChangeScene ("Level2");
	}


	public void setIP(string arg)
	{
		networkAddress = arg;
	}

	public override void OnClientConnect(NetworkConnection conn)
	{
		if (!clientLoadedScene)
		{
			// Ready/AddPlayer is usually triggered by a scene load completing. if no scene was loaded, then Ready/AddPlayer it here instead.
			ClientScene.Ready(conn);
			if (autoJoin)
			{
				ClientScene.AddPlayer(0);
			}
		}
	}
	public override void OnClientSceneChanged(NetworkConnection conn)
	{
		// always become ready.
		ClientScene.Ready(conn);

		if (!autoJoin)
		{
			return;
		}

		bool addPlayer = (ClientScene.localPlayers.Count == 0);
		bool foundPlayer = false;
		foreach (var playerController in ClientScene.localPlayers)
		{
			if (playerController.gameObject != null)
			{
				foundPlayer = true;
				break;
			}
		}
		if (!foundPlayer)
		{
			// there are players, but their game objects have all been deleted
			addPlayer = true;
		}
		if (addPlayer)
		{
			ClientScene.AddPlayer(0);
		}
	}

	IEnumerator ClientConnector()
	{
		yield return new WaitForSeconds(3);
		ClientScene.AddPlayer(0);
	}

}
