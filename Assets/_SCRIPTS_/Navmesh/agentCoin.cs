using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class agentCoin : MonoBehaviour
{
	NavMeshAgent agent;
	GameObject playerPosition;
	void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		agent.updateUpAxis = false;
		agent.updateRotation = false;
		playerPosition = GameObject.FindGameObjectWithTag("Player");

	}

    // Update is called once per frame
    void Update()
    {
		agent.SetDestination(playerPosition.transform.position);
	}
}
