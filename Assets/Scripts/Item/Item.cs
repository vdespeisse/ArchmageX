using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public string name;
	public Sprite sprite;



	void Start () {
		//this.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);

	}
	
	void Update () {
		
	}
	public void MouseEnter() {

		transform.parent.parent.GetComponent<InventaryController>().selectedItem = this.transform;
	}

	public void MouseExit(){

		if(!transform.parent.parent.GetComponent<InventaryController>().canDragItem)
			transform.parent.parent.GetComponent<InventaryController>().selectedItem =null;

	}
}
