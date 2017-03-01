using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {


	Vector3 targetPosition;
	private bool isFlying = false;
	private bool isAttached = false;
	public float hookSpeed = 18f;
	public float pullSpeed = 12f;
	public float maxrange = 7f;
	public GameObject hookPrefab;
	public GameObject owner;
	private GameObject hook;
	private Transform attachedTo_moving;
	Vector3 attachOffset;
	Vector3 attachedTo_static;



	void Start () {
		owner = gameObject;
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.A) && !isFlying) {
			CmdShoot();
			}
		if (Input.GetKeyUp (KeyCode.A))
			Detach ();


		if (attachedTo_moving != null) {
			transform.position = Vector3.MoveTowards (transform.position, attachedTo_moving.position + attachOffset, pullSpeed * Time.deltaTime);
		} else if (attachedTo_static != Vector3.zero) {
			transform.position = Vector3.MoveTowards (transform.position, attachedTo_static, pullSpeed * Time.deltaTime);
		}

		if (hook == null) {
			isFlying = false;
		}


	}

	void CmdShoot() {
		setTargetPosition ();
		Vector3 direction = Vector3.Normalize (targetPosition - transform.position);
		Vector3 offset = new Vector3 (0, 0.5f, 0);

		hook = Instantiate(hookPrefab, transform.position+direction+offset, transform.rotation) as GameObject;
		hook.GetComponent<Rigidbody>().velocity = direction * hookSpeed;
		hook.GetComponent<Projectile> ().owner = owner;
		hook.GetComponent<Projectile> ().startPosition = transform.position;
		isFlying = true;

	}
	void setTargetPosition(){
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
		float point = 0f;
		
		if(plane.Raycast(ray, out point))
			targetPosition = ray.GetPoint(point);
	}

	public void attachOn_moving(Transform contactTransform, Vector3 offset) {
		
		attachedTo_moving = contactTransform;
		owner.GetComponent<PlayerController> ().stopMove ();
	}
	public void attachOn_static(Vector3 contactPoint){
		attachedTo_static = contactPoint;
		owner.GetComponent<PlayerController> ().stopMove ();
	}

	void Detach() {
		Destroy (hook);
		attachedTo_static = Vector3.zero;
		attachedTo_moving = null;
	}
}
