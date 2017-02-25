using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Teleport : NetworkBehaviour {

	Vector3 currentPosition;
	Vector3 targetPosition;

	public float maxRange = 10f;

	
	void Start () {

	}
	
	void Update () {
		//currentPosition = transform.position;
		if (!isLocalPlayer) {return;}

		if(Input.GetKeyDown(KeyCode.S)) {
			setTargetPosition();
			blink();
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


		

