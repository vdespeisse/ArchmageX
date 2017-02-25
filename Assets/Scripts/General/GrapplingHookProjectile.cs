using UnityEngine;
using System.Collections;

public class GrapplingHookProjectile : Projectile
{
	
	Transform attachedTo_moving;
	Vector3 offset;
	Vector3 attachedTo_static;
	GrapplingHook GrapplingHookScript;
	Transform origin;
	public override void Start () {
		GrapplingHookScript = owner.GetComponent<GrapplingHook> ();
		origin = transform.GetChild (0);

		destroyOnHit = false;
		base.Start ();
	}
	public override void Update ()
	{
		

		base.Update ();
		origin.position = owner.transform.position;
		if (attachedTo_moving != null)
			transform.position = attachedTo_moving.position + offset;
		else if (attachedTo_static != Vector3.zero)
			transform.position = attachedTo_static;


	}
	protected override void OnCollisionEnter(Collision collision) {
		base.OnCollisionEnter (collision);
		var hit_HeroManager = hit.GetComponent<HeroManager>();
		Vector3 contactPoint = collision.contacts [0].point;
		if (hit_HeroManager != null) 
			attachOn_moving (contactPoint, hit.transform);
		else
			attachOn_static (contactPoint);
	

	}
	public void attachOn_moving(Vector3 contactPoint, Transform contactTransform){
		attachedTo_moving = contactTransform;
		offset = contactPoint - contactTransform.position;
		GrapplingHookScript.attachOn_moving (contactTransform, offset);
	}

	public void attachOn_static(Vector3 contactPoint){
		attachedTo_static = contactPoint;
		GrapplingHookScript.attachOn_static (contactPoint);
	}
}

