using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour {
	


	private Image currentHealthbar;
	private Text ratioText;
	private GameObject g;
		
	private float hitpoint  =150f;
	private float maxHitpoint = 150f;
	
	private void Start() {

		GameObject g = GameObject.FindGameObjectWithTag("HPImage");
		GameObject t = GameObject.FindGameObjectWithTag("textImage");

		if(g != null)
		{
			currentHealthbar = g.GetComponent<Image>();
		}

		if(t != null)
		{
			ratioText = t.GetComponent<Text>();
		}


	}
	
	private void UpdateHealthbar() {
		
		float ratio = hitpoint / maxHitpoint;
		currentHealthbar.rectTransform.localScale = new Vector3(ratio,1,1);
		ratioText.text = (ratio*100).ToString("0")  + '%';
	}
	
	private void TakeDamage(float damage) {
		
		hitpoint -= damage;
		if(hitpoint < 0)
		{
			hitpoint = 0;
			Debug.Log ("Dead!");
		}
		UpdateHealthbar();

	}
	
	private void HealDamage(float heal) {
		
		hitpoint += heal;
		if(hitpoint > maxHitpoint)
		{
			hitpoint = maxHitpoint;
		}
		UpdateHealthbar();

	}

}
