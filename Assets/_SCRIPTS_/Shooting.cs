using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	#region Singleton
	public static Shooting instance;
	private void Awake()
	{
		if (instance != null)
		{
			Debug.Log("more than one shooting script");
		}
		instance = this;
	}
	#endregion
	public Transform barrelEnd;
	public float bulletDamage;
	public float fireRate = 15f;
	public ParticleSystem muzzleFlash;
	public float impactForce = 30f;
	public float Range = 500f;
	public Animator player;
	bool isReloading = false;
	public bool explosiveBullets = false;
	RaycastHit hit;
	float explosiveDuration = 15f;
	public GameObject bullet;
	void Update()
	{
		if (explosiveBullets)
		{
			explosiveDuration -= Time.deltaTime;
			if (explosiveDuration <= 0)
			{
				explosiveBullets = false;
			}
		}
		if (Input.GetButtonDown("Fire1") && isReloading == false)
		{
			Shoot();
			hitEffect.instance.spawnEnemyHitEffect(hit.point, hit.transform);
	
		}
	}
	IEnumerator Reload()
	{
		isReloading = true;
		yield return new WaitForSeconds(2.57f);
		isReloading = false;
	}


	void Shoot()
	{
		muzzleFlash.Play();
		//hitEffect.instance.spawnDefaultHitEffect(barrelEnd.position, barrelEnd.transform);
		Debug.DrawRay(barrelEnd.transform.position, barrelEnd.transform.forward * 200f, Color.black);
		if (Physics.Raycast(barrelEnd.transform.position, barrelEnd.transform.forward, out hit, Range) && hit.transform.tag == "Enemy")
		{
			Debug.Log(hit.transform.name);
			Enemies enemy = hit.transform.GetComponent<Enemies>();
			//Enemies enemy = hit.collider.gameObject.GetComponent<Enemies>();
			bool isCritical = UnityEngine.Random.Range(0, 100) < 25;
			if (isCritical)
				bulletDamage *= 2;
			if (explosiveBullets)
				Instantiate(bullet, hit.point, hit.transform.rotation);
			if (enemy != null)
				enemy.TakeDamage(bulletDamage);
			if (hit.rigidbody != null)
				hit.rigidbody.AddForce(-hit.normal * impactForce);
			DamagePopUp.Create(hit.point, bulletDamage, isCritical);
		}
	}


}


