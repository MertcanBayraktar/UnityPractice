using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCheck : MonoBehaviour
{
	public bool Triggered = false;
	private void LateUpdate()
	{
		if(Triggered == false)
		{
			movementMAIN main = gameObject.GetComponent<movementMAIN>();
			main.focus = null;
		}
	}
}