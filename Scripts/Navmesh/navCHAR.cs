using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class navCHAR : MonoBehaviour
{
	Transform[] enemyTransform;
	public NavMeshAgent agent;
	GameObject[] enemies;
	Animator anim;
	
    void Start()
    {
		anim = GetComponent<Animator>();
		enemyTransform = new Transform[enemies.Length];
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		for (int i = 0; i < enemies.Length; i++)
		{
			enemyTransform[i] = enemies[i].transform;
		}
		if (enemies.Length == 0)
			Debug.Log("no enemies");
		else
			Debug.Log(enemies.Length);
	}

    void Update()
    {
			Transform closestEnemy = GetClosestEnemy(enemyTransform);
			agent.SetDestination(closestEnemy.position);
	}
	Transform GetClosestEnemy(Transform[] enemies)
	{
		Transform bestTarget = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = transform.position;
		foreach (Transform potentialTarget in enemies)
		{
			Vector3 directionToTarget = potentialTarget.position - currentPosition;
			float dSqrToTarget = directionToTarget.sqrMagnitude;
			if (dSqrToTarget < closestDistanceSqr)
			{
				closestDistanceSqr = dSqrToTarget;
				bestTarget = potentialTarget;
			}
		}

		return bestTarget;
	}
}
