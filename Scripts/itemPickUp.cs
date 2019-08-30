
using UnityEngine;

public class itemPickUp : Interactable	
{
	public Item item;
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{

			Debug.Log(item.name);
			bool wasPickedUp = Inventory.instance.Add(item);
			if (wasPickedUp)
			{
				Destroy(gameObject);
			}
		}
	}
}
