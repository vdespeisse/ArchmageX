using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public GameObject fireball;
	public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			GameObject g;
			g = Instantiate(fireball, transform.position, transform.rotation) as GameObject;

			Rigidbody r;
			r = g.GetComponent<Rigidbody>();

			r.AddForce(transform.forward * speed);

			Destroy(g, 1f);
		}
	}

}
