 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkSync: Photon.MonoBehaviour {

	private Vector3 correctPlayerPos = Vector3.zero;
	private Quaternion correctPlayerRot = Quaternion.identity;
	private PlayerController player;
	private bool initialUpdate= true;
	void Awake() {
		player = GetComponent<PlayerController> ();
	}
	void Start() {

		Debug.Log (player);
		if (photonView.isMine)
			 {
					 //MINE: local player, simply enable the local scripts
					player.enabled = true;
			 }
			 else
			 {
					 player.enabled = false;

			 }
			player.isRemote = (!photonView.isMine);
	}



	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);


		}
		else
		{
			// Network player, receive data
			correctPlayerPos = (Vector3)stream.ReceiveNext();
			correctPlayerRot = (Quaternion)stream.ReceiveNext();

			if (initialUpdate)
					 {
							 initialUpdate = false;
							 transform.position = correctPlayerPos;
							 transform.rotation = correctPlayerRot;
					 }


		}
	}



	void Update()
	{
		if (!photonView.isMine)
		{
			transform.position = Vector3.Lerp(transform.position, correctPlayerPos, Time.deltaTime * 5);
			transform.rotation = Quaternion.Lerp(transform.rotation, correctPlayerRot, Time.deltaTime * 5);


		}
	}
}
