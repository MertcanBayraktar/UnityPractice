using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeExplosion : MonoBehaviour
{
	private Collider[] hitColliders;
	public float blastRadius;
	public float explosionPower;
	public LayerMask explosionLayers;
	public GameObject explosion;
	private GameObject explosionPrefab;
	void OnCollisionEnter(Collision col)
	{
		explosionWork(col.contacts[0].point);
		explosionPrefab = Instantiate(explosion, transform.position, transform.rotation);
		foreach (Collider hitCol in hitColliders)
		{
			if(hitCol.gameObject.tag == "Enemy")
			{
				hitCol.GetComponent<Enemies>().enemyHP -= 100;
				Debug.Log("i hit");
			}
		}
		Destroy(explosionPrefab, 1f);
	}

	void explosionWork(Vector3 explosionPoint)
	{
		hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius,explosionLayers);
		foreach (Collider hitCol in hitColliders)
		{
			if(hitCol.GetComponent<Rigidbody>() != null)
			{
				hitCol.GetComponent<Rigidbody>().isKinematic = false;
				hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
			}
		}
	}
}
