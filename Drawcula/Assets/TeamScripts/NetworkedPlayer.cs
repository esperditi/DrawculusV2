using UnityEngine;
using System.Collections;

public class NetworkedPlayer : MonoBehaviour {

	string _room = "DrawculaTest";

	//On startup connect to photon network 
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("0.1");
	}

	//Join online cloud lobby and specified room
	void OnJoinedLobby() {
		Debug.Log ("joined lobby");

		RoomOptions roomOptions = new RoomOptions() {};
		PhotonNetwork.JoinOrCreateRoom (_room, roomOptions, TypedLobby.Default);
	}

	//After connecting to room in lobby, instantiate the player
	void OnJoinedRoom() {
		//PhotonNetwork.Instantiate ("BGPlayerController", Vector3.zero, Quaternion.identity, 0);
	}
}
