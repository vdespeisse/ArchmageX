using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDatabase : MonoBehaviour {

	public static List<Item> itemList = new List<Item>();
	public Sprite[] sprites;

	void Start () {

		//ITEM CREATION
		Item i0 = new Item();
		i0.name = "fire";
		i0.sprite = sprites[0];
		itemList.Add(i0);

		//ITEM CREATION
		Item i1 = new Item();
		i1.name = "ice";
		i1.sprite = sprites[1];
		itemList.Add(i1);

//		//ITEM CREATION
//		Item i2 = new Item();
//		i2.name = "thunder";
//		i2.sprite = sprites[2];
//		itemList.Add(i2);
//
//		//ITEM CREATION
//		Item i3 = new Item();
//		i3.name = "root";
//		i3.sprite = sprites[3];
//		itemList.Add(i3);
//
//		//ITEM CREATION
//		Item i4 = new Item();
//		i4.name = "storm";
//		i4.sprite = sprites[4];
//		itemList.Add(i4);
//
//		//ITEM CREATION
//		Item i5 = new Item();
//		i5.name = "darkness";
//		i5.sprite = sprites[5];
//		itemList.Add(i5);

	}
	
	void Update () {
		
	}
}
