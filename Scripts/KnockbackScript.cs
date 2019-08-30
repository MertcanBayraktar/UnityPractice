using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackScript : MonoBehaviour
{
	Animator anim;
	private void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
	
	}
	private void Update()
	{
		anim.Play("knockback");
	}
	void PlayKnockbackEffect()
	{
		anim.Play("knockBackRifle");
	}
}
