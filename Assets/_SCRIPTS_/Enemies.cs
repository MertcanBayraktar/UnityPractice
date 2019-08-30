using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemies : MonoBehaviour
{
	public Animator anim;
	public string enemyName;
	public float enemyHP;
	public int enemyDamage;
	public GameObject enemy;
	float distanceBetween;
	GameObject player;
	public int enemyGoldAmount = 10;
	characterPROP charplayer;

	public GameObject blueItem;
	public GameObject greenItem;
	public GameObject legendary;

	int RNG;
	public Vector3 getPosition()
	{
		return transform.position;
	}

	void Start()
	{
		enemyHP += Wave.instance.waveLevel * 100;
		anim = enemy.GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	void Update()

	{
		distanceBetween = Vector3.Distance(player.transform.position, enemy.transform.position);
		if (distanceBetween == 1f)
		{
			//enemy.Play("Attack") animasyonunu yap
		}
	}

	public void TakeDamage(float amount)
	{
		enemyHP -= amount;
		if (enemyHP <= 0)
		{
			Destroy(gameObject);
			GenerateRNG();
			characterPROP.instance.addGold(enemyGoldAmount);
			UI_FX_From.instance.FromTo();
		}
	}

	void GenerateRNG()
	{
		RNG = Random.Range(1, 100);
		if(RNG <= 25)
		{
			Debug.Log("Monster Dropped Green Item");
			Debug.Log(RNG);
			Instantiate(greenItem, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
		}
		else if(RNG > 25 && RNG <= 35)
		{
			Debug.Log("Monster dropped Blue Item");
			Debug.Log(RNG);
			Instantiate(blueItem, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
		}
		else if(RNG > 36 && RNG <= 40)
		{
			Debug.Log("Monster dropped LEGENDARY");
			Debug.Log(RNG);
			Instantiate(legendary, new Vector3(transform.position.x,transform.position.y+1,transform.position.z), transform.rotation);
		}
		else if(RNG > 40)
		{
			Debug.Log("Dropped Nothing");
			Debug.Log(RNG);
			
		}
	}
}
