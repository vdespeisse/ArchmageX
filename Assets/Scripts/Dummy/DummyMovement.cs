using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DummyMovement : NetworkBehaviour {

	private float speed = 10;

	public Vector3 targetPosition;
	private bool isMoving;
	private float timeSinceMoved = 0;

	void Awake() {

		Bounds bounds = GameObject.Find("Ground").GetComponent<MeshCollider>().bounds;

	}
	void Start () {
		




		isMoving = false;	
	}


	void Update () {
		
		timeSinceMoved += Time.deltaTime;
		if (timeSinceMoved >= 2.0f) {
			setTargetPosition ();
			timeSinceMoved = 0;
		}
		

		if(isMoving)
			move();
	}

	void setTargetPosition(){
		targetPosition = new Vector3 (Random.Range (-8, 8), 1, Random.Range (-8, 8));

		isMoving = true;
	}
	void move(){
		transform.LookAt(targetPosition);
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

		if(transform.position == targetPosition)
			isMoving = false;
		
	}


}
