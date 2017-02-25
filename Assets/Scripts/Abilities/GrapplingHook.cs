using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {


	Vector3 targetPosition;
	public bool isFlying = false;
	public float speed = 15f;



	void Start () {
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.A)) {
			setTargetPosition();
			isFlying = true;
			}


		if(isFlying) {
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed *Time.deltaTime);
			if(transform.position == targetPosition)
				isFlying =false;
		}

		
	}


	void setTargetPosition(){
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
		float point = 0f;
		
		if(plane.Raycast(ray, out point))
			targetPosition = ray.GetPoint(point);
	}
}
