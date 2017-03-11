 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventaryController : MonoBehaviour {

	public Transform selectedItem, selectedSlot, originalSlot;
	public GameObject slotPrefab, itemPrefab;
	public Vector2 inventorySize = new Vector2(3,2);
	public Vector2 windowSize;

	public bool canDragItem = false;

	void Start () {
		for(int x = 1; x <= inventorySize.x; x++){
			for(int y = 1; y <= inventorySize.y; y++)
			{
				GameObject slot = Instantiate(slotPrefab) as GameObject;
				slot.transform.SetParent(this.transform, false);
				slot.name = "slot_"+x+":"+y;
				slot.GetComponent<RectTransform>().anchoredPosition = new Vector3(windowSize.x /(inventorySize.x+1)*x, windowSize.y/(inventorySize.y+1)*-y, 0);

				if((x+(y-1)*3) <= ItemDatabase.itemList.Count)
				{
					GameObject item = Instantiate(itemPrefab) as GameObject;
					item.transform.parent = slot.transform;
					item.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
					Item i = item.GetComponent<Item>();

					//ITEM COMPONENT VARIABLES
					i.name = ItemDatabase.itemList[(x+(y-1)*3) -1].name;
					i.sprite = ItemDatabase.itemList[(x+(y-1)*3) -1].sprite;

					item.name = i.name;
					item.GetComponent<Image>().sprite = i.sprite;

				}

			}
		}
	} 
	
	void Update () {

	

		if(Input.GetMouseButtonDown(0) && selectedItem != null)
		{
		
			canDragItem = true;

			originalSlot = selectedItem.parent;
			selectedItem.GetComponent<EventTrigger>().enabled = false;
			SetItemsEvents(false);



		}
			

		if(Input.GetMouseButton (0)  && selectedItem != null && canDragItem) {
			selectedItem.GetComponent<CanvasGroup>().blocksRaycasts = false;

//			selectedSlot.GetComponent<Image>().raycastTarget=false;
			selectedItem.position = Input.mousePosition; //bug kan le cursor va plus vite que l'item

		}

		else if (Input.GetMouseButtonUp(0) && selectedItem != null){      
			//			selectedSlot.GetComponent<Image>().raycastTarget=true;
			selectedItem.GetComponent<CanvasGroup>().blocksRaycasts = true;
			canDragItem = false;            
			SetItemsEvents(true);  

			if (selectedSlot == null)            
			{                 
				selectedItem.parent = originalSlot; 
			}             
			else if(selectedSlot.childCount > 0)  
			{               
				selectedSlot.GetChild(0).parent = originalSlot; 
				selectedItem.parent = selectedSlot;               
				originalSlot.GetChild(0).localPosition = Vector3.zero;   
			}             
			else if (selectedSlot.childCount == 0)           
			{              
				   selectedItem.parent = selectedSlot;    
			}  

			selectedItem.localPosition = Vector3.zero;            
			selectedItem.GetComponent<EventTrigger>().enabled = true;        
		}
	}

	void SetItemsEvents(bool b) {
		foreach(GameObject item in GameObject.FindGameObjectsWithTag("Item")){
			item.GetComponent<EventTrigger>().enabled = b;
			print(b);

		}
	}
}
