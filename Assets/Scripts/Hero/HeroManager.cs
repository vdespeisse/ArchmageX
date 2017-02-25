using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroManager : MonoBehaviour {

	public const float maxHealth = 100;
	public float currentHealth = maxHealth;
	public RectTransform healthBar;
	private float healthBarSize;

	public void Start() {
		healthBarSize = healthBar.sizeDelta.x;
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Destroy (gameObject);
			Debug.Log("Dead!");
		}
		float ratio = currentHealth/maxHealth;
		healthBar.sizeDelta = new Vector2(healthBarSize*ratio, healthBar.sizeDelta.y);
		Debug.Log (healthBar.sizeDelta);
	}
}
