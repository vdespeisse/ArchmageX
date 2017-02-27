using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	private float moveSpeed = 10;
	[HideInInspector]
	public Vector3 targetPosition;
	private bool isMoving = false;
	public const float maxHealth = 100;

	[SyncVar(hook = "OnChangeHealth")]
	public float currentHealth = maxHealth;
	public RectTransform healthBar;

	private float healthBarSize;



	void Start () {
		healthBarSize = healthBar.sizeDelta.x;
	}


	public virtual void Update () {
		if (!isLocalPlayer) {return;}

		if(Input.GetMouseButton(1))
			setTargetPosition();

		if(isMoving)
			move();
	}
	// MOVING STUFF
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
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

		if(transform.position == targetPosition)
			isMoving = false;
		Debug.DrawLine(transform.position, targetPosition, Color.red);
	}

	public void stopMove() {
		isMoving = false;
		targetPosition = transform.position;
	}

	// HEALTH STUFF
	public void TakeDamage(int amount)
	{
		if (!isServer) {return;}

		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Destroy (gameObject);
			Debug.Log("Dead!");
		}

	}

	void OnChangeHealth(float health) {
		float ratio = health/maxHealth;
		healthBar.sizeDelta = new Vector2(healthBarSize*ratio, healthBar.sizeDelta.y);
	}
}
