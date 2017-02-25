using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Fireball : NetworkBehaviour {

	public GameObject fireballPrefab;

	public float speed = 10f;

	private Vector3 targetPosition;




	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) {return;}
		if(Input.GetMouseButtonDown(0)) {
			setTargetPosition();
			CmdShoot();

		}
	}

	[Command]
	void CmdShoot(){

		GameObject fireball;
		Vector3 direction = Vector3.Normalize (targetPosition - transform.position);
		Vector3 offset = new Vector3 (0, 0.5f, 0);

		fireball = Instantiate(fireballPrefab, transform.position+direction+offset, transform.rotation) as GameObject;

		fireball.GetComponent<Rigidbody>().velocity = direction * speed;
		NetworkServer.Spawn (fireball);
		Destroy(fireball, 3f);

	}
	void setTargetPosition(){
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
		float point = 0f;
		
		if(plane.Raycast(ray, out point))
			targetPosition = ray.GetPoint(point);
	}
}
