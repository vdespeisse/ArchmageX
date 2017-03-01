using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	[HideInInspector]
	public GameObject owner;
	[HideInInspector]
	public Vector3 startPosition;
	public bool destroyOnHit = true;
	public bool destroyOnHitUnit = true;
	public float maxRange = -1;
	public float maxDuration = 15f;
	[HideInInspector]
	public float aliveTime = 0;
	public int damage = 10;
	[HideInInspector]
	public GameObject hit;
	[HideInInspector]


	public virtual void Start() {

	}

	public virtual void Update() {
		if (hit != null) {
			
		}
		aliveTime += Time.deltaTime;
		if (maxRange != -1) {
			if (Vector3.Distance (startPosition, transform.position) > maxRange)
				Destroy (gameObject); 
		}
		if (maxDuration != -1) {
				if (aliveTime >= maxDuration) Destroy(gameObject);
		}

			

	}
	protected virtual void OnCollisionEnter(Collision collision)
	{
		hit = collision.gameObject;
		if (hit == owner) {
			hit = null;
			return;
		}

		var hit_HeroManager = hit.GetComponent<PlayerController>();
		if (hit_HeroManager != null)
			OnHitUnit (hit_HeroManager);
		else {
			if (destroyOnHit)
				Destroy (gameObject);
		}


	}
	public virtual void OnHitUnit(PlayerController heroManager){
		if (heroManager.currentHealth >= 0) {
			heroManager.TakeDamage (damage);
		}
	}
}