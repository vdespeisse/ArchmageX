using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	[HideInInspector]
	public Vector3 targetPosition;
	private bool isMoving = false;
	private float moveSpeed = 10;


	public const float maxHealth = 100;
	public const float maxMana = 100;


	public float currentHealth = maxHealth;
	public float currentMana = maxMana;


	private float healthBarSize;
	public RectTransform healthBar;
	public Image currentHealthbar;
	public Text hpRatioText;

	public RectTransform manaBar;
	public Image currentManaBar;
	public Text manaRatioText;



	PhotonView view;


	void Start () {
		healthBarSize = healthBar.sizeDelta.x;

		view = GetComponent<PhotonView>();

	}


	 void Update () {

		if(Input.GetMouseButton(1))
			setTargetPosition();

		if(isMoving)
		{
			if(view.isMine)
				move();

		}
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
	void move() {
	
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
	public void TakeDamage(float amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0) {
			currentHealth = 0;
			Destroy (gameObject);
			Debug.Log ("Dead!");
		} else if (currentHealth > maxHealth)
			currentHealth = maxHealth;


	}
	public void HealDamage(float heal) {
		TakeDamage (-heal);
	}

	public void updateHpBar(float health) { //t sensé mettre quoi ds health  pr call la method ?
		float ratio = (currentHealth - health) / maxHealth;
		Vector3 newScale = new Vector3(ratio,1,1);
		healthBar.localScale = newScale;
		currentHealthbar.rectTransform.localScale = newScale;
		hpRatioText.text = (ratio*100).ToString("0")  + '%';
	}

	public void updateManaBar(float mana) {
		float ratio = mana / maxMana;
		Vector3 newScale = new Vector3(ratio,1,1);
//		manaBar.localScale = newScale;
		currentManaBar.rectTransform.localScale = newScale;
		manaRatioText.text = (ratio*100).ToString("0")  + '%';
		
	}
}
