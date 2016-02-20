using UnityEngine;
using System.Collections;

public class NetworkedPlayer : Photon.MonoBehaviour {

	public GameObject avatar;
	public Transform playerGlobal;	//where the avatar is in space
	public Transform playerLocal;	//avatar head movements

	void Start () {
		Debug.Log ("I'm instantiated");

		//only if we're the player
		if(photonView.isMine)
		{
			playerGlobal = GameObject.Find("FPSController").transform;
			playerLocal = playerGlobal.Find ("FirstPersonCharacter");

			//associate camera with avatar
			this.transform.SetParent(playerLocal);

			this.transform.localPosition = Vector3.zero;	//center the cube on the camera

			//hide the avatar from ourselves (uncomment to toggle this)
			//avatar.SetActive(false);
		}
	}

	//Get new data and send to all players in room
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		//our player sending information out to players
		if (stream.isWriting)
		{
			stream.SendNext(playerGlobal.position);
			stream.SendNext(playerGlobal.rotation);
			stream.SendNext(playerLocal.localPosition);
			stream.SendNext(playerLocal.localRotation);
		}
		else    //our player recieving information from other players
		{
			this.transform.position = (Vector3)stream.ReceiveNext();
			this.transform.rotation = (Quaternion)stream.ReceiveNext();
			avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
			avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();
		}
	}
}
