using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class HeroManager : NetworkBehaviour {

	public const float maxHealth = 100;

	[SyncVar(hook = "OnChangeHealth")]
	public float currentHealth = maxHealth;
	public RectTransform healthBar;

	private float healthBarSize;

	public void Start() {
		healthBarSize = healthBar.sizeDelta.x;
	}

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
