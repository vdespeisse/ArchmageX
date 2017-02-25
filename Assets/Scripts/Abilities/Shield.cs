using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public float duration;
	float timer;
	public GameObject shield;


	void Start () {
		timer = duration;
	}

	void Update () {
		timer -= Time.deltaTime;


		if(Input.GetMouseButton(2))
		   ShieldActivate();

	}

	void ShieldActivate() {
		GameObject s;
		s = (GameObject)Instantiate (shield, transform.position, shield.transform.rotation);
	
	if (timer <= 0) 
		Destroy(s);

	}

	public void Death(){
	}
}
