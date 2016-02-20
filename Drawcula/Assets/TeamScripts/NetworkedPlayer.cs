using UnityEngine;
using System.Collections;

public class NetworkedPlayer : MonoBehaviour {

	string _room = "DrawculaTest";

	//On startup connect to photon network 
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("0.1");
	}
}
