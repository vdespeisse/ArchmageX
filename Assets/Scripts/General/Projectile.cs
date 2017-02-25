using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public GameObject owner;

	void Start() {
	}

	void OnCollisionEnter(Collision collision)
	{
		var hit = collision.gameObject;
		if (hit == owner) {
			return;
		}
		var hitHero = hit.GetComponent<HeroManager>();
		if (hitHero.currentHealth  >= 0)
		{
			hitHero.TakeDamage(10);
		}

		Destroy(gameObject);
	}
}