using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hackAndSlashCam : MonoBehaviour
{
	public Transform target;
	public float runDistance;
	public float walkDistance;
	public float height;
	private Transform _myTransform;
    void Start()
    {
		if (target == null)
		{
			Debug.LogWarning("We do not have a target to look at ");
		}
		_myTransform = transform;
    }
    void Update()
    {
        
    }
	void LateUpdate()
	{
		_myTransform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - walkDistance);
		_myTransform.LookAt(target);
	}
}
