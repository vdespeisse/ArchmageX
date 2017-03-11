using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Ability {

	public string fireballPrefab  = "Fireball";
	public GameObject owner;
	private PhotonView view;


	GameObject fireball;

	public float speed = 10f;

	// Use this for initialization
	protected override void Start () {
		owner = gameObject;
		view = GetComponent<PhotonView>();
		manaCost = 10f;
		cooldown = 5f;


	}
	
	// Update is called once per frame
	protected override void Update () {
		if(Input.GetMouseButtonDown(0)) 
			if(view.isMine){
				setTargetPosition();
				ClickAbility();
			}
		base.Update();


	}

	protected override void Cast(){

		Vector3 direction = Vector3.Normalize (targetPosition - transform.position);
		Vector3 offset = new Vector3 (0, 0.5f, 0);

		fireball = PhotonNetwork.Instantiate(fireballPrefab, transform.position + direction + offset, transform.rotation, 0) as GameObject;

		fireball.GetComponent<Rigidbody>().velocity = direction * speed;
		fireball.GetComponent<Projectile> ().owner = owner;
		Destroy(fireball, 3f);

	}

	/***[PunRPC] //rpc call pr faire x sur tt les écrans
	void TesticuleCall(int viewID) {

		
		fireball = PhotonView.Find(viewID).gameObject;

		fireball.SendMessage("Testicule");

		if(GetComponent<PhotonView>().isMine)
		{
			view.RPC("TesticuleCall", PhotonTargets.OthersBuffered, viewID);
		}

	}***/
}
