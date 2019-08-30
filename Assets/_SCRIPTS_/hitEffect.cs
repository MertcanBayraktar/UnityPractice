using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEffect : MonoBehaviour
{
	public static hitEffect instance;
	void Awake()
	{
		if (instance != null)
		{
			Debug.Log("more than one player in the scene");
		}
		instance = this;
	}
	public GameObject enemyHitEffect;
	public GameObject defaultHitEffect;
	public void spawnDefaultHitEffect(Vector3 hitPosition,Transform hitTransform)
	{
		if(defaultHitEffect != null)
		{
			GameObject Flash = Instantiate(defaultHitEffect, hitPosition, Quaternion.identity);
			Destroy(Flash, 0.3f);
		}
	}
	public void spawnEnemyHitEffect(Vector3 hitPosition, Transform hitTransform)
	{
		if(enemyHitEffect != null)
		{
			GameObject Flash = Instantiate(enemyHitEffect, hitPosition, Quaternion.identity);
			Destroy(Flash,0.2f);
		}
	}
}
