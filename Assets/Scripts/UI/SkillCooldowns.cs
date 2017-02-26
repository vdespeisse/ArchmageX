using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SkillCooldowns : MonoBehaviour {

	public List<Skill> skills;





	void Start()
	{
		foreach (Skill x in skills)
		{             
			x.currentCooldown = x.cooldown;         
		}
	}


	 void FixedUpdate()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			
			if(skills[0].currentCooldown >= skills[0].cooldown)
			{
				Debug.Log("qpressed");
				skills[0].currentCooldown = 0;
				
			}
			
			
		}
		
		
		else if (Input.GetKeyDown (KeyCode.S)) 
		{
			
			if(skills[1].currentCooldown >= skills[1].cooldown)
			{
				Debug.Log("Spressed");
				skills[1].currentCooldown = 0;
				
			}
			
		}
		
		else if (Input.GetKeyDown (KeyCode.D)) 
		{
			if(skills[2].currentCooldown >= skills[2].cooldown)
			{
				Debug.Log("Dpressed");
				skills[2].currentCooldown = 0;
				
			}
			
		}


		//print(QonCD);
		foreach (Skill s in skills) 
		{

			if(s.currentCooldown < s.cooldown)
			{
				s.currentCooldown += Time.deltaTime;
				s.skillIcon.fillAmount = s.currentCooldown / s.cooldown; 
			}


		}

	}

}

[System.Serializable]
public class Skill
{
	public float cooldown; 
	public Image skillIcon;
	[HideInInspector]
	public float currentCooldown;
}
