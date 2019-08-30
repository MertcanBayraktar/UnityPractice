using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FX_From : MonoBehaviour
{
	public static UI_FX_From instance;
	private void Awake()
	{
		instance = this;
	}
	//public characterPROP charProp;
	//public GameObject clickedVFX;
	//public GameObject glowVFX;
	public GameObject UIVFX;
	public GameObject origin;
	public GameObject destination;
	public iTween.EaseType easeType;
	public float time;
	public float rate;
	public float amount;
	public Vector3 offset;
	void Update()
	{
	}
	//public void SpawnClickedVFX()
	//{
	//	if (clickedVFX != null)
	//	{
	//		GameObject vfx = Instantiate(clickedVFX, origin.transform.position, Quaternion.identity);
	//		vfx.transform.SetParent(origin.transform);
	//		var ps = vfx.GetComponent<ParticleSystem>();
	//		Destroy(vfx, ps.main.duration + ps.main.startLifetime.constantMax);
	//	}
	//}
	public void FromTo()
	{
		StartCoroutine(FromToCo());
	}

	IEnumerator FromToCo()
	{
		for (int i = 0; i < amount; i++)
		{
			GameObject vfx = Instantiate(UIVFX, origin.transform.position, Quaternion.identity);
			vfx.transform.SetParent(origin.transform);
			iTween.MoveTo(vfx, iTween.Hash("position", destination.transform.position + offset, "easetype", easeType, "ignoretimescale", true, "time", time));
			Destroy(vfx,time + 0.1f);
			yield return new WaitForSeconds(rate);
		}
	}

}
