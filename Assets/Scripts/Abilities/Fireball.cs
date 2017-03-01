using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public string fireballPrefab  = "Fireball";
	public GameObject owner;
	private PhotonView view;

	public float speed = 10f;

	private Vector3 targetPosition;




	// Use this for initialization
	void Start () {
		owner = gameObject;
		view = GetComponent<PhotonView>();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) 
			if(view.isMine){
				setTargetPosition();
				CmdShoot();
			}


	}

	void CmdShoot(){

		Vector3 direction = Vector3.Normalize (targetPosition - transform.position);
		Vector3 offset = new Vector3 (0, 0.5f, 0);

		GameObject fireball = PhotonNetwork.Instantiate(fireballPrefab, transform.position + direction + offset, transform.rotation, 0);

		fireball.GetComponent<Rigidbody>().velocity = direction * speed;
		fireball.GetComponent<Projectile> ().owner = owner;
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
