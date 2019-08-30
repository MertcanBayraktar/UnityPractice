using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
	Item item;
	public Image icon;
	public Button removeButton;
	public Button upgradeButton;
	
	public Text Damage;
	public Text Name;
	public Image classIcon;
	public Text Level;
	public Text itemWorth;
	public Text upgradeCost;
	public void AddItem(Item newItem)
	{
		item = newItem;
		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;

	}
	private void Update()
	{
		Damage.text = item.Damage.ToString();
		Name.text = item.name.ToString();
		Level.text = item.Level.ToString();
		classIcon.sprite = item.classIcon;
		itemWorth.text = item.itemWorth.ToString();
		upgradeCost.text = item.upgradeCost.ToString();
		if (characterPROP.instance.playerGold < item.upgradeCost)
		{
			upgradeButton.interactable = false;
		}
		else
		{
			upgradeButton.interactable = true;
		}

	}

	public void clearSlot()
	{
		item = null;
		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
	}
	public void OnRemoveButton()
	{
		Inventory.instance.Remove(item);
		
	}
	public void UseItem()
	{
		if(item != null)
		{
			item.Use();
			Inventory.instance.Remove(item);
		}
	}
	public void onUpgradeButton()
	{
			item.addLevel();
	}
	public void OnSellButton()
	{
		characterPROP.instance.playerGold += item.itemWorth;
		Inventory.instance.Remove(item);

	}
}
