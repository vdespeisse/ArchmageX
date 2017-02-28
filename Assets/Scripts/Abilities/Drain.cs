using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drain : MonoBehaviour {

	private float damage = 1f;
	private PlayerController targetPlayer;
	private PlayerController owner;
	private RaycastHit hit;
	
	// Use this for initialization
	void Start () {

		owner = gameObject.GetComponent<PlayerController>();

	}

	void Update() {

		if(Input.GetKey(KeyCode.D)) {
			setTargetPlayer();
			if(targetPlayer !=null) {
				targetPlayer.TakeDamage(damage);
				owner.TakeDamage(-damage);
			}
		}


	}

	void setTargetPlayer() {

		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit))

		   
			targetPlayer = hit.transform.gameObject.GetComponent<PlayerController>();


	}

}
