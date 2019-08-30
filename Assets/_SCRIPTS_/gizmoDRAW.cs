using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmoDRAW : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
			Gizmos.color = Color.red;
			Vector3 direction = transform.TransformDirection(Vector3.forward) * 25;
			Gizmos.DrawRay(transform.position, direction);
    }
}
