using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Ability : MonoBehaviour
{
	protected float cooldown = 0;
	protected float timeSinceCast;
	protected Vector3 targetPosition;

	// Use this for initialization
	protected virtual void Start ()
	{
		timeSinceCast = cooldown;

	}
	
	// Update is called once per frame
	protected virtual void Update ()
	{
		timeSinceCast += Time.deltaTime;
	
	}
	protected void setTargetPosition(){
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
		float point = 0f;

		if(plane.Raycast(ray, out point))
			targetPosition = ray.GetPoint(point);
	}

	protected void ClickAbility() {
		Debug.Log ("Casted");
		if (timeSinceCast >= cooldown) {
			Cast ();
			timeSinceCast = 0;
		} else
			Debug.Log ("Ability On CD");
	}
	protected virtual void Cast(){
	}
}

