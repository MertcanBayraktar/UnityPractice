using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class navmeshEnemy : MonoBehaviour
{
	#region Singleton
	public static navmeshEnemy instance;
	private void Awake()
	{
		instance = this;
	}
	#endregion
	public NavMeshAgent agentEnemy;
	GameObject player;
	Transform playerPosition;
	public Transform temporaryLocation;
	public Animator anim;
	public bool TookDamage = false;
    void Start()
    {
		anim = GetComponent<Animator>();
		agentEnemy.GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");
		playerPosition = player.transform;
		NavMeshHit closestHit;
		if (NavMesh.SamplePosition(agentEnemy.transform.position, out closestHit, 500f, NavMesh.AllAreas))
			agentEnemy.transform.position = closestHit.position;
		else
			Debug.LogError("Could not find position on NavMesh!");
	}


    // Update is called once per frame
    void Update()
    {
		agentEnemy.SetDestination(playerPosition.position);
		if(agentEnemy.velocity !=Vector3.zero)
		{
			anim.Play("Walking");
		}
		else
		{
			anim.Play("Idle");
		}
    }
}
