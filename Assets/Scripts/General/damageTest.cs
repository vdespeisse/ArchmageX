using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageTest : MonoBehaviour {

	public bool isDamaging;
	public float damage = 10;
	void Start() {


	}

	private void OnTriggerStay(Collider col)
	{	

		var playerController = col.GetComponent<PlayerController> ();
		if (playerController != null) {

			float damageTaken = Time.deltaTime * damage;
			if (isDamaging){
				print("cdf");

				playerController.TakeDamage (damageTaken);
				playerController.updateHpBar(damage);

			}
				
			else {
				playerController.TakeDamage (-damageTaken);
				print("aa");


			}
				

		}
	}


}
