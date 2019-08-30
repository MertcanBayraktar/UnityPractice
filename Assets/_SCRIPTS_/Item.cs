using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
	new public string name = "New Item";
	public Sprite icon = null;
	public bool isDefaultItem = false;
	public float Damage;
	public int Level = 1;
	public Sprite classIcon = null;
	public float itemWorth;
	public float upgradeCost = 10;
	void Start()
	{
	}
	public virtual void Use()
	{
		if(name == "explosive")
		{ 
			Shooting.instance.explosiveBullets = true;
		}
		Debug.Log("Using : " + name);
	}

	public void addLevel()
	{

		characterPROP.instance.playerGold -= upgradeCost;
		Level++;
		itemWorth = (Level * 1.5f);
		upgradeCost = (Level * 2f);
		Damage = (Level * 2.5f);
	}
	public void SetExplosiveFalse()
	{
		Shooting.instance.explosiveBullets = true;
	}
}
