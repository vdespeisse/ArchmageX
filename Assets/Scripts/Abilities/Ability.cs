using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Ability : MonoBehaviour
{
	protected float cooldown = 0;
	protected float timeSinceCast;
	protected Vector3 targetPos;

	protected float EnergyCost;
	protected float currentMana = 100f;
	protected float maxMana = 100f;

	private bool hasEnoughMana = true;
	private bool canCast = true;


	// Use this for initialization
	protected  void Start ()
	{
		timeSinceCast = cooldown;

	}
	
	// Update is called once per frame
	protected  void Update ()
	{
		timeSinceCast += Time.deltaTime;


	}

	protected void setTargetPosition(){
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
		float point = 0f;

		if(plane.Raycast(ray, out point))
			targetPos = ray.GetPoint(point);
	}

	protected void ClickAbility() {
		PlayerController go = GameObject.FindWithTag("Player").GetComponent<PlayerController>();


		
		if ((timeSinceCast >= cooldown) &&(hasEnoughMana)) 
		{
			currentMana -= EnergyCost; // currentMana is always = to 100 jdois store la mana qque part somehow
			go.updateManaBar(currentMana);
			//Cast();
			timeSinceCast = 0;

		}  
		if ((timeSinceCast >= cooldown) && (!hasEnoughMana))
		{
			print ("Has not enough Mana !");
		}
		else if((timeSinceCast < cooldown) && (hasEnoughMana))
		{
			print ("Ability is On CD");
		}
			
	}

	protected void Cast(){
		
		if(canCast)
		{

			//TODO


		}
		 

	}

	protected void ManaHandler(float cost) {
		EnergyCost = cost;


		if(EnergyCost <= currentMana)
			hasEnoughMana = true;
		else 
		{
			hasEnoughMana = false;
		}
	
		if(currentMana >= maxMana)
			currentMana = maxMana;


		


	}
}

