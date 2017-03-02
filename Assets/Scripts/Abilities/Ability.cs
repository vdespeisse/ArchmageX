﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Ability : MonoBehaviour
{
	protected float cooldown = 0;
	protected float timeSinceCast;
	protected Vector3 targetPosition;

	protected float manaCost;
	protected float currentMana = 100f;
	protected float maxMana = 100f;


	// Use this for initialization
	protected virtual void Start ()
	{
		timeSinceCast = cooldown;

	}

	// Update is called once per frame
	protected virtual void Update ()
	{
		timeSinceCast += Time.deltaTime;


	}

	protected void setTargetPosition(){
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
		float point = 0f;

		if(plane.Raycast(ray, out point))
			targetPosition = ray.GetPoint(point);
	}

	protected void ClickAbility() {
		PlayerController player = GetComponent<PlayerController>();

		
		if ((timeSinceCast >= cooldown) && (currentMana >= manaCost)) 
		{
			
			player.currentMana -= manaCost; // currentMana is always = to 100 jdois store la mana qque part somehow
			player.updateMana(player.currentMana);
			Cast();
			timeSinceCast = 0;

		}  
		else if (currentMana < manaCost)
		{
			print ("Has not enough Mana !");
		}
		else if(timeSinceCast < cooldown)
		{
			print ("Ability is On CD");
		}
			
	}

	protected virtual void Cast(){
		
		 

	}

}

