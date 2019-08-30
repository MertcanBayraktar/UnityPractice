using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementMAIN : MonoBehaviour
{
	public float speed = 5;
	public float speedWalkBack = 3;
	public float gravity = 8;
	float rotSpeed = 80;
	float rot = 0f;
	Vector3 moveDir = Vector3.zero;
	Animator anim;
	CharacterController controller;
	public Interactable focus;
	void Start()
	{
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
		StartCoroutine(setBBB());

	}
	void Update()
	{
		movement();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Items")
		{
			triggerCheck trigger = gameObject.GetComponent<triggerCheck>();
			trigger.Triggered = true;
			Interactable interactable = other.GetComponent<Interactable>();
			if(interactable != null)
			{
				SetFocus(interactable);
			}
		}
	}
	private void OnTriggerExit(Collider other)
	{
		triggerCheck trigger = gameObject.GetComponent<triggerCheck>();
		trigger.Triggered = false;
	}
	void SetFocus(Interactable newFocus)
	{
		focus = newFocus;
	}
	void RemoveFocus()
	{
		focus = null;
	}
	void movement()
	{
		if (controller.isGrounded)
		{
			if (Input.GetKey(KeyCode.W))
			{
				anim.SetFloat("Vertical_f", 1);
				moveDir = new Vector3(0, 0,1);
				moveDir *= speed;
				moveDir = transform.TransformDirection(moveDir);
			}
			if (Input.GetKeyUp(KeyCode.W))
			{
				anim.SetFloat("Vertical_f", 0);
				anim.SetFloat("horizontal_f", 0);
				moveDir = new Vector3(0, 0, 0);
			}
			if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
			{
				anim.SetFloat("Vertical_f", 0.6f);
				anim.SetFloat("horizontal_f", -0.6f);
				moveDir = new Vector3(-1, 0, 1);
				moveDir *= speed;
				moveDir = transform.TransformDirection(moveDir);

			}
			if(Input.GetKeyUp(KeyCode.W) && Input.GetKey(KeyCode.A))
			{
				anim.SetFloat("Vertical_f", 0);
				anim.SetFloat("horizontal_f", 0);
				moveDir = new Vector3(0, 0, 0);
			}
			if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
			{
				anim.SetFloat("Vertical_f", 0.6f);
				anim.SetFloat("horizontal_f", 0.6f);
				moveDir = new Vector3(1, 0, 1);
				moveDir *= speed;
				moveDir = transform.TransformDirection(moveDir);

			}
			if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.D))
			{
				anim.SetFloat("Vertical_f", 0);
				anim.SetFloat("horizontal_f", 0);
				moveDir = new Vector3(0, 0, 0);
			}
			if (Input.GetKey(KeyCode.S))                                          //ARKA
			{
				anim.SetFloat("Vertical_f", -1);
				moveDir = new Vector3(0, 0, -1);
				moveDir *= speedWalkBack;
				moveDir = transform.TransformDirection(moveDir);
			}
			if (Input.GetKeyUp(KeyCode.S))
			{
				anim.SetFloat("Vertical_f", 0);
				anim.SetFloat("horizontal_f", 0);
				moveDir = new Vector3(0, 0, 0);
			}
			if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
			{
				anim.SetFloat("Vertical_f", -0.6f);
				anim.SetFloat("horizontal_f",0.6f);
				moveDir = new Vector3(1, 0, -1);
				moveDir *= speedWalkBack;
				moveDir = transform.TransformDirection(moveDir);
			}
			if (Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.D))
			{
				moveDir = new Vector3(0, 0, 0);
			}
			if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
			{
				anim.SetFloat("Vertical_f", -0.6f);
				anim.SetFloat("horizontal_f", -0.6f);
				moveDir = new Vector3(-1, 0, -1);
				moveDir *= speedWalkBack;
				moveDir = transform.TransformDirection(moveDir);
			}
			if (Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.A))
			{
				moveDir = new Vector3(0, 0, 0);
			}
		
	}
		rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
		transform.eulerAngles = new Vector3(0, rot, 0);
		moveDir.y -= gravity * Time.deltaTime;
		controller.Move(moveDir * Time.deltaTime);
	}
	IEnumerator setBBB()
	{
		yield return new WaitForSeconds(1f);
		gameObject.GetComponent<bbb>().enabled = true;
	}
}

