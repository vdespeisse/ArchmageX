using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Teleport : Ability {

	Vector3 currentPosition;



	public float maxRange = 10f;

	
	protected override void Start () {
		cooldown = 3f;
		base.Start ();

		
	}
	
	protected override void Update () {

		//currentPosition = transform.position;

		if (Input.GetKeyUp (KeyCode.S))
			ClickAbility ();
		base.Update ();

	}


	protected override void Cast(){
		setTargetPosition ();
		gameObject.GetComponentInParent<PlayerController>().targetPosition = targetPosition;
		if(Vector3.Distance(transform.position, targetPosition) <= maxRange) {
			transform.LookAt(targetPosition);
			transform.position =  targetPosition;
		}
		else {
			transform.LookAt(targetPosition);
			transform.position += Mathf.Min(maxRange, Vector3.Distance(targetPosition, transform.position)) * Vector3.Normalize(targetPosition - transform.position);

		}
		

	}
}


		

