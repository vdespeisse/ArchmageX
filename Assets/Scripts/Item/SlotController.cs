using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}
	public void MouseEnter() {
		transform.parent.GetComponent<InventaryController>().selectedSlot = this.transform;
	}

	public void MouseExit(){
		transform.parent.GetComponent<InventaryController>().selectedSlot =null;
		
	}
}
