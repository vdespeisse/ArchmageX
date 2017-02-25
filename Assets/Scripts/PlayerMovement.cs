using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

	private float speed = 10;

	private Vector3 targetPosition;
	private bool isMoving;



	void Start () {

		isMoving = false;	
	}


	void Update () {
		if (!isLocalPlayer) {return;}

		if(Input.GetMouseButton(1))
			setTargetPosition();

		if(isMoving)
			move();
	}

	void setTargetPosition(){
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
		float point = 0f;

		if(plane.Raycast(ray, out point))
			targetPosition = ray.GetPoint(point);

		isMoving = true;
	}
	void move(){
		transform.LookAt(targetPosition);
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

		if(transform.position == targetPosition)
			isMoving = false;
		Debug.DrawLine(transform.position, targetPosition, Color.red);
 	 }


}
