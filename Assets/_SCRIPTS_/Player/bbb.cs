using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbb : MonoBehaviour
{

	private Vector3 mousePos;
	private float lastAngle;
	public float rotation;
	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Plane plane = new Plane(Vector3.up, Vector3.zero);
		float distance;
		if (plane.Raycast(ray, out distance))
		{
			Vector3 target = ray.GetPoint(distance);
			Vector3 direction = target - transform.position;
			rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0, rotation, 0);
		}
	}
}
