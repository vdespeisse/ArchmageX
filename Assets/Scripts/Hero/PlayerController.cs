using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Photon.MonoBehaviour {

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

	[HideInInspector]
	public bool isRemote;




	void Start () {
		healthBarSize = healthBar.sizeDelta.x;


	}


	 void Update () {
		if (isRemote) {
			return;
		}
		if(Input.GetMouseButton(1))
			setTargetPosition();

		if(isMoving)
		{
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
		if (!PhotonNetwork.isMasterClient) {
			return;
		}
		currentHealth -= amount;
		if (currentHealth <= 0) {
			currentHealth = 0;
			Destroy (gameObject);
			Debug.Log ("Dead!");
		} else if (currentHealth > maxHealth)
			currentHealth = maxHealth;
		photonView.RPC ("updateHealth", PhotonTargets.All, currentHealth);
		


	}
	public void HealDamage(float heal) {
		TakeDamage (-heal);
	}

	[PunRPC]
	public void updateHealth(float health) { //t sensé mettre quoi ds health  pr call la method ?
		currentHealth = health;
		float ratio = currentHealth / maxHealth;
		Vector3 newScale = new Vector3(ratio,1,1);
		healthBar.localScale = newScale;
		currentHealthbar.rectTransform.localScale = newScale;
		hpRatioText.text = (ratio*100).ToString("0")  + '%';
	}

	public void updateMana(float mana) {
		currentMana = mana;
		float ratio = mana / maxMana;
		Vector3 newScale = new Vector3(ratio,1,1);
//		manaBar.localScale = newScale;
		currentManaBar.rectTransform.localScale = newScale;
		manaRatioText.text = (ratio*100).ToString("0")  + '%';

	}
}
