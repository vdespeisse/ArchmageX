using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drain : Ability {

	private float damage = 10f;
	private PlayerController targetPlayer;
	private PlayerController owner;
	private RaycastHit hit;

	
	// Use this for initialization
	protected override void Start () {

		owner = gameObject.GetComponent<PlayerController>();
		manaCost =30f;
		cooldown = 3f;
		base.Start();
	}

	protected override void Update() {

		if(Input.GetKeyDown(KeyCode.D)) {
			if(photonView.isMine)
			{
				setTargetPlayer();
				ClickAbility();
				if(targetPlayer !=null) 
				{
					targetPlayer.TakeDamage(damage);
					owner.TakeDamage(-damage);
				}

			}
		}
		base.Update();


	}

	void setTargetPlayer() {

		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit))

		   
			targetPlayer = hit.transform.gameObject.GetComponent<PlayerController>();


	}

}
