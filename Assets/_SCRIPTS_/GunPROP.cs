using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunPROP : MonoBehaviour
{
	public string gunName;
	public int gunLevel = 1;
	public float gunBaseDamage = 50f;
	GameObject charprop;
	public int LevelCost = 3;
	public int BulletAmount = 30;
	public void addLevel()
	{
		if(GameObject.FindGameObjectWithTag("Player").GetComponent<characterPROP>().playerGold < LevelCost)
		{
			Debug.Log("You dont have enough Gold");
		}
		else
		{
			gunLevel++;
			GameObject.FindGameObjectWithTag("Player").GetComponent<characterPROP>().playerGold -= LevelCost;
			LevelCost += gunLevel + 4;
			gunBaseDamage += gunBaseDamage * 0.25f;
		}



	}
}
