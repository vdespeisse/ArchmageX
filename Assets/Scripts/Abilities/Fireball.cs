using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public GameObject bullet;

	public float speed = 10f;

	private Vector3 targetPosition;




	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			setTargetPosition();
			shoot();

		}
	}

	void shoot(){

		GameObject g;

		g = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		g.transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);// marche pas ...
		Destroy(g, 3f);

	}
	void setTargetPosition(){
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
		float point = 0f;
		
		if(plane.Raycast(ray, out point))
			targetPosition = ray.GetPoint(point);
	}
}
