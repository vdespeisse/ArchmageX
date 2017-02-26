using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Teleport : NetworkBehaviour {

	Vector3 currentPosition;
	Vector3 targetPosition;

	public float cd;
	public float cdTimer;


	public float maxRange = 10f;

	
	void Start () {
		
	}
	
	void Update () {

		if(cdTimer >0)
		{
			cdTimer -= Time.deltaTime;
		}
		if(cdTimer < 0)
		{
			cdTimer = 0;
		}





		//currentPosition = transform.position;
		if (!isLocalPlayer) {return;}

		if(Input.GetKeyDown(KeyCode.S) && cdTimer == 0) {
			setTargetPosition();
			blink();
			cdTimer = cd;
		}
	}

	void setTargetPosition(){
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
		float point = 0f;
		
		if(plane.Raycast(ray, out point))
			targetPosition = ray.GetPoint(point);
	}
	void blink(){
		gameObject.GetComponentInParent<PlayerMovement>().targetPosition = targetPosition;
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


		

