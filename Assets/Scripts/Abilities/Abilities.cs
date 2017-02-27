 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour {

	public GameObject shield;


	void Start () {
		
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.F))
		   Ability1();
	}

	void Ability1() {

		GameObject g = (GameObject)Instantiate(shield, transform.position, shield.transform.rotation);
		Shield s = g.GetComponent<Shield>();
		s.myOwner = this.gameObject;
	}
}
