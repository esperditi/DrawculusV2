using UnityEngine;
using System.Collections;

public class NetworkController : MonoBehaviour {

	string _room = "DrawculaTest";

	//On startup connect to photon network 
	void Start () {
		Debug.Log ("Connecting to Photon Server for Drawcula Project");
		PhotonNetwork.ConnectUsingSettings ("0.1");
		Debug.Log ("Connection to Photon Server successful!");
	}

	//Join online cloud lobby and specified room
	void OnJoinedLobby() {
		Debug.Log ("Joined Lobby for Drawcula Project");
		RoomOptions roomOptions = new RoomOptions() {};
		PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
	}

	//After connecting to room in lobby, instantiate the player
	void OnJoinedRoom() {
		PhotonNetwork.Instantiate ("NetworkedPlayer", Vector3.zero, Quaternion.identity, 0);
	}
}