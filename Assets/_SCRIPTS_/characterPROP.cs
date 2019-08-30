using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class characterPROP : MonoBehaviour
{
	#region Singleton
	public static characterPROP instance;
	 void Awake()
	{
		if(instance != null)
		{
			Debug.Log("more than one player in the scene");
		}
		instance = this;
	}
	#endregion
	public const int charBaseHp = 100;
	public int charHP = 100;
	public float charDMG = 10;
	public float playerGold = 0;
	public Text textGOLD;
	GameObject currentGun;
	void Start()
	{
		playerGold = 0;
		currentGun = GameObject.FindGameObjectWithTag("Rifle");
	}
	 void Update()
	{
		textGOLD.text = playerGold.ToString();
	}
	public void addGold(int goldAmount)
	{
		playerGold += goldAmount;
	}
}

