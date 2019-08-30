using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
	// Create a Damage Popup
	public static DamagePopUp Create(Vector3 position, float dmg, bool isCriticalHit)
	{
		Transform damagePopupTransform = Instantiate(GameAssets.instance.pDamagePopUp, position, Quaternion.identity);
		DamagePopUp damagePopup = damagePopupTransform.GetComponent<DamagePopUp>();
		damagePopup.Setup(dmg, isCriticalHit);

		return damagePopup;
	}

	private static int sortingOrder;

	private const float DISAPPEAR_TIMER_MAX = 1f;

	private TextMeshPro textMesh;
	private float disappearTimer;
	private Color textColor = Color.red;
	private Vector3 moveVector;

	private void Awake()
	{
		textMesh = transform.GetComponent<TextMeshPro>();
	}

	public void Setup(float dmg, bool isCriticalHit)
	{
		textMesh.SetText(dmg.ToString());
		if (!isCriticalHit)
		{
			// Normal hit
			textMesh.fontSize = 6;

		}
		else
		{
			textMesh.color = textColor;
			textMesh.fontSize = 8;
		}

		disappearTimer = DISAPPEAR_TIMER_MAX;

		sortingOrder++;
		textMesh.sortingOrder = sortingOrder;

		moveVector = new Vector3(-0.4f, 1) * 60f;
	}
	private void Update()
	{
		transform.position += moveVector * Time.deltaTime;
		moveVector -= moveVector * 8f * Time.deltaTime;

		if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
		{
			// First half of the popup lifetime
			float increaseScaleAmount = 1f;
			transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
		}
		else
		{
			// Second half of the popup lifetime
			float decreaseScaleAmount = 1f;
			transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
		}

		disappearTimer -= Time.deltaTime;
		if (disappearTimer < 0)
		{
			// Start disappearing
			float disappearSpeed = 3f;
			textColor.a -= disappearSpeed * Time.deltaTime;
			textMesh.color = textColor;
			if (textColor.a < 0)
			{
				Destroy(gameObject);
			}
		}
	}

}
