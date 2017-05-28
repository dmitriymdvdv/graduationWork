using CnControls;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TankController : MonoBehaviour {
	
	public enum goDirection { up = 0, down = 180, left = -90, right = 90, stay = 360};
	public goDirection direction;
	
	public float speed;
	public GameObject mBullet;
	bool shouldGo = false;
	private Rigidbody rigidbody;
	private Animation animation;
	private Vector3 position;

	Quaternion initialRot;

	void Start () 
	{
		rigidbody = GetComponent <Rigidbody> ();
		animation = GetComponent <Animation> ();
		initialRot = transform.rotation;
	}
	
	void FixedUpdate()
	{
		rigidbody.velocity = Vector3.zero;

		if (direction == goDirection.right || direction == goDirection.left || direction == goDirection.up || direction == goDirection.down) {
			Move ((int)direction);
		}

		MobileMove ();


		if (!animation.IsPlaying("shoot") && !animation.IsPlaying("idle")) {
			animation.Play("idle");
		}
	}

	private void Move (float y) 
	{
		transform.rotation = initialRot;
		transform.Rotate(new Vector3(0, y, 0));
		rigidbody.AddForce(-transform.right * speed, ForceMode.Impulse);
	}

	private void MobileMove () {
		Vector3 movement = new Vector3 (CnInputManager.GetAxis ("Horizontal"), 0f, CnInputManager.GetAxis ("Vertical"));
		if (movement != Vector3.zero) {
			MobileRotate (movement.x, movement.z);
			rigidbody.AddForce (movement * speed, ForceMode.Impulse);
		
		}
	}

	private void MobileRotate (float x, float y) {
		float rotarion = 0;
		if (x < 0 && y > 0) {
			if (Math.Abs (x) > y) {
				rotarion = -90;
			} else {
				rotarion = 0;
			}
		} else if (x > 0 && y > 0) {
			if (Math.Abs (x) > y) {
				rotarion = 90;
			} else {
				rotarion = 0;
			}
		} else if (x < 0 && y < 0) {
			if (Math.Abs (x) > y) {
				rotarion = -90;
			} else {
				rotarion = 180;
			}
		} else if (x > 0 && y < 0) {
			if (Math.Abs (x) > y) {
				rotarion = 90;
			} else {
				rotarion = 180;
			}
		}
		transform.rotation = initialRot;
		transform.Rotate(new Vector3(0, rotarion, 0));
	}

	public void Shoot()
	{
		animation.Play("shoot");
		GameObject bullet = Instantiate(mBullet, transform.position + -transform.right * 7, this.transform.rotation) as GameObject;
		(bullet.GetComponent<Bullet>() as Bullet).owner = this.gameObject;
	}
}
