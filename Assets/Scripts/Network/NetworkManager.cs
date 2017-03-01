using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

	const string VERSION = "v0.0.1";
	public string roomName = "qsd";
	public string playerPrefabName  = "Player";
	public Transform spawnPoint;

	void Start () {
		PhotonNetwork.ConnectUsingSettings(VERSION); //connect server ac l'app id
	}

	void OnJoinedLobby() {
		RoomOptions roomOptions = new RoomOptions() { IsVisible = false, MaxPlayers = 4};
		PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);

	}

	void OnJoinedRoom() {
		PhotonNetwork.Instantiate(playerPrefabName, spawnPoint.position, spawnPoint.rotation, 0); //le prefab doit etre ds un dossier "Resource"
		                          			
	}


}
