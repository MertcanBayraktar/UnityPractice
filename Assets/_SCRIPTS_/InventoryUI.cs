
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	Inventory inventory;
	public GameObject inventoryUI;
	public Transform itemsParent;
	InventorySlot[] slots;
    void Start()
    {
		inventory = Inventory.instance;
		inventory.onItemChangedCallBack += UpdateUI;
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

 
    void Update()
    {
		if (Input.GetButtonDown("Inventory"))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}
    }
	void UpdateUI()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if(i < inventory.items.Count)
			{
				slots[i].AddItem(inventory.items[i]);
			}
			else
			{
				slots[i].clearSlot();
				ClearAttributes();
			}
		}


	}
	void ClearAttributes()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			slots[i].Damage.text = "";
			slots[i].Name.text = "0";
			slots[i].Level.text = "0";
			slots[i].classIcon.sprite = null;
			slots[i].itemWorth.text = "0";
			slots[i].upgradeCost.text = "";
			slots[i].upgradeButton.interactable = false;
		}
	}
}
